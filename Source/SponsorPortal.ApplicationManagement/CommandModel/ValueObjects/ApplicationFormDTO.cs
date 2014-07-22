using System;

namespace SponsorPortal.ApplicationManagement.CommandModel.ValueObjects
{
    public class ApplicationFormDTO
    {
        public Guid Id { get; private set; }
        public string Organization { get; private set; }
        public string Email { get; private set; }
        public double Amount { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }

        public ApplicationFormDTO(Guid id, string organization, string email, double amount, string title, string text) 
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
        }

        public ApplicationFormDTO(string organization, string email, double amount, string title, string text)
            : this(Guid.NewGuid(), organization, email, amount, title, text)
        {
            
        }
    }
}