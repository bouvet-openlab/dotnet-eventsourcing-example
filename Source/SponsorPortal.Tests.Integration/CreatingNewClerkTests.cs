using System.Collections.Immutable;
using System.Linq;
using System.Web.Http.Results;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Web;
using SponsorPortal.ClerkManagement.QueryModel.Interfaces;
using SponsorPortal.Infrastructure;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;
using Clerk = SponsorPortal.ClerkManagement.QueryModel.ClerkAggregate.Clerk;

namespace SponsorPortal.Tests.Integration
{
    [TestFixture]
    [Category(TestCategory.IntegrationTests)]
    public class CreatingNewClerkTests : IntegrationTestContext
    {
        private IClerkProjection _clerkProjection;
        private ClerkController _clerkController;

        [SetUp]
        public void Setup()
        {
            ConfigureDefaultIoC();
            IoC.Resolve<IEventPersistance>().Initialize();
            _clerkProjection = IoC.Resolve<IClerkProjection>();
            _clerkController = IoC.Resolve<ClerkController>();
        }

        [Test]
        public async void WhenSubmittingNewClerk_ExpectedClerkIsRetrievableFromProjection()
        {
            await _clerkProjection.Initialize();

            var clerksBeforeInsert = _clerkController.GetAll() as OkNegotiatedContentResult<ImmutableList<Clerk>>;

            var dto = new ClerkDTOBuilder().Build();
            await _clerkController.AddNew(dto);

            await Async.PauseToAllowRunningAsyncTasksToCompleteBeforeContinuing();

            var clerksAfterInsert = _clerkController.GetAll() as OkNegotiatedContentResult<ImmutableList<Clerk>>;

            if (clerksBeforeInsert == null || clerksAfterInsert == null)
                Assert.Fail("Could not get clerks as expected");

            Assert.AreEqual(1, clerksAfterInsert.Content.Count - clerksBeforeInsert.Content.Count);
            
            var lastClerkAdded = clerksAfterInsert.Content.OrderByDescending(clerk => clerk.CreatedTimestamp).First();
            Assert.AreEqual(dto.Name, lastClerkAdded.Name);
            Assert.AreEqual(dto.Description, lastClerkAdded.Description);
        }
    }
}
