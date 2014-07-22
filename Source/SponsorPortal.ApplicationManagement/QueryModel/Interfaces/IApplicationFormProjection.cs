using System.Collections.Immutable;
using SponsorPortal.ApplicationManagement.QueryModel.ApplicationFormAggregate;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.QueryModel.Interfaces
{
    public interface IApplicationFormProjection : IProjection
    {
        ImmutableList<ApplicationForm> ApplicationForms { get; }
    }
}