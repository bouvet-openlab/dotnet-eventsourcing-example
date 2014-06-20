using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
{
    public class ApplicationFormRepository : IApplicationFormRespository
    {
        private readonly IEventStore _eventStore;
        private readonly ApplicationFormProjection _applicationFormProjection;

        public ApplicationFormRepository(IEventStore eventStore, ApplicationFormProjection applicationFormProjection)
        {
            if (eventStore == null) throw new ArgumentNullException("eventStore");
            if (applicationFormProjection == null) throw new ArgumentNullException("applicationFormProjection");
            _eventStore = eventStore;
            _applicationFormProjection = applicationFormProjection;
        }

        public ApplicationForm CreateNewApplication(string organization, string email, double amount, string title, string text)
        {
            return new ApplicationForm(organization, email, amount, title, text);
        }

        public ApplicationForm GetApplicationForm(Guid applicationFormId)
        {
            var applicationForm = _applicationFormProjection.ApplicationForms.SingleOrDefault(appForm => appForm.Id == applicationFormId);
            if (applicationForm != null)
            {
                return new ApplicationForm(applicationForm.Organization, applicationForm.Email, applicationForm.Amount, applicationForm.Title, applicationForm.Text);
            }
            throw new Exception("Could not find an application matching the id " + applicationFormId);
        }

        public async Task Store(CreatedNewApplicationFormEvent evnt)
        {
            await _eventStore.Tell(evnt);
        }
    }
}
