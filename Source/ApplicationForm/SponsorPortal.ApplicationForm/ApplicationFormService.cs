using System;
using System.Threading.Tasks;
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

        public async Task Handle(CreateNewApplicationFormCommand command)
        {
            var createdNewApplicationFormEvent = ApplicationForm.CreateNew(command.ApplicationForm.Organization, command.ApplicationForm.Email, command.ApplicationForm.Amount, command.ApplicationForm.Title, command.ApplicationForm.Text);
            await _applicationFormRespository.Store(createdNewApplicationFormEvent);
        }
    }
}
