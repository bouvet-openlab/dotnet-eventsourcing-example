using System;
using NUnit.Framework;
using SponsorPortal.ClerkManagement.CommandModel.ValueObjects;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ClerkManagement.ValueObjectsTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ClerkDTOTests
    {
        private const string Name = "Mr.Clerk";
        private const string Description = "Is a clerk";

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameCannotBeNull()
        {
            new ClerkDTO(null, Description);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameCannotBeEmpty()
        {
            new ClerkDTO(String.Empty, Description);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DescriptionCannotBeNull()
        {
            new ClerkDTO(Name, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DescriptionCannotBeEmpty()
        {
            new ClerkDTO(Name, String.Empty);
        }
    }
}
