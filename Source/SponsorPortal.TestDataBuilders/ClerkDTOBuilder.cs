using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SponsorPortal.ClerkManagement.ValueObjects;

namespace SponsorPortal.TestDataBuilders
{
    public class ClerkDTOBuilder : TestDataBuilder<ClerkDTO>
    {
        private string _name;
        private string _description;

        public ClerkDTOBuilder()
        {
            _name = "Mr. Clerk";
            _description = "Some description";
        }

        public ClerkDTOBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ClerkDTOBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public override ClerkDTO Build()
        {
            return new ClerkDTO(_name, _description);
        }
    }
}
