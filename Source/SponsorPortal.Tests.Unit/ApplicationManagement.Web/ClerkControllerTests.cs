using System.Collections.Immutable;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using SponsorPortal.ClerkManagement.Commands;
using SponsorPortal.ClerkManagement.QueryModel.ClerkAggregate;
using SponsorPortal.ClerkManagement.QueryModel.Interfaces;
using SponsorPortal.Infrastructure;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;
using SponsorPortal.Web;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Web
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ClerkControllerTests
    {
        private Mock<ICommandDispatcher> _commandDispatcher;
        private Mock<IClerkProjection> _clerkProjection;
        private ClerkController _clerkController;

        [SetUp]
        public void Setup()
        {
            _commandDispatcher = new Mock<ICommandDispatcher>();
            _clerkProjection = new Mock<IClerkProjection>();
            _clerkController = new ClerkController(_commandDispatcher.Object, _clerkProjection.Object);
        }

        [Test]
        public async void WhenCreatingClerk_WithNoClerk_ReturnsBadRequest()
        {
            var response = await _clerkController.AddNew(null) as BadRequestErrorMessageResult;
            Assert.NotNull(response);
        }

        [Test]
        public async void WhenCreatingClerk_WithValidClerk_SendsCreateClerkCommand()
        {
            var clerk = new ClerkDTOBuilder().Build();
            await _clerkController.AddNew(clerk);
            _commandDispatcher.Verify(cmdDis => cmdDis.Execute(It.Is<CreateClerkCommand>(cmd => cmd.Name == clerk.Name && cmd.Description == clerk.Description)));
        }

        [Test]
        public async void WhenCreatingClerk_WithValidClerk_ReturnsOk()
        {
            var clerk = new ClerkDTOBuilder().Build();
            var response = await _clerkController.AddNew(clerk) as OkNegotiatedContentResult<string>;
            Assert.NotNull(response);
        }

        [Test]
        public void WhenRetrievingAllClerks_AsksProjectionForClerks()
        {
            _clerkController.GetAll();
            _clerkProjection.Verify(proj => proj.Clerks);
        }

        [Test]
        public void WhenRetrievingAllClerks_ReturnsOk()
        {
            var response = _clerkController.GetAll() as OkNegotiatedContentResult<ImmutableList<Clerk>>;
            Assert.NotNull(response);
        }
    }
}
