using System;
using SponsorPortal.Helpers;

namespace SponsorPortal.Infrastructure
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; private set; }

        protected AggregateRoot(Guid id)
        {
            Id = id;
        }

        public abstract AggregateRoots AggregateRootIdentifier { get; }
    }
}
