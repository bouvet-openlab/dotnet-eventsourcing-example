using System;
using SponsorPortal.ApplicationManagement.Core.Commands;

namespace SponsorPortal.TestDataBuilders
{
    public class GrantApplicationCommandBuilder : TestDataBuilder<GrantApplicationCommand>
    {
        private Guid _applicationId;
        private double _amount;
        private Guid _clerkId;

        public GrantApplicationCommandBuilder()
        {
            _applicationId = Guid.NewGuid();
            _clerkId = Guid.NewGuid();
            _amount = 100.0;
        }

        public GrantApplicationCommandBuilder WithApplicationId(Guid id)
        {
            _applicationId = id;
            return this;
        }

        public GrantApplicationCommandBuilder WithAmount(double amount)
        {
            _amount = amount;
            return this;
        }

        public override GrantApplicationCommand Build()
        {
            return new GrantApplicationCommand(_applicationId, _amount, _clerkId);
        }

        public GrantApplicationCommandBuilder WithClerkId(Guid clerkId)
        {
            _clerkId = clerkId;
            return this;
        }
    }
}