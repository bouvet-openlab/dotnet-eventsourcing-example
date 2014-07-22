using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace SponsorPortal.ApplicationManagement.QueryModel.ApplicationFormAggregate
{
    public class ApplicationForm
    {
        public Guid Id { get; private set; }
        public string Organization { get; private set; }
        public string Email { get; private set; }
        public double Amount { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string ClerkName { get; private set; }
        public ApplicationStatus Status { get; private set; }
        public DateTime CreatedTimestamp { get; private set; }
        public DateTime UpdatedTimestamp { get; private set; }
        public ImmutableList<HistoryEntry> History { get; private set; }

        public ApplicationForm(Guid id, string organization, string email, double amount, string title, string text, ApplicationStatus status, DateTime createdTimestamp)
            : this(id, organization, email, amount, title, text, status, createdTimestamp, createdTimestamp, null, ImmutableList<HistoryEntry>.Empty)
        {
        }

        public ApplicationForm(Guid id, string organization, string email, double amount, string title, string text, ApplicationStatus status,
           DateTime createdTimestamp, DateTime updatedTimestamp, string clerkName, IEnumerable<HistoryEntry> history)
        {
            if (String.IsNullOrEmpty(organization)) throw new ArgumentNullException("organization");
            if (String.IsNullOrEmpty(email)) throw new ArgumentNullException("email");
            if (String.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            if (String.IsNullOrEmpty(text)) throw new ArgumentNullException("text");
            if (amount == 0.0) throw new ArgumentException("amount cannot be zero");

            Id = id;
            Organization = organization;
            Email = email;
            Amount = amount;
            Title = title;
            Text = text;
            ClerkName = String.IsNullOrEmpty(clerkName) ? null : clerkName;
            Status = status;
            CreatedTimestamp = createdTimestamp;
            UpdatedTimestamp = updatedTimestamp;

            History = history != null && history.Any() ? history.ToImmutableList() : ImmutableList<HistoryEntry>.Empty;
        }
    }
}
