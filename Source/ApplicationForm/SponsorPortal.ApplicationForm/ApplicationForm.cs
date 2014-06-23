using System;
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

        public ApplicationForm(string organization, string email, double amount, string title, string text)
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
        
        public static CreatedNewApplicationFormEvent CreateNew(string organization, string email, double amount, string title, string text)
        {
            return new CreatedNewApplicationFormEvent(organization, email, amount, title, text);
        }
        
        public override string Identifier
        {
            get { return "ApplicationForm"; }
        }

        public CreatedNewApplicationFormEvent AssignClerk(string clerkId)
        {
            throw new System.NotImplementedException();
        }
    }
}
