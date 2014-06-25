using System.Linq;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using SponsorPortal.ApplicationForm.Query;
using SponsorPortal.CommandApi;
using SponsorPortal.EventStore;
using SponsorPortal.Infrastructure;
using SponsorPortal.QueryApi;
using SponsorPortal.TestDataBuilders;

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

            await Task.Delay(100); // Allow the projection's event subscription callback to be invoked by the eventstore before trying to get applications

            var applicationForms = await applicationFormController.GetAll();
            
            Assert.AreEqual(1, applicationForms.Count);

            var applicationForm = applicationForms.Single();
            Assert.AreEqual(dto.Title, applicationForm.Title);
            Assert.AreEqual(dto.Text, applicationForm.Text);
            Assert.AreEqual(dto.Organization, applicationForm.Organization);
            Assert.AreEqual(dto.Amount, applicationForm.Amount);
            Assert.AreEqual(dto.Email, applicationForm.Email);
        }
    }
}
