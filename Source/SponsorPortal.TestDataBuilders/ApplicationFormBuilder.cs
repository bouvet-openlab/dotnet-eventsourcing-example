using System;
using SponsorPortal.ApplicationManagement.Core.CommandModel;

namespace SponsorPortal.TestDataBuilders
{
    public class ApplicationFormBuilder : TestDataBuilder<ApplicationForm>
    {
        private Guid _id;
        private string _organization;
        private string _email;
        private double _amount;
        private string _title;
        private string _text;

        public ApplicationFormBuilder()
        {
            _id = Guid.NewGuid();
            _organization = "My Company";
            _email = "person@company.com";
            _amount = 10000;
            _title = "Request for money";
            _text = "Need money for stuff";
        }

        public ApplicationFormBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public ApplicationFormBuilder WithOrganization(string organization)
        {
            _organization = organization;
            return this;
        }

        public ApplicationFormBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public ApplicationFormBuilder WithAmount(double amount)
        {
            _amount = amount;
            return this;
        }

        public ApplicationFormBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public ApplicationFormBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public override ApplicationForm Build()
        {
            return new ApplicationForm(_id, _organization, _email, _amount, _title, _text);
        }
    }
}
