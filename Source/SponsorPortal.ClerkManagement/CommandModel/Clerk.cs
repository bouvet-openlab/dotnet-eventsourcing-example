using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SponsorPortal.ClerkManagement.Events;

namespace SponsorPortal.ClerkManagement.CommandModel
{
    public class Clerk
    {
        public static CreatedClerkEvent Create(string name, string description)
        {
            return new CreatedClerkEvent(name, description);
        }
    }
}
