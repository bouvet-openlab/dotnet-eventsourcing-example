using System;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Core.Events
{
    [Serializable]
    public class ClerkAssignedToApplicationFormEvent : EventBase
    {
        public Guid ApplicationFormId { get; private set; }
        public Guid ClerkId { get; private set; }

        public ClerkAssignedToApplicationFormEvent(Guid applicationFormId, Guid clerkId) : base(AggregateRoot.ApplicationForm)
        {
            if (applicationFormId == Guid.Empty) throw new ArgumentException("applicationFormId cannot be empty");
            if (clerkId == Guid.Empty) throw new ArgumentException("clerkId cannot be empty");
            ApplicationFormId = applicationFormId;
            ClerkId = clerkId;
        }
    }
}
