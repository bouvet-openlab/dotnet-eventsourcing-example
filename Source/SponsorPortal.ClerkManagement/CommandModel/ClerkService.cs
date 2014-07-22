using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SponsorPortal.ClerkManagement.CommandModel.Interfaces;
using SponsorPortal.ClerkManagement.Commands;
using SponsorPortal.ClerkManagement.QueryModel;
using SponsorPortal.Infrastructure;
using Clerk = SponsorPortal.ClerkManagement.CommandModel.ClerkAggregate.Clerk;

namespace SponsorPortal.ClerkManagement.CommandModel
{
    public class ClerkService : ICommandHandler<CreateClerkCommand>
    {
        private readonly IClerkRepository _clerkRepository;

        public ClerkService(IClerkRepository clerkRepository)
        {
            if (clerkRepository == null) throw new ArgumentNullException("clerkRepository");
            _clerkRepository = clerkRepository;
        }

        public async Task Handle(CreateClerkCommand command)
        {
            var clerkCreatedEvent = Clerk.Create(command.Name, command.Description);
            await _clerkRepository.Store(clerkCreatedEvent);
        }
    }
}
