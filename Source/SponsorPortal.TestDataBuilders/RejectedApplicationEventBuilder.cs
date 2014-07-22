using System;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.ApplicationManagement.Core.Events;

namespace SponsorPortal.TestDataBuilders
{
    public class RejectedApplicationEventBuilder : TestDataBuilder<RejectedApplicationEvent>
    {
        private Guid _applicationId;
        private Guid _clerkId;

        public RejectedApplicationEventBuilder()
        {
            _applicationId = Guid.NewGuid();
            _clerkId = Guid.NewGuid();
        }

        public override RejectedApplicationEvent Build()
        {
            return new RejectedApplicationEvent(_applicationId, _clerkId);
        }

        public RejectedApplicationEventBuilder WithApplicationId(Guid id)
        {
            _applicationId = id;
            return this;
        }

        public RejectedApplicationEventBuilder WithClerkId(Guid id)
        {
            _clerkId = id;
            return this;
        }
        
    }
}