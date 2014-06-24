using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SponsorPortal.ApplicationForm.Contracts;
using SponsorPortal.EventStore;
using SponsorPortal.Helpers;
using SponsorPortal.TestDataBuilders;

namespace SponsorPortal.ApplicationForm.Tests.Unit
{
    [TestFixture]
    public class ApplicationRepositoryTests
    {
        [Test]
        public async void GetsApplicationFormFromEventPersistance()
        {
            const AggregateRoots aggregateRootId = AggregateRoots.ApplicationForm;
            var eventPersistance = new Mock<IEventPersistance>();
            var storedEvents = new[]{ new CreatedNewApplicationFormEventBuilder().Build(), new CreatedNewApplicationFormEventBuilder().Build() }.ToImmutableList();
            var applicationId = storedEvents.First().EntityId;
            eventPersistance.Setup(ctx => ctx.ReadAllEvents<CreatedNewApplicationFormEvent>(aggregateRootId))
                            .Returns(() => Task.FromResult(storedEvents));

            var repository = new ApplicationFormRepository(eventPersistance.Object);

            var result = await repository.GetApplicationForm(applicationId);

            Assert.NotNull(result);
            Assert.AreEqual(applicationId, result.Id);
        }
    }
}
