using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using SponsorPortal.EventStore.Helpers;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.EventStore
{
    /// <summary>
    /// This is an implementation of the http://geteventstore.com/. 
    /// Since it's just called 'Event Store' the naming is somewhat confusing with this project.
    /// </summary>
    public class EventStoreEventPersistance : IEventPersistance
    {
        private IEventStoreConnection _connection;

        public void Initialize()
        {
            var connectionSettings = ConnectionSettings.Create().EnableVerboseLogging()
                                                                .LimitAttemptsForOperationTo(3)
                                                                .OnConnected((conn, endpoint) => Debug.WriteLine("Event Store connected"))
                                                                .OnClosed((conn, reason) => Debug.WriteLine("Event Store connection closed " + reason))
                                                                .OnDisconnected((conn, endpoint) => Debug.WriteLine("Event Store disconnected"))
                                                                .OnReconnecting((conn) => Debug.WriteLine("Reconnecting to Event Store"))
                                                                .OnErrorOccurred((conn, ex) => Debug.WriteLine("Event Store error occurred " + ex))
                                                                .UseDebugLogger()
                                                                .UseNormalConnection();

            _connection = EventStoreConnection.Create(connectionSettings, new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1113));
            _connection.Connect();
        }

        public void Teardown()
        {
            _connection.Close();
        }

        public async Task Store(IEvent evnt)
        {
            var data = evnt.ToBinaryArray();
            var streamId = evnt.AggregateRootIdentifier.ToString();
            var eventdata = new EventData(Guid.NewGuid(), EventHelpers.GetNameFor(evnt), false, data, null);

            await _connection.AppendToStreamAsync(streamId, ExpectedVersion.Any, eventdata);
        }

        public async Task<ImmutableList<TEvent>> ReadAllFromAggregate<TEvent>(AggregateRoot aggregateRoot) where TEvent : IEvent
        {
            var streamId = aggregateRoot.ToString();
            var events = await ReadStream(streamId);

            return events.Where(EventHelpers.IsSameTypeAs<TEvent>)
                         .Select(evnt => evnt.ParseTo<TEvent>())
                         .ToImmutableList();
        }

        public async Task<ImmutableList<TEvent>> ReadAllEvents<TEvent>() where TEvent : IEvent
        {
            var events = await ReadAll();
            return events.Where(EventHelpers.IsSameTypeAs<TEvent>)
                .Select(evnt => evnt.ParseTo<TEvent>())
                .ToImmutableList();
        }

        public async Task SubscribeFromStart<TEvent>(AggregateRoot aggregateRoot, Action<TEvent> subscription) where TEvent : IEvent
        {
            Action<EventStoreCatchUpSubscription, ResolvedEvent> onEventAppeared = (catchUpSubscription, resolvedEvent) =>
            {
                if (!EventHelpers.IsSameTypeAs<TEvent>(resolvedEvent)) return;

                Debug.WriteLine("Catching up...");
                var evnt = resolvedEvent.ParseTo<TEvent>();
                subscription(evnt);
            };

            Action<EventStoreCatchUpSubscription> onIsUpToDate = (catchUpSubscription) =>
            {
                Debug.WriteLine("Subscription is up to date");
            };

            var streamId = aggregateRoot.ToString();
            await Task.FromResult(_connection.SubscribeToStreamFrom(streamId, null, true, onEventAppeared, onIsUpToDate));
        }

        public async Task SubscribeToNew<TEvent>(AggregateRoot aggregateRoot, Action<TEvent> subscription) where TEvent : IEvent
        {
            Action<EventStoreSubscription, ResolvedEvent> onEventAppeared = (sub, resolvedEvent) =>
            {
                if (!EventHelpers.IsSameTypeAs<TEvent>(resolvedEvent)) return;

                var evnt = resolvedEvent.ParseTo<TEvent>();
                subscription(evnt);
            };

            var streamId = aggregateRoot.ToString();
            await _connection.SubscribeToStreamAsync(streamId, true, onEventAppeared);
        }
        
        private async Task<ImmutableList<ResolvedEvent>> ReadAll()
        {
            var result = await _connection.ReadAllEventsForwardAsync(Position.Start, Int32.MaxValue, true);
            return result.Events.ToImmutableList();
        }

        private async Task<ImmutableList<ResolvedEvent>> ReadStream(string streamId)
        {
            var streamEvents = new List<ResolvedEvent>();
            StreamEventsSlice currentSlice;
            var nextSliceStart = StreamPosition.Start;
            do
            {
                currentSlice = await _connection.ReadStreamEventsForwardAsync(streamId, nextSliceStart, 200, false);
                nextSliceStart = currentSlice.NextEventNumber;

                streamEvents.AddRange(currentSlice.Events);
            } while (!currentSlice.IsEndOfStream);

            return streamEvents.ToImmutableList();
        }
    }
}
