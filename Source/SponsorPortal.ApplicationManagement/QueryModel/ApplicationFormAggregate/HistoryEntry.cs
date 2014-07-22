using System;

namespace SponsorPortal.ApplicationManagement.QueryModel.ApplicationFormAggregate
{
    public class HistoryEntry
    {
        public DateTime Timestamp { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
    }
}
