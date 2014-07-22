using System;

namespace SponsorPortal.ClerkManagement.ValueObjects
{
    public class ClerkDTO
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ClerkDTO(string name, string description)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (String.IsNullOrEmpty(description)) throw new ArgumentNullException("description");
            Name = name;
            Description = description;
        }
    }
}
