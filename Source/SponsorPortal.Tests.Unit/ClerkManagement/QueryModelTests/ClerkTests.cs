using System;
using NUnit.Framework;
using SponsorPortal.ClerkManagement.QueryModel;
using SponsorPortal.ClerkManagement.QueryModel.ClerkAggregate;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ClerkManagement.QueryModelTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ClerkTests
    {
        private static readonly Guid Id = Guid.NewGuid();
        private const string Name = "Mr.Clerk";
        private const string Description = "Is a clerk";
        private static readonly DateTime CreatedTimestamp = DateTime.Now;

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameCannotBeNull()
        {
            new Clerk(Id, null, Description, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameCannotBeEmpty()
        {
            new Clerk(Id, String.Empty, Description, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DescriptionCannotBeNull()
        {
            new Clerk(Id, Name, null, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DescriptionCannotBeEmpty()
        {
            new Clerk(Id, Name, String.Empty, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IdCannotBeEmptyGuid()
        {
            new Clerk(Guid.Empty, Name, Description, CreatedTimestamp);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CreatedTimestampCannotBeDateTimeMinOrMax()
        {
            new Clerk(Id, Name, Description, DateTime.MinValue);
            new Clerk(Id, Name, Description, DateTime.MaxValue);
        }
    }
}
