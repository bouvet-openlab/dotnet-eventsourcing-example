using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.Web.Http;
using SponsorPortal.ApplicationManagement.Core.QueryModel;
using ApplicationForm = SponsorPortal.ApplicationManagement.Core.QueryModel.ApplicationForm;

namespace SponsorPortal.ApplicationManagement.Web
{
    public class ApplicationFormController : ApiController
    {
        private readonly IApplicationFormProjection _applicationFormProjection;

        public ApplicationFormController(IApplicationFormProjection applicationFormProjection)
        {
            if (applicationFormProjection == null) throw new ArgumentNullException("applicationFormProjection");
            _applicationFormProjection = applicationFormProjection;
        }

        [HttpGet]
        [Route("applicationforms")]
        public async Task<ImmutableList<ApplicationForm>> GetAll()
        {
            return await Task.FromResult(_applicationFormProjection.ApplicationForms);
        }
    }
}