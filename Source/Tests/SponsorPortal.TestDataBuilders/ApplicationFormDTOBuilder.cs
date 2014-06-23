using SponsorPortal.ApplicationForm;

namespace SponsorPortal.TestDataBuilders
{
    public class ApplicationFormDTOBuilder : TestDataBuilder<ApplicationFormDTO>
    {
        private string _organization;
        private string _email;
        private double _amount;
        private string _title;
        private string _text;

        public ApplicationFormDTOBuilder()
        {
            _organization = "My Company";
            _email = "person@company.com";
            _amount = 10000;
            _title = "Request for money";
            _text = "Need money for stuff";
        }

        public ApplicationFormDTOBuilder WithOrganization(string organization)
        {
            _organization = organization;
            return this;
        }

        public ApplicationFormDTOBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public ApplicationFormDTOBuilder WithAmount(double amount)
        {
            _amount = amount;
            return this;
        }

        public ApplicationFormDTOBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public ApplicationFormDTOBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public override ApplicationFormDTO Build()
        {
            return new ApplicationFormDTO(_organization, _email, _amount, _title, _text);
        }
    }
}
