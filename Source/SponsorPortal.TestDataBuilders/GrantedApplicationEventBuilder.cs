using System;
using SponsorPortal.ApplicationManagement.Events;

namespace SponsorPortal.TestDataBuilders
{
    public class GrantedApplicationEventBuilder : TestDataBuilder<GrantedApplicationEvent>
    {
        private Guid _applicationId;
        private double _amount;
        private Guid _clerkId;

        public GrantedApplicationEventBuilder()
        {
            _applicationId = Guid.NewGuid();
            _clerkId = Guid.NewGuid();
            _amount = 100.0;
        }

        public GrantedApplicationEventBuilder WithApplicationId(Guid id)
        {
            _applicationId = id;
            return this;
        }

        public GrantedApplicationEventBuilder WithAmount(double amount)
        {
            _amount = amount;
            return this;
        }


        public override GrantedApplicationEvent Build()
        {
            return new GrantedApplicationEvent(_applicationId, _amount, _clerkId);
        }

        public GrantedApplicationEventBuilder WithClerkId(Guid clerkId)
        {
            _clerkId = clerkId;
            return this;
        }
    }
}