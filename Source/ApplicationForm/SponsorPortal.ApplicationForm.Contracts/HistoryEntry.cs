using System;

namespace SponsorPortal.ApplicationForm.Contracts
{
    public class HistoryEntry
    {
        public DateTime Timestamp { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
    }
}
