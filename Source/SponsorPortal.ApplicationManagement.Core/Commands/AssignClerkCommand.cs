using System;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Core.Commands
{
    public class AssignClerkCommand : ICommand
    {
        public Guid ClerkId { get; private set; }
        public Guid ApplicationFormId { get; private set; }

        public AssignClerkCommand(Guid applicationFormId, Guid clerkId)
        {
            if (applicationFormId == Guid.Empty) throw new ArgumentException("applicationFormId cannot be empty");
            if (clerkId == Guid.Empty) throw new ArgumentException("clerkId cannot be empty");
            ApplicationFormId = applicationFormId;
            ClerkId = clerkId;
        }
    }
}