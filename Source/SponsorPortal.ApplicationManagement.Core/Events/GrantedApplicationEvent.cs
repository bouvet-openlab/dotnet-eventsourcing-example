using System;

namespace SponsorPortal.ApplicationManagement.Core.Events
{
    [Serializable]
    public class GrantedApplicationEvent
    {
        public GrantedApplicationEvent(Guid applicationId, double amount, Guid clerkId)
        {
            if (applicationId == Guid.Empty) throw new ArgumentException("ApplicationId cannot be empty guid");
            if (clerkId == Guid.Empty) throw new ArgumentException("ClerkId cannot be empty guid");
            if (amount <= 0.0) throw new ArgumentException("Amount must be greater than zero");

            ApplicationId = applicationId;
            Amount = amount;
            ClerkId = clerkId;
        }

        public Guid ApplicationId { get; private set; }
        public double Amount { get; private set; }
        public Guid ClerkId { get; private set; }
    }
}