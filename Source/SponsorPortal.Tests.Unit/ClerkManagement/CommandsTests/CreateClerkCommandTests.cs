using System;
using NUnit.Framework;
using SponsorPortal.ClerkManagement.Commands;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ClerkManagement.CommandsTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class CreateClerkCommandTests
    {
        private const string Name = "Mr.Clerk";
        private const string Description = "Is a clerk";

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameCannotBeNull()
        {
            new CreateClerkCommand(null, Description);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameCannotBeEmpty()
        {
            new CreateClerkCommand(String.Empty, Description);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DescriptionCannotBeNull()
        {
            new CreateClerkCommand(Name, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DescriptionCannotBeEmpty()
        {
            new CreateClerkCommand(Name, String.Empty);
        }
    }
}
