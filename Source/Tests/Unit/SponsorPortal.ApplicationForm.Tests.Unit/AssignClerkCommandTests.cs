using System;
using NUnit.Framework;

namespace SponsorPortal.ApplicationForm.Tests.Unit
{
    [TestFixture]
    public class AssignClerkCommandTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClerkIdCannotBeNull()
        {
            new AssignClerkCommand(Guid.NewGuid(), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClerkIdCannotBeEmpty()
        {
            new AssignClerkCommand(Guid.NewGuid(), String.Empty);
        }
    }
}
