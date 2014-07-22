using System;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.CommandModel;
using SponsorPortal.ApplicationManagement.Core.CommandModel.ValueObjects;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.CommandModelTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ApplicationFormDTOTests
    {
        private const string Organization = "organization";
        private const string Email = "email@email.com";
        private const string Title = "title";
        private const double Amount = 123;
        private const string Text = "text";

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OrganizationCannotBeNull()
        {
            new ApplicationFormDTO(null, Email, Amount, Title, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OrganizationCannotBeEmpty()
        {
            new ApplicationFormDTO(String.Empty, Email, Amount, Title, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailCannotBeNull()
        {
            new ApplicationFormDTO(Organization, null, Amount, Title, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailCannotBeEmpty()
        {
            new ApplicationFormDTO(Organization, String.Empty, Amount, Title, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TitleCannotBeNull()
        {
            new ApplicationFormDTO(Organization, Email, Amount, null, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TitleCannotBeEmpty()
        {
            new ApplicationFormDTO(Organization, Email, Amount, String.Empty, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextCannotBeNull()
        {
            new ApplicationFormDTO(Organization, Email, Amount, Title, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextCannotBeEmpty()
        {
            new ApplicationFormDTO(Organization, Email, Amount, Title, String.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AmountCannotBeZero()
        {
            new ApplicationFormDTO(Organization, Email, 0, Title, Text);
            new ApplicationFormDTO(Organization, Email, 0.0, Title, Text);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException))]
        public void WhenGUIDIsNotGiven_NewGuidIsCreated()
        {
            var application = new ApplicationFormDTO(Organization, Email, 0, Title, Text);
            Assert.AreNotEqual(Guid.Empty, application.Id);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenGUIDIsGiven_IsSetAsID()
        {
            var guid = Guid.NewGuid();
            var application = new ApplicationFormDTO(guid, Organization, Email, 0, Title, Text);
            Assert.AreEqual(guid, application.Id);
        }
    }
}
