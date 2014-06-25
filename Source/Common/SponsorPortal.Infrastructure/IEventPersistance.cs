using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using SponsorPortal.Helpers;

namespace SponsorPortal.Infrastructure
{
    public interface IEventPersistance
    {
        void Initialize();
        Task StoreEvent(IEvent evnt);
        Task<ImmutableList<TEvent>> ReadAllEvents<TEvent>(AggregateRoots aggregateRoot) where TEvent : IEvent;
        Task Subscribe<TEvent>(Action<TEvent> subscription) where TEvent : IEvent;
    }
}
