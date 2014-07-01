using System;
using SponsorPortal.Helpers;

namespace SponsorPortal.Infrastructure
{
    public abstract class Aggregate
    {
        public Guid Id { get; private set; }

        protected Aggregate(Guid id)
        {
            Id = id;
        }

        public abstract AggregateRoot AggregateRootIdentifier { get; }
    }
}
