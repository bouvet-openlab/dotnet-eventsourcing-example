using System;
using NUnit.Framework;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.CommandsTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class RejectApplicationCommandTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ApplicationIdCannotBeEmptyGuid()
        {
            var command = new RejectApplicationCommandBuilder().WithApplicationId(Guid.Empty).Build();
            Assert.AreNotEqual(Guid.Empty, command.ApplicationId);
        }

        [Test]
        public void WhenGivenValidApplicationId_ApplicationIdIsAssigned()
        {
            Guid id = Guid.NewGuid();
            var command = new RejectApplicationCommandBuilder().WithApplicationId(id).Build();
            Assert.AreEqual(id, command.ApplicationId);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ClerkIdCannotBeEmptyGuid()
        {
            var command = new RejectApplicationCommandBuilder().WithClerkId(Guid.Empty).Build();
            Assert.AreNotEqual(Guid.Empty, command.ClerkId);
        }

        [Test]
        public void WhenGivenValidClerk_ClerkIsAssigned()
        {
            Guid id = Guid.NewGuid();
            var command = new RejectApplicationCommandBuilder().WithClerkId(id).Build();
            Assert.AreEqual(id, command.ClerkId);
        }
    }
}