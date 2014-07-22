using System.Collections.Immutable;
using SponsorPortal.ClerkManagement.QueryModel;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ClerkManagement.Interfaces
{
    public interface IClerkProjection : IProjection
    {
        ImmutableList<Clerk> Clerks { get; }
    }
}