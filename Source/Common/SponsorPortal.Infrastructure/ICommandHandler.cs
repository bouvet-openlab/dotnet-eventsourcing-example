namespace SponsorPortal.Infrastructure
{
    public interface ICommandHandler
    {
        
    }

    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }
}
