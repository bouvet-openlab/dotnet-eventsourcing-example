using System;

namespace SponsorPortal.ClerkManagement.QueryModel
{
    public class Clerk 
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedTimestamp { get; private set; }

        public Clerk(Guid id, string name, string description, DateTime createdTimestamp)
        {
            if (id == Guid.Empty) throw new ArgumentException("id cannot be empty guid");
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (String.IsNullOrEmpty(description)) throw new ArgumentNullException("description");
            if (createdTimestamp == DateTime.MinValue) throw new ArgumentException("createdTimestamp cannot be initial value");
            if (createdTimestamp == DateTime.MaxValue) throw new ArgumentException("createdTimestamp cannot be initial value");
            Id = id;
            Name = name;
            Description = description;
            CreatedTimestamp = createdTimestamp;
        }
    }
}
