using System;
using System.Threading.Tasks;
using System.Web.Http;
using SponsorPortal.ApplicationManagement.Core.CommandModel;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Web
{
    public class ReceptionController : ApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public ReceptionController(ICommandDispatcher commandDispatcher)
        {
            if (commandDispatcher == null) throw new ArgumentNullException("commandDispatcher");
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        [Route("applicationform")]
        public async Task<IHttpActionResult> SaveNew([FromBody] ApplicationFormDTO applicationForm)
        {
            if (applicationForm == null)
                return BadRequest("The application form is invalid");

            var command = new CreateNewApplicationFormCommand(applicationForm);
            await _commandDispatcher.Execute(command);

            return Ok(String.Format((string) "Application form for \"{0}\" received", (object) applicationForm.Title));
        }
    }
}