using System.Collections.Immutable;
using SponsorPortal.ClerkManagement.QueryModel.ClerkAggregate;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ClerkManagement.QueryModel.Interfaces
{
    public interface IClerkProjection : IProjection
    {
        ImmutableList<Clerk> Clerks { get; }
    }
}