using NUnit.Framework;
using SponsorPortal.ApplicationManagement.Core.Events;

namespace SponsorPortal.ApplicationManagement.Core.Tests.Unit.CommandModelTests
{
    [TestFixture]
    public class ApplicationFormTests
    {
        private const string Organization = "organization";
        private const string Email = "email@email.com";
        private const string Title = "title";
        private const double Amount = 123;
        private const string Text = "text";

        [Test]
        public void WhenCreatingNew_ReturnsExpectedEventAndEventHasSameDataAsIsGiven()
        {
            var evnt = ApplicationManagement.Core.CommandModel.ApplicationForm.CreateNew(Organization, Email, Amount, Title, Text);
            Assert.IsInstanceOf<CreatedNewApplicationFormEvent>(evnt);
            Assert.AreEqual(Organization, evnt.Organization);
            Assert.AreEqual(Email, evnt.Email);
            Assert.AreEqual(Amount, evnt.Amount);
            Assert.AreEqual(Title, evnt.Title);
            Assert.AreEqual(Text, evnt.Text);
        }

        [Test]
        public void WhenAssigningClerk_ReturnsExpectedEventAndHasExpectedApplicationIdAndClerkId()
        {
            const string clerkId = "Mr. Clerk";
            var application = new ApplicationManagement.Core.CommandModel.ApplicationForm(Organization, Email, Amount, Title, Text);
            var evnt = application.AssignClerk(clerkId);
            Assert.IsInstanceOf<ClerkAssignedToApplicationFormEvent>(evnt);
            Assert.AreEqual(clerkId, evnt.ClerkId);
            Assert.AreEqual(application.Id, evnt.ApplicationFormId);
        }
    }
}
