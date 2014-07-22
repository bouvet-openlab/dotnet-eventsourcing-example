using System.Threading.Tasks;

namespace SponsorPortal.Infrastructure
{
    public interface IProjection
    {
        Task Initialize();  
    }
}