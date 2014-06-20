using System;

namespace SponsorPortal.Infrastructure
{
    public abstract class EventBase : IEvent
    {
        public string AggregateRootIdentifier { get; private set; }
        public Guid Id { get; private set; }
        public DateTime CreatedTimestamp { get; private set; }

        protected EventBase(string aggregateRootIdentifier)
        {
            if (aggregateRootIdentifier == null) throw new ArgumentNullException("aggregateRootIdentifier");
            AggregateRootIdentifier = aggregateRootIdentifier;
            Id = Guid.NewGuid();
            CreatedTimestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return String.Format("AggregateRoot={0}, Id={1}, CreatedTimestamp={2}", AggregateRootIdentifier, Id, CreatedTimestamp);
        }
    }
}
