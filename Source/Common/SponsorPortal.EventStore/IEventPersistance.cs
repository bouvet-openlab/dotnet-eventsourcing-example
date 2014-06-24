using System.Collections.Immutable;
using System.Threading.Tasks;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.EventStore
{
    public interface IEventPersistance
    {
        void Initialize();
        Task StoreEvent(IEvent evnt);
        Task<ImmutableList<TEvent>> ReadAllEvents<TEvent>(AggregateRoots aggregateRoot) where TEvent : IEvent;
    }
}
