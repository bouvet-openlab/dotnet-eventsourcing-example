using System;

namespace SponsorPortal.ApplicationManagement.Core.QueryModel
{
    public class HistoryEntry
    {
        public DateTime Timestamp { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
    }
}
