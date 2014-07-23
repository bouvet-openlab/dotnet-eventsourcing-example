using System;
using SponsorPortal.Helpers;

namespace SponsorPortal.Infrastructure
{
    [Serializable]
    public abstract class EventBase : IEvent
    {
        public AggregateRoot AggregateRootIdentifier { get; private set; }
        public Guid EntityId { get; private set; }
        public DateTime CreatedTimestamp { get; private set; }

        protected EventBase(AggregateRoot aggregateRootIdentifier)
        {
            AggregateRootIdentifier = aggregateRootIdentifier;
            EntityId = Guid.NewGuid();
            CreatedTimestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return String.Format("Aggregate={0}, Id={1}, CreatedTimestamp={2}", AggregateRootIdentifier, EntityId, CreatedTimestamp);
        }

        public abstract string LogDescription { get; }
    }
}
