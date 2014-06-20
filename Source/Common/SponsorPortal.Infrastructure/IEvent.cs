using System;

namespace SponsorPortal.Infrastructure
{
    public interface IEvent
    {
        Guid Id { get; }
        DateTime CreatedTimestamp { get; }
        string AggregateRootIdentifier { get; }
    }
}