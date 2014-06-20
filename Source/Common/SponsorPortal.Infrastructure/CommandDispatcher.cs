using System.Threading.Tasks;

namespace SponsorPortal.Infrastructure
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public async Task Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandlers = IoC.ResolveAll<ICommandHandler<TCommand>>();

            foreach (var handler in commandHandlers)
            {
                await handler.Handle(command);
            }
        }
    }
}
