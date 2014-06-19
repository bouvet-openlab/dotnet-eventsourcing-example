using System;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
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
