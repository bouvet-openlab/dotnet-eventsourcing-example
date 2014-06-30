using System;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.Web.Http;
using SponsorPortal.ApplicationManagement.Core.CommandModel;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.ApplicationManagement.Core.QueryModel;
using SponsorPortal.Infrastructure;
using ApplicationForm = SponsorPortal.ApplicationManagement.Core.QueryModel.ApplicationForm;

namespace SponsorPortal.ApplicationManagement.Web
{
    public class ApplicationFormController : ApiController
    {
        private readonly IApplicationFormProjection _applicationFormProjection;
        private readonly ICommandDispatcher _commandDispatcher;

        public ApplicationFormController(IApplicationFormProjection applicationFormProjection, ICommandDispatcher commandDispatcher)
        {
            if (applicationFormProjection == null) throw new ArgumentNullException("applicationFormProjection");
            if (commandDispatcher == null) throw new ArgumentNullException("commandDispatcher");
            _applicationFormProjection = applicationFormProjection;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        [Route("applicationforms")]
        public ImmutableList<ApplicationForm> GetAll()
        {
            return _applicationFormProjection.ApplicationForms;
        }
        
        [HttpPost]
        [Route("applicationform")]
        public async Task<IHttpActionResult> SaveNew([FromBody] ApplicationFormDTO applicationForm)
        {
            if (applicationForm == null)
                return BadRequest("The application form is invalid");

            var command = new CreateNewApplicationFormCommand(applicationForm);
            await _commandDispatcher.Execute(command);

            return Ok(String.Format("Application form \"{0}\" received", applicationForm.Title));
        }
    }
}