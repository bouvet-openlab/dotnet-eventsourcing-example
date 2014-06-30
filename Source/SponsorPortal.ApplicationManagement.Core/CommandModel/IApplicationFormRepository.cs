using System;
using System.Threading.Tasks;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Core.CommandModel
{
    public interface IApplicationFormRespository
    {
        Task<CommandModel.ApplicationForm> GetApplicationForm(Guid applicationFormId);
        Task Store(IEvent evnt);
    }
}
