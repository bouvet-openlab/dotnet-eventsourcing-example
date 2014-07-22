using System;
using SponsorPortal.ApplicationManagement.CommandModel.ValueObjects;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Commands
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
