using System.Collections.Immutable;
using System.Threading.Tasks;

namespace SponsorPortal.ApplicationManagement.Core.QueryModel
{
    public interface IApplicationFormProjection
    {
        ImmutableList<ApplicationForm> ApplicationForms { get; }
        Task SubscribeToEvents();
        Task GetAllExistingEventsOfInterest();
    }
}