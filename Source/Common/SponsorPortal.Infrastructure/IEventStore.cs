using System;
using System.Threading.Tasks;

namespace SponsorPortal.Infrastructure
{
    public interface IEventStore
    {
        Task Tell<TEvent>(TEvent evnt) where TEvent : IEvent;
        void Subscribe<TEvent>(Action<TEvent> eventSubscription) where TEvent : IEvent;
    }
}
