using System.Threading.Tasks;

namespace SponsorPortal.Infrastructure
{
    public interface ICommandHandler
    {
        
    }

    public interface ICommandHandler<in TCommand>
    {
        Task Handle(TCommand command);
    }
}
