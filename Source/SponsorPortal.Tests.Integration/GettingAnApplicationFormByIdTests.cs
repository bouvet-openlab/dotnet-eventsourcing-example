using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.QueryModel;
using SponsorPortal.ApplicationManagement.Web;
using SponsorPortal.EventStore;
using SponsorPortal.Infrastructure;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Integration
{
    [TestFixture]
    [Category(TestCategory.IntegrationTests)]
    public class GettingAnApplicationFormByIdTests
    {
        [Ignore]
        public void WhenGettingAnApplicationFormById_WithInvalidApplicationId_ReturnsBadRequest()
        {
            var eventstore = new EventStoreEventPersistance();
            eventstore.Initialize();
            var projection = new ApplicationFormProjection(eventstore);
            var commandDispatcher = new CommandDispatcher();
            var controller = new ApplicationFormController(projection, commandDispatcher);
            //controller.GetById()
        }
    }
}
