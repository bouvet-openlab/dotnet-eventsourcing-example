using System;

namespace SponsorPortal.ApplicationManagement.QueryModel.ApplicationFormAggregate
{
    public class HistoryEntry
    {
        private const string DefaultUser = "SponsorPortal";

        public DateTime Timestamp { get; private set; }
        public string User { get; private set; }
        public string Text { get; private set; }

        public HistoryEntry(DateTime timestamp, string user, string text)
        {
            if (timestamp == DateTime.MinValue || timestamp == DateTime.MaxValue) throw new ArgumentException("Timestamp cannot be min/max");
            if (String.IsNullOrEmpty(user)) throw new ArgumentNullException("user");
            if (String.IsNullOrEmpty(text)) throw new ArgumentNullException("text");

            Timestamp = timestamp;
            User = user;
            Text = text;
        }

        public HistoryEntry(string text)
        {
            if (String.IsNullOrEmpty(text)) throw new ArgumentNullException("text");
            
            Timestamp = DateTime.Now;
            User = DefaultUser;
            Text = text;
        }
    }
}

