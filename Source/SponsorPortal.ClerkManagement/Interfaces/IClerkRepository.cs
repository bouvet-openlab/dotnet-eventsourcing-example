using System.Threading.Tasks;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ClerkManagement.Interfaces
{
    public interface IClerkRepository
    {
        Task Store(IEvent evnt);
    }
}
