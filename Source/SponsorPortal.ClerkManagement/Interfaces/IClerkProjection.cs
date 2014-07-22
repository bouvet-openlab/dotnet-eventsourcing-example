using System.Collections.Immutable;
using System.Threading.Tasks;
using SponsorPortal.ClerkManagement.QueryModel;

namespace SponsorPortal.ClerkManagement.Interfaces
{
    public interface IClerkProjection
    {
        ImmutableList<Clerk> Clerks { get; }
        Task SubscribeToEvents();
    }
}