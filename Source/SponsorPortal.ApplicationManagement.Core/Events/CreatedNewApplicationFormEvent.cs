using System;
using SponsorPortal.ApplicationManagement.Core.QueryModel;
using SponsorPortal.ApplicationManagement.Core.QueryModel.ApplicationFormAggregate;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Core.Events
{
    [Serializable]
    public class CreatedNewApplicationFormEvent : EventBase
    {
        public string Organization { get; private set; }
        public string Email { get; private set; }
        public double Amount { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public ApplicationStatus Status { get; private set; }

        public CreatedNewApplicationFormEvent(AggregateRoot aggregateRoot, string organization, string email, double amount, string title, string text)
            : base(aggregateRoot)
        {
            if (String.IsNullOrEmpty(organization)) throw new ArgumentNullException("organization");
            if (String.IsNullOrEmpty(email)) throw new ArgumentNullException("email");
            if (String.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            if (String.IsNullOrEmpty(text)) throw new ArgumentNullException("text");
            if (amount == 0 || amount == 0.0) throw new ArgumentException("Amount must be greater than zero");

            Organization = organization;
            Email = email;
            Amount = amount;
            Title = title;
            Text = text;
            Status = ApplicationStatus.NotProcessed;
        }
    }
}