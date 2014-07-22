using System;
using NUnit.Framework;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.EventsTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class GrantedApplicationEventTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ApplicationIdCannotBeEmptyGuid()
        {
            var command = new GrantedApplicationEventBuilder().WithApplicationId(Guid.Empty).Build();
            Assert.AreNotEqual(Guid.Empty, command.ApplicationId);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AmountCannotBeZero()
        {
            new GrantedApplicationEventBuilder().WithAmount(0.0).Build();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AmountCannotBeNegativeNumber()
        {
            new GrantedApplicationEventBuilder().WithAmount(-1.0).Build();
        }

        [Test]
        public void WhenGivenValidApplicationId_ApplicationIdIsSet()
        {
            var id = Guid.NewGuid();
            var command = new GrantedApplicationEventBuilder().WithApplicationId(id).Build();
            Assert.AreEqual(id, command.ApplicationId);
        }

        [Test]
        public void WhenGivenValidAmount_AmountIsSet()
        {
            const double amount = 123.45;
            var command = new GrantedApplicationEventBuilder().WithAmount(amount).Build();
            Assert.AreEqual(amount, command.Amount);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ClerkIdCannotBeEmptyGuid()
        {
            new GrantedApplicationEventBuilder().WithClerkId(Guid.Empty).Build();
        }

        [Test]
        public void WhenGivenValidClerkId_ClerkIdIsSet()
        {
            var clerkId = Guid.NewGuid();
            var command = new GrantedApplicationEventBuilder().WithClerkId(clerkId).Build();
            Assert.AreEqual(clerkId, command.ClerkId);

        }
    }
}