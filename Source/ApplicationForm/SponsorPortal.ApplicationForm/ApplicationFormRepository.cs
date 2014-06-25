using System;
using System.Linq;
using System.Threading.Tasks;
using SponsorPortal.ApplicationForm.Common;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
{
    public class ApplicationFormRepository : IApplicationFormRespository
    {
        private readonly IEventPersistance _eventPersistance;

        public ApplicationFormRepository(IEventPersistance eventPersistance)
        {
            if (eventPersistance == null) throw new ArgumentNullException("eventPersistance");
            _eventPersistance = eventPersistance;
        }
        
        public async Task<ApplicationForm> GetApplicationForm(Guid applicationFormId)
        {
            var events = await _eventPersistance.ReadAllEvents<CreatedNewApplicationFormEvent>(AggregateRoots.ApplicationForm);
            return events.Where(evnt => evnt.EntityId == applicationFormId)
                         .Select(evnt => new ApplicationForm(evnt.EntityId, evnt.Organization, evnt.Email, evnt.Amount, evnt.Title, evnt.Text))
                         .SingleOrDefault();
        }

        public async Task Store(IEvent evnt)
        {
            await _eventPersistance.StoreEvent(evnt);
        }
    }
}
