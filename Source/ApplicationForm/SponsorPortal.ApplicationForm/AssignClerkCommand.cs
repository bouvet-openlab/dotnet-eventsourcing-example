using System;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
{
    public class AssignClerkCommand : ICommand
    {
        public string ClerkId { get; private set; }
        public Guid ApplicationFormId { get; private set; }

        public AssignClerkCommand(Guid applicationFormId, string clerkId)
        {
            if (String.IsNullOrEmpty(clerkId)) throw new ArgumentNullException("clerkId");
            ApplicationFormId = applicationFormId;
            ClerkId = clerkId;
        }
    }
}