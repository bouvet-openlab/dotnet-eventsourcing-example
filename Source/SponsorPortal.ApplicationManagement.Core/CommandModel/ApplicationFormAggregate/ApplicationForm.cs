using System;
using SponsorPortal.ApplicationManagement.Core.Events;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Core.CommandModel.ApplicationFormAggregate
{
    public class ApplicationForm : Aggregate
    {
        public string Organization { get; private set; }
        public string Email { get; private set; }
        public double Amount { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }

        public ApplicationForm(Guid id, string organization, string email, double amount, string title, string text) : base(id)
        {
            if (String.IsNullOrEmpty(organization)) throw new ArgumentNullException("organization");
            if (String.IsNullOrEmpty(email)) throw new ArgumentNullException("email");
            if (String.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            if (String.IsNullOrEmpty(text)) throw new ArgumentNullException("text");
            if (amount == 0.0) throw new ArgumentException("amount cannot be zero");

            Organization = organization;
            Email = email;
            Amount = amount;
            Title = title;
            Text = text;
        }

        public ApplicationForm(string organization, string email, double amount, string title, string text)
            : this(Guid.NewGuid(), organization, email, amount, title, text)
        {
            
        }

        public override AggregateRoot AggregateRootIdentifier
        {
            get { return AggregateRoot.ApplicationForm; }
        }

        public static CreatedNewApplicationFormEvent CreateNew(string organization, string email, double amount, string title, string text)
        {
            return new CreatedNewApplicationFormEvent(AggregateRoot.ApplicationForm, organization, email, amount, title, text);
        }
      
        public ClerkAssignedToApplicationFormEvent AssignClerk(Guid clerkId)
        {
            return new ClerkAssignedToApplicationFormEvent(Id, clerkId);
        }
    }
}
