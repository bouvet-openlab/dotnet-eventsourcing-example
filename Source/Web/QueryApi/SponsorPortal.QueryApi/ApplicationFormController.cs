using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.Web.Http;
using SponsorPortal.ApplicationForm.Query;

namespace SponsorPortal.QueryApi
{
    public class ApplicationFormController : ApiController
    {
        private readonly ApplicationFormProjection _applicationFormProjection;

        public ApplicationFormController(ApplicationFormProjection applicationFormProjection)
        {
            if (applicationFormProjection == null) throw new ArgumentNullException("applicationFormProjection");
            _applicationFormProjection = applicationFormProjection;
        }

        [HttpGet]
        [Route("applicationforms")]
        public async Task<ImmutableList<ApplicationForm.Query.ApplicationForm>> GetAll()
        //public ImmutableList<ApplicationForm.Query.ApplicationForm> GetAll()
        {
            return await Task.FromResult(_applicationFormProjection.ApplicationForms);
            //return _applicationFormProjection.ApplicationForms;
        }
    }
}