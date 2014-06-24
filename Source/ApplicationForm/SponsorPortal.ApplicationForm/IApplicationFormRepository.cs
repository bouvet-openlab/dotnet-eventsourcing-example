using System;
using System.Threading.Tasks;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
{
    public interface IApplicationFormRespository
    {
        Task<ApplicationForm> GetApplicationForm(Guid applicationFormId);
        Task Store(IEvent evnt);
    }
}
