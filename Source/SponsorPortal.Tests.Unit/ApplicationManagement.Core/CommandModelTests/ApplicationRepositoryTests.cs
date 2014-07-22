using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.CommandModel;
using SponsorPortal.ApplicationManagement.Events;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.CommandModelTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ApplicationRepositoryTests
    {
        [Test]
        public async void GetsApplicationFormFromEventPersistance()
        {
            const AggregateRoot aggregateRootId = AggregateRoot.ApplicationForm;
            var eventPersistance = new Mock<IEventPersistance>();
            var storedEvents = new[]{ new CreatedNewApplicationFormEventBuilder().Build(), new CreatedNewApplicationFormEventBuilder().Build() }.ToImmutableList();
            var applicationId = storedEvents.First().EntityId;
            eventPersistance.Setup(ctx => ctx.ReadAllEvents<CreatedNewApplicationFormEvent>())
                            .Returns(() => Task.FromResult(storedEvents));

            var repository = new ApplicationFormRepository(eventPersistance.Object);

            var result = await repository.GetApplicationForm(applicationId);

            Assert.NotNull(result);
            Assert.AreEqual(applicationId, result.Id);
        }
    }
}
