using System;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.Events;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.EventsTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ClerkAssignedToApplicationFormEventTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ClerkIdCannotBeEmpty()
        {
            new ClerkAssignedToApplicationFormEvent(Guid.NewGuid(), Guid.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ClerkIdCannotBeNull()
        {
            new ClerkAssignedToApplicationFormEvent(Guid.Empty, Guid.NewGuid());
        }
    }
}
