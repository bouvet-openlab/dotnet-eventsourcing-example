using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Moq;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.ApplicationManagement.Core.QueryModel;
using SponsorPortal.ApplicationManagement.Core.QueryModel.ApplicationFormAggregate;
using SponsorPortal.ApplicationManagement.Core.QueryModel.Interfaces;
using SponsorPortal.Infrastructure;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;
using SponsorPortal.Web;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Web
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ApplicationFormControllerTests
    {
        private Mock<ICommandDispatcher> _commandDispatcher;
        private Mock<IApplicationFormProjection> _projection;
        private ApplicationFormController _controller;

        [SetUp]
        public void Setup()
        {
            _commandDispatcher = new Mock<ICommandDispatcher>();
            _projection = new Mock<IApplicationFormProjection>();
            _controller = new ApplicationFormController(_projection.Object, _commandDispatcher.Object);
        }

        [Test]
        public async void WhenSavingNewApplicationForm_ApplicationFormIsNull_ReturnsStatusCode400BadRequest()
        {
            var response = await _controller.SaveNew(null) as BadRequestErrorMessageResult;

            Assert.NotNull(response);
        }

        [Test]
        public async void WhenSavingNewApplicationForm_ApplicationFormIsNotNull_SendsCreateNewApplicationCommand()
        {
            var applicationForm = new ApplicationFormDTOBuilder().Build();
  
            await _controller.SaveNew(applicationForm);

            _commandDispatcher.Verify(cmdDisp => cmdDisp.Execute(It.IsAny<CreateNewApplicationFormCommand>()));
        }

        [Test]
        public async void WhenSavingNewApplicationForm_ApplicationFormIsNotNull_ReturnsStatusCode200Ok()
        {
            var applicationForm = new ApplicationFormDTOBuilder().Build();

            var response = await _controller.SaveNew(applicationForm) as OkNegotiatedContentResult<string>;

            Assert.NotNull(response);
        }

        [Test]
        public void WhenGettingAnApplicationById_WithEmptyGuid_ReturnsBadRequest()
        {
            var emptyGuid = Guid.Empty;

            var response = _controller.GetById(emptyGuid) as BadRequestErrorMessageResult;

            Assert.NotNull(response);
        }


        [Test]
        public void WhenGettingAnApplicationById_WithNullAsApplicationId_ReturnsBadRequest()
        {
            var response = _controller.GetById(null) as BadRequestErrorMessageResult;
            Assert.NotNull(response);
        }

        [Test]
        public void WhenGettingAnApplicationById_WithValidGuid_AsksProjectionForApplicationWithId()
        {
            _projection.Setup(ctx => ctx.ApplicationForms).Returns(GetFakeApplicationForms());
            var controller = new ApplicationFormController(_projection.Object, _commandDispatcher.Object);
            controller.GetById(Guid.NewGuid());
            _projection.Verify(proj => proj.ApplicationForms);
        }

        [Test]
        public void WhenGettingAnApplicationById_WithValidGuid_ReturnsOkResult()
        {
            var id = Guid.NewGuid();
            _projection.Setup(ctx => ctx.ApplicationForms).Returns(GetFakeApplicationForms());
            var controller = new ApplicationFormController(_projection.Object, _commandDispatcher.Object);
            var response = controller.GetById(id) as OkNegotiatedContentResult<ApplicationForm>;

            Assert.NotNull(response);
        }

        [Test]
        public async void WhenAssigningAClerkToAnApplication_WithEmptyGuid_ReturnsBadRequest()
        {
            var emptyGuid = Guid.Empty;
            var response = await _controller.AssignClerk(emptyGuid, emptyGuid) as BadRequestErrorMessageResult;
            Assert.NotNull(response);
        }

        [Test]
        public async void WhenAssigningAClerkToAnApplication_WithNullGuids_ReturnsBadRequest()
        {
            var response = await _controller.AssignClerk(null, null) as BadRequestErrorMessageResult;
            Assert.NotNull(response);
        }

        [Test]
        public async void WhenAssigningAClerkToAnApplication_WithValidGuids_SendsAssignClerkCommand()
        {
            var applicationId = Guid.NewGuid();
            var clerkId = Guid.NewGuid();
            
            await _controller.AssignClerk(applicationId, clerkId);
            _commandDispatcher.Verify(ctx => ctx.Execute(It.Is<AssignClerkCommand>(command => command.ApplicationFormId == applicationId && command.ClerkId == clerkId)));
        }

        [Test]
        public async void WhenAssigningAClerkToAnApplication_WithValidGuids_ReturnsOk()
        {
            var applicationId = Guid.NewGuid();
            var clerkId = Guid.NewGuid();

            var result = await _controller.AssignClerk(applicationId, clerkId) as OkNegotiatedContentResult<string>;
            Assert.NotNull(result);
        }

        private ImmutableList<ApplicationForm> GetFakeApplicationForms()
        {
            return new List<ApplicationForm>
            {
                new QueryApplicationFormBuilder().Build(),
                new QueryApplicationFormBuilder().Build(),
                new QueryApplicationFormBuilder().Build(),
                new QueryApplicationFormBuilder().Build(),
                new QueryApplicationFormBuilder().Build()
            }.ToImmutableList();
        } 
    }
}
