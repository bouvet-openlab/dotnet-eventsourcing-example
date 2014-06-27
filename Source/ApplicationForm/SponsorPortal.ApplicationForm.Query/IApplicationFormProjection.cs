using System.Collections.Immutable;
using System.Threading.Tasks;

namespace SponsorPortal.ApplicationForm.Query
{
    public interface IApplicationFormProjection
    {
        ImmutableList<ApplicationForm> ApplicationForms { get; }
        Task SubscribeToEvents();
        Task GetAllExistingEventsOfInterest();
    }
}