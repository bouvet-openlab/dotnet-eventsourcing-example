﻿using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using SponsorPortal.Helpers;

namespace SponsorPortal.Infrastructure
{
    public interface IEventPersistance
    {
        void Initialize();
        void Teardown();
        Task Store(IEvent evnt);
        Task<ImmutableList<TEvent>> ReadAllFromAggregate<TEvent>(AggregateRoot aggregateRoot) where TEvent : IEvent;
        Task<ImmutableList<TEvent>> ReadAllEvents<TEvent>() where TEvent : IEvent;
        Task SubscribeToNew<TEvent>(AggregateRoot aggregateRoot, Action<TEvent> subscription) where TEvent : IEvent;
        Task SubscribeFromStart<TEvent>(AggregateRoot aggregateRoot, Action<TEvent> subscription) where TEvent : IEvent;
    }
}
