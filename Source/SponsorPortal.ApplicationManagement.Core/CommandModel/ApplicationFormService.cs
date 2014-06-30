using System;
using System.Threading.Tasks;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Core.CommandModel
{
    public class ApplicationFormService : ICommandHandler<CreateNewApplicationFormCommand>, ICommandHandler<AssignClerkCommand>
    {
        private readonly IApplicationFormRespository _applicationFormRespository;

        public ApplicationFormService(IApplicationFormRespository applicationFormRespository)
        {
            if (applicationFormRespository == null) throw new ArgumentNullException("applicationFormRespository");
            _applicationFormRespository = applicationFormRespository;
        }

        public async Task Handle(CreateNewApplicationFormCommand command)
        {
            var createdNewApplicationFormEvent = CommandModel.ApplicationForm.CreateNew(command.ApplicationForm.Organization, command.ApplicationForm.Email, command.ApplicationForm.Amount, command.ApplicationForm.Title, command.ApplicationForm.Text);
            await _applicationFormRespository.Store(createdNewApplicationFormEvent);
        }

        public async Task Handle(AssignClerkCommand command)
        {
            var applicationForm = await _applicationFormRespository.GetApplicationForm(command.ApplicationFormId);
            if (applicationForm == null)
                throw new ApplicationFormNotFoundException("Could not find application form with id " + command.ApplicationFormId);

            var clerkAssignedToApplicationFormEvent = applicationForm.AssignClerk(command.ClerkId);
            await _applicationFormRespository.Store(clerkAssignedToApplicationFormEvent);
        }
    }
}
