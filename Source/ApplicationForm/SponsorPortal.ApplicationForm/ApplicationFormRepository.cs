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

        public ApplicationFormRepository(IEventStore eventStore)
        {
            if (eventStore == null) throw new ArgumentNullException("eventStore");
            _eventStore = eventStore;
        }

        public ApplicationForm CreateNewApplication(string organization, string email, double amount, string title, string text)
        {
            throw new NotImplementedException();
        }

        public ApplicationForm GetApplicationForm()
        {
            throw new NotImplementedException();
        }

        public async Task Store(CreatedNewApplicationFormEvent evnt)
        {
            await _eventStore.Tell(evnt);
        }
    }
}
