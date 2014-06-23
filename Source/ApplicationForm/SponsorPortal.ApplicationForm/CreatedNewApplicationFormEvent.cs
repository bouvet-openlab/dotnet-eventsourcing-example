using System;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
{
    public class CreatedNewApplicationFormEvent : EventBase
    {
        private readonly string _organization;
        private readonly string _email;
        private readonly double _amount;
        private readonly string _title;
        private readonly string _text;

        public CreatedNewApplicationFormEvent(string organization, string email, double amount, string title, string text)
            : base("ApplicationForm")
        {
            if (organization == null) throw new ArgumentNullException("organization");
            if (email == null) throw new ArgumentNullException("email");
            if (title == null) throw new ArgumentNullException("title");
            if (text == null) throw new ArgumentNullException("text");
            _organization = organization;
            _email = email;
            _amount = amount;
            _title = title;
            _text = text;
        }

        public string Organization
        {
            get { return _organization; }
        }

        public string Email
        {
            get { return _email; }
        }

        public double Amount
        {
            get { return _amount; }
        }

        public string Title
        {
            get { return _title; }
        }

        public string Text
        {
            get { return _text; }
        }
    }
}