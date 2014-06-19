using System;
using System.Collections.Generic;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.EventStore
{
    internal static class EventSubscription<TEvent> where TEvent : IEvent
    {
        private static readonly List<Action<TEvent>> EventSubscriptions;

        static EventSubscription()
        {
            EventSubscriptions = new List<Action<TEvent>>();
        }

        public static void Subscribe(Action<TEvent> subscription)
        {
            EventSubscriptions.Add(subscription);
        }

        public static IReadOnlyList<Action<TEvent>> GetSubscriptions()
        {
            return EventSubscriptions;
        }
    }
}
