using System.Collections.Immutable;
using System.Threading.Tasks;
using SponsorPortal.ApplicationManagement.Core.QueryModel.ApplicationFormAggregate;

namespace SponsorPortal.ApplicationManagement.Core.QueryModel.Interfaces
{
    public interface IApplicationFormProjection
    {
        ImmutableList<ApplicationForm> ApplicationForms { get; }
        Task SubscribeToEvents();
        Task GetAllExistingEventsOfInterest();
    }
}