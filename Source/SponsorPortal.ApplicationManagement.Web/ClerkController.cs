using System;
using System.Threading.Tasks;
using System.Web.Http;
using SponsorPortal.ClerkManagement.CommandModel.ValueObjects;
using SponsorPortal.ClerkManagement.Commands;
using SponsorPortal.ClerkManagement.QueryModel.Interfaces;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Web
{
    public class ClerkController : ApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IClerkProjection _clerkProjection;

        public ClerkController(ICommandDispatcher commandDispatcher, IClerkProjection clerkProjection)
        {
            if (commandDispatcher == null) throw new ArgumentNullException("commandDispatcher");
            if (clerkProjection == null) throw new ArgumentNullException("clerkProjection");
            _commandDispatcher = commandDispatcher;
            _clerkProjection = clerkProjection;
        }

        [HttpPost]
        [Route("clerks/add")]
        public async Task<IHttpActionResult> AddNew([FromBody] ClerkDTO clerk)
        {
            if (clerk == null)
                return BadRequest("The clerk object provided was invalid");

            var command = new CreateClerkCommand(clerk.Name, clerk.Description);
            await _commandDispatcher.Execute(command);

            return Ok("Clerk " + clerk.Name + " received and processed");
        }

        [HttpGet]
        [Route("clerks")]
        public IHttpActionResult GetAll()
        {
            return Ok(_clerkProjection.Clerks);
        }
    }
}