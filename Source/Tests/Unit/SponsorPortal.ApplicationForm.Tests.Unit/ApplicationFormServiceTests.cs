﻿using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SponsorPortal.ApplicationForm.Contracts;
using SponsorPortal.TestDataBuilders;

namespace SponsorPortal.ApplicationForm.Tests.Unit
{
    [TestFixture]
    public class ApplicationFormServiceTests
    {
        private Mock<IApplicationFormRespository> _applicationFormRepository;

        [SetUp]
        public void Setup()
        {
            _applicationFormRepository = new Mock<IApplicationFormRespository>();
        }

        [Test]
        public async void HandlesCreateNewApplicationFormCommand_CreatesEventForNewApplicationForm()
        {
            var service = new ApplicationFormService(_applicationFormRepository.Object);
            var applicationForm = new ApplicationFormDTOBuilder().Build();
            var command = new CreateNewApplicationFormCommand(applicationForm);
            
            await service.Handle(command);
            
            _applicationFormRepository.Verify(repo => repo.Store(It.Is<CreatedNewApplicationFormEvent>(evnt => HasSameContent(applicationForm, evnt))));
        }

        [Test]
        public async void HandlesAssignClerkCommand_WhenApplicationFormExists_CreatesEventForClerkAssignedToApplication()
        {
            const string clerkId = "Mr. Clerk";
            var applicationForm = new ApplicationFormBuilder().Build();
            var applicationId = applicationForm.Id;
            _applicationFormRepository.Setup(ctx => ctx.GetApplicationForm(applicationId)).Returns(() => Task.FromResult(applicationForm));
            var service = new ApplicationFormService(_applicationFormRepository.Object);
            var command = new AssignClerkCommand(applicationId, clerkId);

            await service.Handle(command);

            _applicationFormRepository.Verify(repo => repo.GetApplicationForm(applicationId));
            _applicationFormRepository.Verify(repo => repo.Store(It.Is<ClerkAssignedToApplicationFormEvent>(evnt => evnt.ApplicationFormId == applicationId && evnt.ClerkId == clerkId)));
        }

        [Test]
        [ExpectedException(typeof(ApplicationFormNotFoundException))]
        public async void HandlesAssignClerkCommand_WhenApplicationFormDoesNotExist_CreatesEventForClerkAssignedToApplication()
        {
            const string clerkId = "Mr. Clerk";
            var applicationForm = new ApplicationFormBuilder().Build();
            var applicationId = applicationForm.Id;
            _applicationFormRepository.Setup(ctx => ctx.GetApplicationForm(applicationId)).Returns(() => Task.FromResult<ApplicationForm>(null));
            var service = new ApplicationFormService(_applicationFormRepository.Object);
            var command = new AssignClerkCommand(applicationId, clerkId);

            await service.Handle(command);
        }

        private bool HasSameContent(ApplicationFormDTO expected, CreatedNewApplicationFormEvent actual)
        {
            return expected.Organization == actual.Organization
                   && expected.Email == actual.Email
                   && expected.Amount == actual.Amount
                   && expected.Text == actual.Text
                   && expected.Title == actual.Title;
        }
    }

}
