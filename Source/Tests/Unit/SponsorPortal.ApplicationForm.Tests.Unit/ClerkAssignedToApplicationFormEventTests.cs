using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SponsorPortal.ApplicationForm.Tests.Unit
{
    [TestFixture]
    public class ClerkAssignedToApplicationFormEventTests
    {
        private const string ClerkId = "clerk";
        private static readonly Guid ApplicationFormId = Guid.NewGuid();
        private static readonly ApplicationForm AggregateRoot = new ApplicationForm();

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AggregateRootCannotBeNull()
        {
            new ClerkAssignedToApplicationFormEvent(null, ApplicationFormId, ClerkId);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClerkIdCannotBeNull()
        {
            new ClerkAssignedToApplicationFormEvent(AggregateRoot, ApplicationFormId, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClerkIdCannotBeEmpty()
        {
            new ClerkAssignedToApplicationFormEvent(AggregateRoot, ApplicationFormId, String.Empty);
        }
    }
}
