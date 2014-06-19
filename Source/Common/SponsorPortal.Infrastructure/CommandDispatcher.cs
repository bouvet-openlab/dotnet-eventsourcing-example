namespace SponsorPortal.Infrastructure
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandlers = IoC.ResolveAll<ICommandHandler<TCommand>>();

            foreach (var handler in commandHandlers)
            {
                handler.Handle(command);
            }
        }
    }
}
