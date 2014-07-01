using System;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
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
