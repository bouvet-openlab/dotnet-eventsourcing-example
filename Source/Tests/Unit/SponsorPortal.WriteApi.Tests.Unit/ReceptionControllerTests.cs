using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using SponsorPortal.ApplicationForm;
using SponsorPortal.Infrastructure;
using Moq;

namespace SponsorPortal.WriteApi.Tests.Unit
{
    [TestFixture]
    public class ReceptionControllerTests
    {
        private Mock<ICommandDispatcher> _commandDispatcher;

        [SetUp]
        public void Setup()
        {
            _commandDispatcher = new Mock<ICommandDispatcher>();
        }

        [Test]
        public void WhenSavingNewApplicationForm_ApplicationFormIsNull_ReturnsStatusCode400BadRequest()
        {
            var controller = new ReceptionController(_commandDispatcher.Object);

            var response = controller.SaveNew(null) as BadRequestErrorMessageResult;

            Assert.NotNull(response);
        }

        [Test]
        public void WhenSavingNewApplicationForm_ApplicationFormIsNotNull_SendsCreateNewApplicationCommand()
        {
            var applicationForm = new ApplicationFormDTO("organization", "mail@mail.com", 123, "title", "text");
            var controller = new ReceptionController(_commandDispatcher.Object);

            controller.SaveNew(applicationForm);

            _commandDispatcher.Verify(cmdDisp => cmdDisp.Execute(It.IsAny<CreateNewApplicationFormCommand>()));
        }

        [Test]
        public void WhenSavingNewApplicationForm_ApplicationFormIsNotNull_ReturnsStatusCode200Ok()
        {
            var applicationForm = new ApplicationFormDTO("organization", "mail@mail.com", 123, "title", "text");
            var controller = new ReceptionController(_commandDispatcher.Object);

            var response = controller.SaveNew(applicationForm) as OkNegotiatedContentResult<string>;

            Assert.NotNull(response);
        }
    }
}
