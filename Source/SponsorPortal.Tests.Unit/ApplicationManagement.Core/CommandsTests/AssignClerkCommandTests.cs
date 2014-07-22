using System;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.CommandsTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class AssignClerkCommandTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ApplicationIdCannotBeEmpty()
        {
            new AssignClerkCommand(Guid.Empty, Guid.NewGuid());
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ClerkIdCannotBeEmpty()
        {
            new AssignClerkCommand(Guid.NewGuid(), Guid.Empty);
        }
    }
}
