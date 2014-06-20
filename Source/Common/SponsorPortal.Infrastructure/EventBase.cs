using System;

namespace SponsorPortal.Infrastructure
{
    public abstract class EventBase : IEvent
    {
        public AggregateRoot AggregateRoot { get; private set; }
        public Guid Id { get; private set; }
        public DateTime CreatedTimestamp { get; private set; }

        protected EventBase(AggregateRoot aggregateRoot)
        {
            AggregateRoot = aggregateRoot;
            Id = Guid.NewGuid();
            CreatedTimestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return String.Format("AggregateRoot={0}, Id={1}, CreatedTimestamp={2}", AggregateRoot.Identifier, Id, CreatedTimestamp);
        }
    }
}
