using System.Threading.Tasks;

namespace SponsorPortal.Infrastructure
{
    public interface ICommandDispatcher
    {
        Task Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}