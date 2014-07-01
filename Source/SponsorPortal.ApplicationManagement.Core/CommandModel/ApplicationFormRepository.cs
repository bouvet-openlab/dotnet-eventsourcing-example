using System;
using System.Linq;
using System.Threading.Tasks;
using SponsorPortal.ApplicationManagement.Core.Events;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Core.CommandModel
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
            var events = await _eventPersistance.ReadAllEvents<CreatedNewApplicationFormEvent>();
            return events.Where(evnt => evnt.EntityId == applicationFormId)
                         .Select(evnt => new ApplicationForm(evnt.EntityId, evnt.Organization, evnt.Email, evnt.Amount, evnt.Title, evnt.Text))
                         .SingleOrDefault();
        }

        public async Task Store(IEvent evnt)
        {
            await _eventPersistance.Store(evnt);
        }
    }
}
