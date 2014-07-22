using System;
using System.Collections.Immutable;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.QueryModel.ApplicationFormAggregate;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.QueryModelTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ApplicationFormTests
    {
        private static readonly Guid Id = Guid.NewGuid();
        private const string Organization = "organization";
        private const string Email = "email@email.com";
        private const string Title = "title";
        private const double Amount = 123;
        private const string Text = "text";
        private const ApplicationStatus Status = ApplicationStatus.NotProcessed;
        private static readonly DateTime CreatedTimestamp = DateTime.Now;
        private static readonly DateTime UpdatedTimestamp = DateTime.Now;
        private const string Clerk = "Mr. Employee";
        private static readonly ImmutableList<HistoryEntry> History = ImmutableList<HistoryEntry>.Empty;
        
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OrganizationCannotBeNull()
        {
            new ApplicationForm(Id, null, Email, Amount, Title, Text, Status, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OrganizationCannotBeEmpty()
        {
            new ApplicationForm(Id, String.Empty, Email, Amount, Title, Text, Status, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailCannotBeNull()
        {
            new ApplicationForm(Id, Organization, null, Amount, Title, Text, Status, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailCannotBeEmpty()
        {
            new ApplicationForm(Id, Organization, String.Empty, Amount, Title, Text, Status, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TitleCannotBeNull()
        {
            new ApplicationForm(Id, Organization, Email, Amount, null, Text, Status, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TitleCannotBeEmpty()
        {
            new ApplicationForm(Id, Organization, Email, Amount, String.Empty, Text, Status, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextCannotBeNull()
        {
            new ApplicationForm(Id, Organization, Email, Amount, Title, null, Status, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextCannotBeEmpty()
        {
            new ApplicationForm(Id, null, Email, Amount, Title, String.Empty, Status, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AmountCannotBeZero()
        {
            new ApplicationForm(Id, Organization, Email, 0, Title, Text, Status, CreatedTimestamp);
            new ApplicationForm(Id, Organization, Email, 0.0, Title, Text, Status, CreatedTimestamp);
        }

        [Test]
        public void WhenClerkNameIsNotGiven_IsNullAndNotEmptyString()
        {
            var application = new ApplicationForm(Id, Organization, Email, Amount, Title, Text, Status, CreatedTimestamp);
            Assert.IsNull(application.ClerkName);
            Assert.AreNotEqual(String.Empty, application.ClerkName);
        }

        [Test]
        public void WhenClerkNameIsGivenAsNull_IsNullAndNotEmptyString()
        {
            var updatedTimestamp = DateTime.Now;
            var application = new ApplicationForm(Id, Organization, Email, Amount, Title, Text, Status, CreatedTimestamp, updatedTimestamp, null, History);
            Assert.IsNull(application.ClerkName);
            Assert.AreNotEqual(String.Empty, application.ClerkName);
        }

        [Test]
        public void WhenClerkNameIsGivenAsEmptyString_IsNullAndNotEmptyString()
        {
            var updatedTimestamp = DateTime.Now;
            var application = new ApplicationForm(Id, Organization, Email, Amount, Title, Text, Status, CreatedTimestamp, updatedTimestamp, String.Empty, History);
            Assert.IsNull(application.ClerkName);
            Assert.AreNotEqual(String.Empty, application.ClerkName);
        }

        [Test]
        public void WhenUpdateTimestampIsNotGiven_CreatedTimestampIsUsedAsUpdatedTimestamp()
        {
            var application = new ApplicationForm(Id, Organization, Email, Amount, Title, Text, Status, CreatedTimestamp);
            Assert.AreEqual(application.CreatedTimestamp, application.UpdatedTimestamp);
        }

        [Test]
        public void WhenHistoryIsNotGiven_IsEmptyImmutableList()
        {
            var application = new ApplicationForm(Id, Organization, Email, Amount, Title, Text, Status, CreatedTimestamp);
            Assert.AreEqual(ImmutableList<HistoryEntry>.Empty, application.History);
        }

        [Test]
        public void WhenHistoryIsGivenAsNull_IsEmptyImmutableList()
        {
            var application = new ApplicationForm(Id, Organization, Email, Amount, Title, Text, Status, CreatedTimestamp, UpdatedTimestamp, Clerk, null);
            Assert.AreEqual(ImmutableList<HistoryEntry>.Empty, application.History);
        }
    }
}
