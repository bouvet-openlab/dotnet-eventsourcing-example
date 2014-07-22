using System;

namespace SponsorPortal.ApplicationManagement.Commands
{
    public class RejectApplicationCommand
    {
        public RejectApplicationCommand(Guid applicationId, Guid clerkId)
        {
            if (applicationId == Guid.Empty) throw new ArgumentException("ApplicationId cannot be empty guid");
            if (clerkId == Guid.Empty) throw new ArgumentException("ClerkId cannot be empty guid");
            
            ApplicationId = applicationId;
            ClerkId = clerkId;
        }

        public Guid ApplicationId { get; private set; }
        public Guid ClerkId { get; private set; }
    }
}