using System;
using NUnit.Framework;
using SponsorPortal.ClerkManagement.Events;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ClerkManagement.EventsTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class CreatedClerkEventTests
    {
        private const string Name = "Mr.Clerk";
        private const string Description = "Is a clerk";

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameCannotBeNull()
        {
            new CreatedClerkEvent(null, Description);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameCannotBeEmpty()
        {
            new CreatedClerkEvent(String.Empty, Description);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DescriptionCannotBeNull()
        {
            new CreatedClerkEvent(Name, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DescriptionCannotBeEmpty()
        {
            new CreatedClerkEvent(Name, String.Empty);
        }

        [Test]
        public void IsAssignedNewIdWhenCreated()
        {
            var clerkEvent = new CreatedClerkEvent(Name, Description);
            Assert.AreNotEqual(Guid.Empty, clerkEvent.EntityId);
        }

        [Test]
        public void IsAssignedCreatedTimestampWhenCreated()
        {
            var clerkEvent = new CreatedClerkEvent(Name, Description);
            Assert.AreNotEqual(DateTime.MinValue, clerkEvent.CreatedTimestamp);
            Assert.AreNotEqual(DateTime.MaxValue, clerkEvent.CreatedTimestamp);
        }
    }
}
