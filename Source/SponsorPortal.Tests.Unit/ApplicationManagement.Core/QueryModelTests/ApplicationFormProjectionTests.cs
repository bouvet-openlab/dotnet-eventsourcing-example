﻿using NUnit.Framework;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.QueryModelTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ApplicationFormProjectionTests
    {
        /*
        [Test]
        public void SubscribesToEventForNewApplicationForm()
        {
            var eventStore = new Mock<IEventStore>();
            var projection = new ApplicationFormProjection(eventStore.Object);
            
            projection.SubscribeToEvents();

            eventStore.Verify(store => store.Subscribe(It.IsAny<Action<CreatedNewApplicationFormEvent>>()));
        }

        [Test]
        public async void WhenReceivsEventForNewApplicationForm_AddsApplicationFormToListOfApplicationForms()
        {
            var evnt = new CreatedNewApplicationFormEventBuilder().Build();
            var eventPersistance = new Mock<IEventPersistance>();
            var eventStore = new SponsorPortalEventStore(eventPersistance.Object);
            var projection = new ApplicationFormProjection(eventStore);

            projection.SubscribeToEvents();

            var applicationFormsBeforeEvent = projection.ApplicationForms;

            await eventStore.Tell(evnt);

            var applicationFormsAfterEvent = projection.ApplicationForms;

            Assert.AreEqual(0, applicationFormsBeforeEvent.Count);
            Assert.AreEqual(1, applicationFormsAfterEvent.Count);
        }
        */
    }
}
