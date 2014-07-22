using System;
using System.Threading.Tasks;
using SponsorPortal.ApplicationManagement.CommandModel.ApplicationFormAggregate;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.CommandModel.Interfaces
{
    public interface IApplicationFormRespository
    {
        Task<ApplicationForm> GetApplicationForm(Guid applicationFormId);
        Task Store(IEvent evnt);
    }
}
