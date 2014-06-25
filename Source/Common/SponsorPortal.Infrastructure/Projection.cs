using System;
using System.Threading.Tasks;

namespace SponsorPortal.Infrastructure
{
    public abstract class Projection
    {
        protected IEventPersistance EventStore { get; private set; }

        protected Projection(IEventPersistance eventStore)
        {
            if (eventStore == null) throw new ArgumentNullException("eventStore");
            EventStore = eventStore;
        }

        public abstract Task SubscribeToEvents();
    }
}
