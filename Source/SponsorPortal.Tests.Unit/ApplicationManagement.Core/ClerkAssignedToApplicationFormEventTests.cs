using System;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.Events;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ClerkAssignedToApplicationFormEventTests
    {
        private static readonly Guid ApplicationFormId = Guid.NewGuid();

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClerkIdCannotBeNull()
        {
            new ClerkAssignedToApplicationFormEvent(ApplicationFormId, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClerkIdCannotBeEmpty()
        {
            new ClerkAssignedToApplicationFormEvent(ApplicationFormId, String.Empty);
        }
    }
}
