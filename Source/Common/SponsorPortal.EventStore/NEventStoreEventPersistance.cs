using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using NEventStore;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.EventStore
{
    public class NEventStoreEventPersistance : IEventPersistance
    {
        private IStoreEvents _eventStore;

        public void Initialize()
        {
            _eventStore = Wireup.Init()
                .LogToOutputWindow()
                .UsingInMemoryPersistence()
                .InitializeStorageEngine()
                .UsingJsonSerialization()
                .Compress()
                .Build();
        }

        public async Task StoreEvent(IEvent evnt)
        {
            await Task.Run(() =>
            {
                using (var stream = _eventStore.OpenStream(evnt.AggregateRootIdentifier))
                {
                    var metadata = new Dictionary<string, object>
                            {
                                {"Id", evnt.Id},
                                {"CreatedTimestamp", evnt.CreatedTimestamp}
                            };

                    stream.Add(new EventMessage {Body = evnt, Headers = metadata});
                    stream.CommitChanges(Guid.NewGuid());
                }
            });
        }

        public async Task<ImmutableList<TEvent>> ReadAllEvents<TEvent>(AggregateRoot aggregateRoot) where TEvent : IEvent
        {
            return await Task.Run(() =>
            {
                using (var stream = _eventStore.OpenStream(aggregateRoot.Identifier))
                {
                    return stream.CommittedEvents.Where(evnt => evnt.Body is TEvent)
                                                 .Select(evnt => evnt.Body)
                                                 .Cast<TEvent>()
                                                 .ToImmutableList();
                }
            });
        }
    }
}
