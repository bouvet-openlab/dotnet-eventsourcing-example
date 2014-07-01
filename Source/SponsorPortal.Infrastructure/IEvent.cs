using System;
using SponsorPortal.Helpers;

namespace SponsorPortal.Infrastructure
{
    public interface IEvent
    {
        Guid EntityId { get; }
        DateTime CreatedTimestamp { get; }
        AggregateRoot AggregateRootIdentifier { get; }
    }
}