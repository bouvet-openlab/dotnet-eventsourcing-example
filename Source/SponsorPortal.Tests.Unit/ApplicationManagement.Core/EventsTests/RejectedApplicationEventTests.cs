using System;
using NUnit.Framework;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.EventsTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class RejectedApplicationEventTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ApplicationIdCannotBeEmptyGuid()
        {
            var command = new RejectedApplicationEventBuilder().WithApplicationId(Guid.Empty).Build();
            Assert.AreNotEqual(Guid.Empty, command.ApplicationId);
        }

        [Test]
        public void WhenGivenValidApplicationId_ApplicationIdIsAssigned()
        {
            Guid id = Guid.NewGuid();
            var command = new RejectedApplicationEventBuilder().WithApplicationId(id).Build();
            Assert.AreEqual(id, command.ApplicationId);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ClerkIdCannotBeEmptyGuid()
        {
            var command = new RejectedApplicationEventBuilder().WithClerkId(Guid.Empty).Build();
            Assert.AreNotEqual(Guid.Empty, command.ClerkId);
        }

        [Test]
        public void WhenGivenValidClerk_ClerkIsAssigned()
        {
            Guid id = Guid.NewGuid();
            var command = new RejectedApplicationEventBuilder().WithClerkId(id).Build();
            Assert.AreEqual(id, command.ClerkId);
        }
    }
}