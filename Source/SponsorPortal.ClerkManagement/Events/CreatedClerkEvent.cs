using System;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ClerkManagement.Events
{
    [Serializable]
    public class CreatedClerkEvent : IEvent
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid EntityId { get; private set; }
        public DateTime CreatedTimestamp { get; private set; }
        public AggregateRoot AggregateRootIdentifier { get { return AggregateRoot.Clerk; } }

        public CreatedClerkEvent(string name, string description)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (String.IsNullOrEmpty(description)) throw new ArgumentNullException("description");
            Name = name;
            Description = description;
            EntityId = Guid.NewGuid();
            CreatedTimestamp = DateTime.Now;
        }
    }
}
