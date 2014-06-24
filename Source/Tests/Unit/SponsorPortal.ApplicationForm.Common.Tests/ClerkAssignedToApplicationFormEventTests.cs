using System;
using NUnit.Framework;
using SponsorPortal.ApplicationForm.Contracts;

namespace SponsorPortal.ApplicationForm.Common.Tests
{
    [TestFixture]
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
