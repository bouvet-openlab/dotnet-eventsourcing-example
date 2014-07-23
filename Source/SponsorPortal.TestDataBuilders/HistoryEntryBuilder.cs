using System;
using SponsorPortal.ApplicationManagement.QueryModel.ApplicationFormAggregate;

namespace SponsorPortal.TestDataBuilders
{
    public class HistoryEntryBuilder : TestDataBuilder<HistoryEntry>
    {
        private DateTime _timestamp;
        private string _user;
        private string _text;

        public HistoryEntryBuilder()
        {
            _timestamp = DateTime.Now;
            _user = "SponorPortalTestFramework";
            _text = "Some generic entry text";
        }

        public HistoryEntryBuilder WithTimestamp(DateTime timestamp)
        {
            _timestamp = timestamp;
            return this;
        }

        public HistoryEntryBuilder WithUser(string user)
        {
            _user = user;
            return this;
        }

        public HistoryEntryBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public override HistoryEntry Build()
        {
            return new HistoryEntry(_timestamp, _user, _text);
        }
    }
}