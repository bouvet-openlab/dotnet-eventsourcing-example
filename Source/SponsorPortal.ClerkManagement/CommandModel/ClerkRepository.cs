using System;
using System.Threading.Tasks;
using SponsorPortal.ClerkManagement.Interfaces;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ClerkManagement.CommandModel
{
    public class ClerkRepository : IClerkRepository
    {
        private readonly IEventPersistance _eventPersistance;

        public ClerkRepository(IEventPersistance eventPersistance)
        {
            if (eventPersistance == null) throw new ArgumentNullException("eventPersistance");
            _eventPersistance = eventPersistance;
        }

        public async Task Store(IEvent evnt)
        {
            await _eventPersistance.Store(evnt);
        }
    }
}
