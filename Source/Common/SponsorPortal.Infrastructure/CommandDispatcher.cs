namespace SponsorPortal.Infrastructure
{
    public static class CommandDispatcher
    {
        public static void Execute<TCommand>(this TCommand command) where TCommand : ICommand
        {
            var commandHandlers = IoC.ResolveAll<ICommandHandler<TCommand>>();

            foreach (var handler in commandHandlers)
            {
                handler.Handle(command);
            }
        }
    }
}
