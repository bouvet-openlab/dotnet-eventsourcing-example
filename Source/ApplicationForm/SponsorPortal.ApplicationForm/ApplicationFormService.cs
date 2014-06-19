using System;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
{
    public class ApplicationFormService : ICommandHandler<CreateNewApplicationFormCommand>
    {
        private readonly IApplicationFormRespository _applicationFormRespository;

        public ApplicationFormService(IApplicationFormRespository applicationFormRespository)
        {
            if (applicationFormRespository == null) throw new ArgumentNullException("applicationFormRespository");
            _applicationFormRespository = applicationFormRespository;
        }

        public void Handle(CreateNewApplicationFormCommand command)
        {
            var createdNewApplicationFormEvent = ApplicationForm.CreateNew(command.ApplicationForm.Organization, command.ApplicationForm.Email, command.ApplicationForm.Amount, command.ApplicationForm.Title, command.ApplicationForm.Text);
            _applicationFormRespository.Store(createdNewApplicationFormEvent);
        }
    }
}
