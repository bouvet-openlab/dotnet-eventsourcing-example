using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.EventStore
{
    public class SponsorPortalEventStore : IEventStore
    {
        private readonly IEventPersistance _eventPersistance;

        public SponsorPortalEventStore(IEventPersistance eventPersistance)
        {
            if (eventPersistance == null) throw new ArgumentNullException("eventPersistance");
            _eventPersistance = eventPersistance;
        }

        public async Task Tell<TEvent>(TEvent evnt) where TEvent : IEvent
        {
            try
            {
                await _eventPersistance.StoreEvent(evnt);
                TellSubscribers(evnt);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> eventSubscription) where TEvent : IEvent
        {
            EventSubscription<TEvent>.Subscribe(eventSubscription);
        }

        private void TellSubscribers<TEvent>(TEvent evnt) where TEvent : IEvent
        {
            var subscriptions = EventSubscription<TEvent>.GetSubscriptions();
            foreach (var subscriber in subscriptions)
                subscriber(evnt);
        }
    }
}
