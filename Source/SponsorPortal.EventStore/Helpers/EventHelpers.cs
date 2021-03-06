﻿using EventStore.ClientAPI;

namespace SponsorPortal.EventStore.Helpers
{
    internal static class EventHelpers
    {
        internal static string GetNameFor<TEvent>()
        {
            return typeof (TEvent).Name;
        }

        internal static string GetNameFor<TEvent>(TEvent evnt)
        {
            return evnt.GetType().Name;
        }

        internal static bool IsSameTypeAs<TEvent>(ResolvedEvent resolvedEvent)
        {
            return resolvedEvent.Event.EventType == GetNameFor<TEvent>();
        }
    }
}
