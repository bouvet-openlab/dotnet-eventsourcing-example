using System;
using SponsorPortal.ApplicationForm.Contracts;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
{
    public class ApplicationForm : AggregateRoot
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

        public override AggregateRoots AggregateRootIdentifier
        {
            get { return AggregateRoots.ApplicationForm; }
        }

        public static CreatedNewApplicationFormEvent CreateNew(string organization, string email, double amount, string title, string text)
        {
            return new CreatedNewApplicationFormEvent(AggregateRoots.ApplicationForm, organization, email, amount, title, text);
        }
      
        public ClerkAssignedToApplicationFormEvent AssignClerk(string clerkId)
        {
            return new ClerkAssignedToApplicationFormEvent(Id, clerkId);
        }
    }
}
