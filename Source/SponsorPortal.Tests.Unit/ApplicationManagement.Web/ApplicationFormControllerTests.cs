using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.ApplicationManagement.Core.QueryModel;
using SponsorPortal.ApplicationManagement.Web;
using SponsorPortal.Infrastructure;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Web
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ApplicationFormControllerTests
    {
        private Mock<ICommandDispatcher> _commandDispatcher;
        private Mock<IApplicationFormProjection> _projection;

        [SetUp]
        public void Setup()
        {
            _commandDispatcher = new Mock<ICommandDispatcher>();
            _projection = new Mock<IApplicationFormProjection>();
        }

        [Test]
        public async void WhenSavingNewApplicationForm_ApplicationFormIsNull_ReturnsStatusCode400BadRequest()
        {
            var controller = new ApplicationFormController(_projection.Object, _commandDispatcher.Object);

            var response = await controller.SaveNew(null) as BadRequestErrorMessageResult;

            Assert.NotNull(response);
        }

        [Test]
        public async void WhenSavingNewApplicationForm_ApplicationFormIsNotNull_SendsCreateNewApplicationCommand()
        {
            var applicationForm = new ApplicationFormDTOBuilder().Build();
            var controller = new ApplicationFormController(_projection.Object, _commandDispatcher.Object);

            await controller.SaveNew(applicationForm);

            _commandDispatcher.Verify(cmdDisp => cmdDisp.Execute(It.IsAny<CreateNewApplicationFormCommand>()));
        }

        [Test]
        public async void WhenSavingNewApplicationForm_ApplicationFormIsNotNull_ReturnsStatusCode200Ok()
        {
            var applicationForm = new ApplicationFormDTOBuilder().Build();
            var controller = new ApplicationFormController(_projection.Object, _commandDispatcher.Object);

            var response = await controller.SaveNew(applicationForm) as OkNegotiatedContentResult<string>;

            Assert.NotNull(response);
        }
    }
}
