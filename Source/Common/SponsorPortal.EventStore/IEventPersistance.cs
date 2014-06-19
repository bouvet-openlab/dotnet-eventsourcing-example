using System.Collections.Immutable;
using System.Threading.Tasks;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.EventStore
{
    public interface IEventPersistance
    {
        void Initialize();
        Task StoreEvent(IEvent evnt);
        Task<ImmutableList<TEvent>> ReadAllEvents<TEvent>(AggregateRoot aggregateRoot) where TEvent : IEvent;
    }
}
