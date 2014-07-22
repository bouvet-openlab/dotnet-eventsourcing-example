using SponsorPortal.ClerkManagement.Events;

namespace SponsorPortal.ClerkManagement.CommandModel.ClerkAggregate
{
    public class Clerk
    {
        public static CreatedClerkEvent Create(string name, string description)
        {
            return new CreatedClerkEvent(name, description);
        }
    }
}
