using System;
using NUnit.Framework;
using SponsorPortal.ApplicationManagement.QueryModel.ApplicationFormAggregate;
using SponsorPortal.TestDataBuilders;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ApplicationManagement.Core.QueryModelTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class HistoryEntryTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenTimestampIsDateTimeMinValue_ThrowsException()
        {
            new HistoryEntryBuilder().WithTimestamp(DateTime.MinValue).Build();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenTimestampIsDateTimeMaxValue_ThrowsException()
        {
            new HistoryEntryBuilder().WithTimestamp(DateTime.MaxValue).Build();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenUsingConstructorWithUserParamAndUserIsNull_ThrowsException()
        {
            new HistoryEntry(DateTime.Now, null, "Text");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenUsingConstructorWithUserParamAndUserIsEmptyString_ThrowsException()
        {
            new HistoryEntry(DateTime.Now, String.Empty, "Text");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextCannotBeNull()
        {
            new HistoryEntry(DateTime.Now, "User", null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TextCannotBeEmptyString()
        {
            new HistoryEntry(DateTime.Now, "User", String.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WithTextOnlyConstructor_TextCannotBeNull()
        {
            new HistoryEntry(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WithTextOnlyConstructor_TextCannotBeEmptyString()
        {
            new HistoryEntry(String.Empty);
        }

        [Test]
        public void WhenCreatedWithNoUser_SetsUserToSystemDefaultUser()
        {
            var entry = new HistoryEntry("text");
            Assert.AreEqual("SponsorPortal", entry.User);
        }

        [Test]
        public void WhenCreatedWithNoTimestamp_SetsTimestampToNow()
        {
            var now = DateTime.Now;
            var entry = new HistoryEntry("Some text...");
            Assert.AreEqual(now.Year, entry.Timestamp.Year);
            Assert.AreEqual(now.Month, entry.Timestamp.Month);
            Assert.AreEqual(now.Date, entry.Timestamp.Date);
            Assert.AreEqual(now.Hour, entry.Timestamp.Hour);
            Assert.AreEqual(now.Minute, entry.Timestamp.Minute);
        }

        [Test]
        public void WhenTimestampIsValid_SetsTimestampProperty()
        {
            var now = DateTime.Now;
            var entry = new HistoryEntry(now, "User", "Text");
            Assert.AreEqual(now, entry.Timestamp);
        }

        [Test]
        public void WhenUserIsValid_SetsUserProperty()
        {
            const string user = "Mr.User";
            var entry = new HistoryEntry(DateTime.Now, user, "Text");
            Assert.AreEqual(user, entry.User);
        }

        [Test]
        public void WhenTextIsValid_SetsTextProperty()
        {
            const string text = "Text";
            var entry1 = new HistoryEntry(DateTime.Now, "User", text);
            Assert.AreEqual(text, entry1.Text);

            var entry2 = new HistoryEntry(text);
            Assert.AreEqual(text, entry2.Text);
        }
    }
}