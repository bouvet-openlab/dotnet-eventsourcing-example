using System;
using System.Threading.Tasks;

namespace SponsorPortal.Infrastructure
{
    public abstract class Projection
    {
        protected IEventPersistance EventStore { get; private set; }
        public bool IsInitialized { get; protected set; }

        protected Projection(IEventPersistance eventStore)
        {
            if (eventStore == null) throw new ArgumentNullException("eventStore");
            EventStore = eventStore;
        }

        protected abstract Task SubscribeToEvents();

        protected abstract Task GetPersistedEvents();

        public async virtual Task Initialize()
        {
            if (!IsInitialized)
            {
                await GetPersistedEvents();
                await SubscribeToEvents();
                IsInitialized = true;
            }
        }
    }
}
