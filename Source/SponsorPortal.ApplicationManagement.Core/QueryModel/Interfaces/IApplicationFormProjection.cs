using System.Collections.Immutable;
using SponsorPortal.ApplicationManagement.Core.QueryModel.ApplicationFormAggregate;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Core.QueryModel.Interfaces
{
    public interface IApplicationFormProjection : IProjection
    {
        ImmutableList<ApplicationForm> ApplicationForms { get; }
    }
}