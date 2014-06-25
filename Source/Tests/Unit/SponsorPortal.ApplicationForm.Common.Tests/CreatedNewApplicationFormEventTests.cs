using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm.Common.Tests
{
    [TestFixture]
    public class CreatedNewApplicationFormEventTests
    {
        //private const string AggregateRootIdentifier = "ApplicationForm";
        private const AggregateRoots AggregateRootIdentifier = AggregateRoots.ApplicationForm;
        private const string Organization = "organization";
        private const string Email = "email@email.com";
        private const string Title = "title";
        private const double Amount = 123;
        private const string Text = "text";

        /*
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AggregateRootIdentifierCannotBeNull()
        {
            new CreatedNewApplicationFormEvent(null, Organization, Email, Amount, Title, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AggregateRootIdentifierCannotBeEmptyString()
        {
            new CreatedNewApplicationFormEvent(String.Empty, Organization, Email, Amount, Title, Text);
        }
        */

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OrganizationCannotBeNull()
        {
            new CreatedNewApplicationFormEvent(AggregateRootIdentifier, null, Email, Amount, Title, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OrganizationCannotBeEmpty()
        {
            new CreatedNewApplicationFormEvent(AggregateRootIdentifier, String.Empty, Email, Amount, Title, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailCannotBeNull()
        {
            new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, null, Amount, Title, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailCannotBeEmpty()
        {
            new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, String.Empty, Amount, Title, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TitleCannotBeNull()
        {
            new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, Email, Amount, null, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TitleCannotBeEmpty()
        {
            new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, Email, Amount, String.Empty, Text);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextCannotBeNull()
        {
            new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, Email, Amount, Title, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextCannotBeEmpty()
        {
            new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, Email, Amount, Title, String.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AmountCannotBeZero()
        {
            new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, Email, 0, Title, Text);
            new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, Email, 0.0, Title, Text);
        }

        [Test]
        public void ApplicationStatusIsAlwaysNotProcessed()
        {
            var evnt = new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, Email, Amount, Title, Text);
            Assert.AreEqual(ApplicationStatus.NotProcessed, evnt.Status);
        }

        [Test]
        public void IsAssignedNewGuid()
        {
            var evnt = new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, Email, Amount, Title, Text);
            Assert.AreNotEqual(Guid.Empty, evnt.EntityId);
        }

        [Test]
        public void IsAssignedCreatedTimestamp()
        {
            var now = DateTime.Now;
            var evnt = new CreatedNewApplicationFormEvent(AggregateRootIdentifier, Organization, Email, Amount, Title, Text);
            Assert.AreNotEqual(DateTime.MinValue, evnt.CreatedTimestamp);
            Assert.AreEqual(now.Date, evnt.CreatedTimestamp.Date);
            Assert.AreEqual(now.Hour, evnt.CreatedTimestamp.Hour);
        }
    }
}
