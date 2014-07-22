using System;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.CommandsTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class GrantApplicationCommandTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ApplicationIdCannotBeEmptyGuid()
        {
            var command = new GrantApplicationCommandBuilder().WithApplicationId(Guid.Empty).Build();
            Assert.AreNotEqual(Guid.Empty, command.ApplicationId);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AmountCannotBeZero()
        {
            new GrantApplicationCommandBuilder().WithAmount(0.0).Build();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AmountCannotBeNegativeNumber()
        {
            new GrantApplicationCommandBuilder().WithAmount(-1.0).Build();
        }

        [Test]
        public void WhenGivenValidApplicationId_ApplicationIdIsSet()
        {
            var id = Guid.NewGuid();
            var command = new GrantApplicationCommandBuilder().WithApplicationId(id).Build();
            Assert.AreEqual(id, command.ApplicationId);
        }

        [Test]
        public void WhenGivenValidAmount_AmountIsSet()
        {
            const double amount = 123.45;
            var command = new GrantApplicationCommandBuilder().WithAmount(amount).Build();
            Assert.AreEqual(amount, command.Amount);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ClerkIdCannotBeEmptyGuid()
        {
            new GrantApplicationCommandBuilder().WithClerkId(Guid.Empty).Build();
        }

        [Test]
        public void WhenGivenValidClerkId_ClerkIdIsSet()
        {
            var clerkId = Guid.NewGuid();
            var command = new GrantApplicationCommandBuilder().WithClerkId(clerkId).Build();
            Assert.AreEqual(clerkId, command.ClerkId);

        }
    }
}