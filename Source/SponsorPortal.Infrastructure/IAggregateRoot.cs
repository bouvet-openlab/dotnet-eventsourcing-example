namespace SponsorPortal.Infrastructure
{
    public interface IAggregateRoot
    {
        string Identifier { get; }
    }
}