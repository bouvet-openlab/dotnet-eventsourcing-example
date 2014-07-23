using System;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Events
{
    [Serializable]
    public class GrantedApplicationEvent : EventBase
    {
        public GrantedApplicationEvent(Guid applicationId, double amount, Guid clerkId) : base(AggregateRoot.ApplicationForm)
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

        public override string LogDescription
        {
            get { return "Granted " + Amount + " by " + ClerkId; }
        }
    }
}