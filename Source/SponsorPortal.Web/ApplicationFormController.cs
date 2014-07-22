using System;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using SponsorPortal.ApplicationManagement.Core.CommandModel.ValueObjects;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.ApplicationManagement.Core.QueryModel.ApplicationFormAggregate;
using SponsorPortal.ApplicationManagement.Core.QueryModel.Interfaces;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.Web
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

        [HttpGet]
        [Route("applicationforms/{applicationId}")]
        public IHttpActionResult GetById(Guid? applicationId)
        {
            if (applicationId == null || applicationId == Guid.Empty)
                return BadRequest("The application id \""+ applicationId +"\" is invalid");

            var applicationForm = _applicationFormProjection.ApplicationForms.SingleOrDefault(appForm => appForm.Id == applicationId);
            
            return Ok(applicationForm);
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

        [HttpPost]
        [Route("applicationform/{applicationId}/assignclerk/{clerkId}")]
        public async Task<IHttpActionResult> AssignClerk(Guid? applicationId, Guid? clerkId)
        {
            if (applicationId == null || applicationId == Guid.Empty)
                return BadRequest("The given application id was invalid");

            if (clerkId == null || clerkId == Guid.Empty)
                return BadRequest("The given clerk id was invalid");

            var command = new AssignClerkCommand(applicationId.Value, clerkId.Value);
            await _commandDispatcher.Execute(command);

            return Ok("Clerk with id " + clerkId + " was assigned application " + applicationId);
        }
    }
}