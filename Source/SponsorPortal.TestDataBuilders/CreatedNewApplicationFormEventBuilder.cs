using SponsorPortal.ApplicationManagement.Core.Events;
using SponsorPortal.Helpers;

namespace SponsorPortal.TestDataBuilders
{
    public class CreatedNewApplicationFormEventBuilder : TestDataBuilder<CreatedNewApplicationFormEvent>
    {
        private string _organization;
        private string _email;
        private double _amount;
        private string _title;
        private string _text;
        private AggregateRoot _aggregateRootIdentifier;

        public CreatedNewApplicationFormEventBuilder()
        {
            _organization = "My Company";
            _email = "person@company.com";
            _amount = 10000;
            _title = "Request for money";
            _text = "Need money for stuff";
            _aggregateRootIdentifier = AggregateRoot.ApplicationForm;
        }

        public CreatedNewApplicationFormEventBuilder WithOrganization(string organization)
        {
            _organization = organization;
            return this;
        }

        public CreatedNewApplicationFormEventBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public CreatedNewApplicationFormEventBuilder WithAmount(double amount)
        {
            _amount = amount;
            return this;
        }

        public CreatedNewApplicationFormEventBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public CreatedNewApplicationFormEventBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public CreatedNewApplicationFormEventBuilder WithAggregateRootIdentifier(AggregateRoot aggregateRootIdentifier)
        {
            _aggregateRootIdentifier = aggregateRootIdentifier;
            return this;
        }
        
        public override CreatedNewApplicationFormEvent Build()
        {
            return new CreatedNewApplicationFormEvent(_aggregateRootIdentifier, _organization, _email, _amount, _title, _text);
        }
    }
}
