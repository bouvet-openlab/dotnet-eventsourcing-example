using System;

namespace SponsorPortal.Infrastructure
{
    public abstract class Projection
    {
        protected IEventStore EventStore { get; private set; }

        protected Projection(IEventStore eventStore)
        {
            if (eventStore == null) throw new ArgumentNullException("eventStore");
            EventStore = eventStore;
        }

        public abstract void SubscribeToEvents();
    }
}
