using System;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ClerkManagement.Commands
{
    public class CreateClerkCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public CreateClerkCommand(string name, string description)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            if (String.IsNullOrEmpty(description)) throw new ArgumentNullException("description");

            Name = name;
            Description = description;
        }
    }
}
