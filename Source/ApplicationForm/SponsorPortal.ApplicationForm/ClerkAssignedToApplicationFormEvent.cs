using System;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
{
    public class ClerkAssignedToApplicationFormEvent : EventBase
    {
        public Guid ApplicationFormId { get; private set; }
        public string ClerkId { get; private set; }

        public ClerkAssignedToApplicationFormEvent(AggregateRoot aggregateRoot, Guid applicationFormId, string clerkId) : base(aggregateRoot)
        {
            if (aggregateRoot == null) throw new ArgumentNullException("aggregateRoot");
            if (String.IsNullOrEmpty(clerkId)) throw new ArgumentNullException("clerkId");
            ApplicationFormId = applicationFormId;
            ClerkId = clerkId;
        }
    }
}
