using System;
using SponsorPortal.ApplicationManagement.Core.CommandModel;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Core.Commands
{
    public class CreateNewApplicationFormCommand : ICommand
    {
        public CreateNewApplicationFormCommand(ApplicationFormDTO applicationForm)
        {
            if (applicationForm == null) throw new ArgumentNullException("applicationForm");
            ApplicationForm = applicationForm;
        }

        public ApplicationFormDTO ApplicationForm { get; private set; }
    }
}
