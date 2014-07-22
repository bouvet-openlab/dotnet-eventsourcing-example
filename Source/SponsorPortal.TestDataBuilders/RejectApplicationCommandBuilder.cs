using System;
using SponsorPortal.ApplicationManagement.Commands;

namespace SponsorPortal.TestDataBuilders
{
    public class RejectApplicationCommandBuilder : TestDataBuilder<RejectApplicationCommand>
    {
        private Guid _applicationId;
        private Guid _clerkId;

        public RejectApplicationCommandBuilder()
        {
            _applicationId = Guid.NewGuid();
            _clerkId = Guid.NewGuid();
        }

        public override RejectApplicationCommand Build()
        {
            return new RejectApplicationCommand(_applicationId, _clerkId);
        }

        public RejectApplicationCommandBuilder WithApplicationId(Guid id)
        {
            _applicationId = id;
            return this;
        }

        public RejectApplicationCommandBuilder WithClerkId(Guid id)
        {
            _clerkId = id;
            return this;
        }
    }
}