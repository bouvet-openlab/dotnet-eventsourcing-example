﻿using System.Linq;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.QueryModel.Interfaces;
using SponsorPortal.ApplicationManagement.Web;
using SponsorPortal.Infrastructure;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Integration
{
    [TestFixture]
    [Category(TestCategory.IntegrationTests)]
    public class CreatingNewApplicationFormTests : IntegrationTestContext
    {
        private IApplicationFormProjection _applicationFormProjection;
        private ApplicationFormController _applicationFormController;

        [SetUp]
        public void Setup()
        {
            ConfigureDefaultIoC();
            IoC.Resolve<IEventPersistance>().Initialize();
             _applicationFormProjection = IoC.Resolve<IApplicationFormProjection>();
            _applicationFormController = IoC.Resolve<ApplicationFormController>();
        }

        [Test]
        public async void WhenGivingNewApplicationFormToCommandApi_RetrievesExpectedApplicationFormFromQueryApi()
        {
            await _applicationFormProjection.SubscribeToEvents();
            
            var dto = new ApplicationFormDTOBuilder().Build();
            await _applicationFormController.SaveNew(dto);

            await Async.PauseToAllowRunningAsyncTasksToCompleteBeforeContinuing();

            var applicationForms = _applicationFormController.GetAll();

            var applicationForm = applicationForms.FirstOrDefault(app => app.Title == dto.Title);
            if (applicationForm != null)
            {
                Assert.AreEqual(dto.Title, applicationForm.Title);
                Assert.AreEqual(dto.Text, applicationForm.Text);
                Assert.AreEqual(dto.Organization, applicationForm.Organization);
                Assert.AreEqual(dto.Amount, applicationForm.Amount);
                Assert.AreEqual(dto.Email, applicationForm.Email);    
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public async void WhenGivingSeveralApplicationFormsToCommandApi_RetrievesExpectedAmountOfApplicationsFromQueryApi()
        {
            await _applicationFormProjection.GetAllExistingEventsOfInterest();
            await _applicationFormProjection.SubscribeToEvents();

            await Async.PauseToAllowRunningAsyncTasksToCompleteBeforeContinuing(1000);

            var applicationFormsBefore = _applicationFormController.GetAll();
            var countBefore = applicationFormsBefore.Count;

            var dto1 = new ApplicationFormDTOBuilder().Build();
            var dto2 = new ApplicationFormDTOBuilder().Build();
            var dto3 = new ApplicationFormDTOBuilder().Build();
            var dto4 = new ApplicationFormDTOBuilder().Build();
            var dto5 = new ApplicationFormDTOBuilder().Build();
            await _applicationFormController.SaveNew(dto1);
            await _applicationFormController.SaveNew(dto2);
            await _applicationFormController.SaveNew(dto3);
            await _applicationFormController.SaveNew(dto4);
            await _applicationFormController.SaveNew(dto5);

            await Async.PauseToAllowRunningAsyncTasksToCompleteBeforeContinuing();

            var applicationForms = _applicationFormController.GetAll();
            var countAfter = applicationForms.Count;

            Assert.AreEqual(5, countAfter - countBefore);
        }

        [Test]
        public async void WhenProjectionSubscribesToEventsWithEventsAlreadyInEventStore_ProjectionReceivesOnlyNewEvents()
        {
            var dto1 = new ApplicationFormDTOBuilder().Build();
            var dto2 = new ApplicationFormDTOBuilder().Build();
            var dto3 = new ApplicationFormDTOBuilder().Build();
            await _applicationFormController.SaveNew(dto1);
            await _applicationFormController.SaveNew(dto2);
            await _applicationFormController.SaveNew(dto3);

            await _applicationFormProjection.SubscribeToEvents();

            var dto4 = new ApplicationFormDTOBuilder().Build();
            var dto5 = new ApplicationFormDTOBuilder().Build();
            await _applicationFormController.SaveNew(dto4);
            await _applicationFormController.SaveNew(dto5);

            await Async.PauseToAllowRunningAsyncTasksToCompleteBeforeContinuing();

            var applicationForms = _applicationFormController.GetAll();

            Assert.IsTrue(applicationForms.Count == 2);
        }
    }
}
