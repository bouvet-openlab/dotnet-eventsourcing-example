using System.Linq;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.CommandModel;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.ApplicationManagement.Core.QueryModel;
using SponsorPortal.ApplicationManagement.Web;
using SponsorPortal.EventStore;
using SponsorPortal.Infrastructure;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.ApplicationForm.Tests.Integration
{
    [TestFixture]
    public class CreatingNewApplicationFormTests
    {
        [Test]
        public async void WhenGivingNewApplicationFormToCommandApi_RetrievesExpectedApplicationFormFromQueryApi()
        {
            var container = new UnityContainer();
            
            var eventstore = new EventStoreEventPersistance();
            eventstore.Initialize();

            var repository = new ApplicationFormRepository(eventstore);
            var commandHandler = new ApplicationFormService(repository);
            container.RegisterInstance(typeof(ICommandHandler<CreateNewApplicationFormCommand>), commandHandler, new ContainerControlledLifetimeManager());
            IoC.RegisterContainer(container);
            
            var commandDispatcher = new CommandDispatcher();
            var receptionController = new ReceptionController(commandDispatcher);

            var applicationFormProjection = new ApplicationFormProjection(eventstore);
            await applicationFormProjection.SubscribeToEvents();
            var applicationFormController = new ApplicationFormController(applicationFormProjection);

            var dto = new ApplicationFormDTOBuilder().Build();
            await receptionController.SaveNew(dto);

            await Async.PauseToAllowRunningAsyncTasksToCompleteBeforeContinuing();

            var applicationForms = await applicationFormController.GetAll();

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
            var container = new UnityContainer();

            var eventstore = new EventStoreEventPersistance();
            eventstore.Initialize();

            var repository = new ApplicationFormRepository(eventstore);
            var commandHandler = new ApplicationFormService(repository);
            container.RegisterInstance(typeof(ICommandHandler<CreateNewApplicationFormCommand>), commandHandler, new ContainerControlledLifetimeManager());
            IoC.RegisterContainer(container);

            var commandDispatcher = new CommandDispatcher();
            var receptionController = new ReceptionController(commandDispatcher);

            var applicationFormProjection = new ApplicationFormProjection(eventstore);
            await applicationFormProjection.GetAllExistingEventsOfInterest();
            await applicationFormProjection.SubscribeToEvents();

            await Async.PauseToAllowRunningAsyncTasksToCompleteBeforeContinuing(1000);

            var applicationFormController = new ApplicationFormController(applicationFormProjection);
            var applicationFormsBefore = await applicationFormController.GetAll();
            var countBefore = applicationFormsBefore.Count;

            var dto1 = new ApplicationFormDTOBuilder().Build();
            var dto2 = new ApplicationFormDTOBuilder().Build();
            var dto3 = new ApplicationFormDTOBuilder().Build();
            var dto4 = new ApplicationFormDTOBuilder().Build();
            var dto5 = new ApplicationFormDTOBuilder().Build();
            await receptionController.SaveNew(dto1);
            await receptionController.SaveNew(dto2);
            await receptionController.SaveNew(dto3);
            await receptionController.SaveNew(dto4);
            await receptionController.SaveNew(dto5);

            await Async.PauseToAllowRunningAsyncTasksToCompleteBeforeContinuing();

            var applicationForms = await applicationFormController.GetAll();
            var countAfter = applicationForms.Count;

            Assert.AreEqual(5, countAfter - countBefore);
        }

        [Test]
        public async void WhenProjectionSubscribesToEventsWithEventsAlreadyInEventStore_ProjectionReceivesOnlyNewEvents()
        {
            var container = new UnityContainer();

            var eventstore = new EventStoreEventPersistance();
            eventstore.Initialize();

            var repository = new ApplicationFormRepository(eventstore);
            var commandHandler = new ApplicationFormService(repository);
            container.RegisterInstance(typeof(ICommandHandler<CreateNewApplicationFormCommand>), commandHandler, new ContainerControlledLifetimeManager());
            IoC.RegisterContainer(container);

            var commandDispatcher = new CommandDispatcher();
            var receptionController = new ReceptionController(commandDispatcher);

            var dto1 = new ApplicationFormDTOBuilder().Build();
            var dto2 = new ApplicationFormDTOBuilder().Build();
            var dto3 = new ApplicationFormDTOBuilder().Build();
            await receptionController.SaveNew(dto1);
            await receptionController.SaveNew(dto2);
            await receptionController.SaveNew(dto3);

            var applicationFormProjection = new ApplicationFormProjection(eventstore);
            await applicationFormProjection.SubscribeToEvents();
            var applicationFormController = new ApplicationFormController(applicationFormProjection);

            var dto4 = new ApplicationFormDTOBuilder().Build();
            var dto5 = new ApplicationFormDTOBuilder().Build();
            await receptionController.SaveNew(dto4);
            await receptionController.SaveNew(dto5);

            await Async.PauseToAllowRunningAsyncTasksToCompleteBeforeContinuing();

            var applicationForms = await applicationFormController.GetAll();

            Assert.IsTrue(applicationForms.Count == 2);
        }
    }
}
