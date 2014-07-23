using System;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ClerkManagement.Events
{
    [Serializable]
    public class CreatedClerkEvent : EventBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public override string LogDescription
        {
            get { return "Clerk " + Name + "( " + Description + " ) was created"; }
        }
        
        public CreatedClerkEvent(string name, string description) : base(AggregateRoot.Clerk)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (String.IsNullOrEmpty(description)) throw new ArgumentNullException("description");
            Name = name;
            Description = description;
        }
    }
}
