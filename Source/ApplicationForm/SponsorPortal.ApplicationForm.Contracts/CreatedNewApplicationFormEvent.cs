using System;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm.Contracts
{
    public class CreatedNewApplicationFormEvent : EventBase
    {
        public string Organization { get; private set; }
        public string Email { get; private set; }
        public double Amount { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public ApplicationStatus Status { get; private set; }

        public CreatedNewApplicationFormEvent(string organization, string email, double amount, string title, string text)
            : base("ApplicationForm")
        {
            if (organization == null) throw new ArgumentNullException("organization");
            if (email == null) throw new ArgumentNullException("email");
            if (title == null) throw new ArgumentNullException("title");
            if (text == null) throw new ArgumentNullException("text");

            Organization = organization;
            Email = email;
            Amount = amount;
            Title = title;
            Text = text;
            Status = ApplicationStatus.NotProcessed;
        }
    }
}