using System;

namespace SponsorPortal.ApplicationManagement.Events
{
    [Serializable]
    public class RejectedApplicationEvent
    {
        public Guid ApplicationId { get; private set; }
        public Guid ClerkId { get; private set; }

        public RejectedApplicationEvent(Guid applicationId, Guid clerkId)
        {
            if (applicationId == Guid.Empty) throw new ArgumentException("applicationId cannot be empty guid");
            if (clerkId == Guid.Empty) throw new ArgumentException("clerkId cannot be empty guid");

            ApplicationId = applicationId;
            ClerkId = clerkId;
        }
    }
}