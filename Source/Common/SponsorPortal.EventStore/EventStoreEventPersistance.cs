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
                                                                .OnClosed((conn, reason) => Debug.WriteLine("Event Store connection closed"))
                                                                .OnDisconnected((conn, endpoint) => Debug.WriteLine("Event Store disconnected"))
                                                                .OnReconnecting((conn) => Debug.WriteLine("Reconnecting to Event Store"))
                                                                .UseDebugLogger()
                                                                .UseNormalConnection();

            _connection = EventStoreConnection.Create(connectionSettings, new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1113));
            _connection.Connect();
        }

        public void Teardown()
        {
            _connection.Close();
        }

        public async Task StoreEvent(IEvent evnt)
        {
            var data = evnt.ToBinaryArray();
            var streamId = evnt.AggregateRootIdentifier.ToString();
            var eventdata = new EventData(Guid.NewGuid(), evnt.GetType().Name, false, data, null);

            await _connection.AppendToStreamAsync(streamId, ExpectedVersion.Any, eventdata);
        }

        public async Task<ImmutableList<TEvent>> ReadAllEvents<TEvent>(AggregateRoots aggregateRoot) where TEvent : IEvent
        {
            var streamId = aggregateRoot.ToString();
            var events = await ReadStream(streamId);
            
            return events.Where(evnt => evnt.Event.EventType == typeof(TEvent).Name)
                         .Select(evnt => evnt.ParseTo<TEvent>())
                         .ToImmutableList();
        }

        public async Task Subscribe<TEvent>(Action<TEvent> subscription) where TEvent : IEvent
        {
            var eventType = typeof (TEvent).Name;

            Action<EventStoreSubscription, ResolvedEvent> onEventAppeared = (sub, evnt) =>
            {
                Debug.WriteLine("Event appeared");

                if (evnt.Event.EventType == eventType)
                {
                    var e = evnt.ParseTo<TEvent>();
                    subscription(e);
                }
            };

            await _connection.SubscribeToStreamAsync(AggregateRoots.ApplicationForm.ToString(), true, onEventAppeared, SubscriptionDropped);
        }

        private void SubscriptionDropped(EventStoreSubscription eventStoreSubscription, SubscriptionDropReason subscriptionDropReason, Exception arg3)
        {
            Debug.WriteLine("Subscription dropped: ", subscriptionDropReason);
        }

        private void EventAppeared(EventStoreSubscription eventStoreSubscription, ResolvedEvent resolvedEvent)
        {
            
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
