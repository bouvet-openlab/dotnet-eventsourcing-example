using System.Collections.Immutable;
using System.Threading.Tasks;
using SponsorPortal.ClerkManagement.Events;
using SponsorPortal.ClerkManagement.Interfaces;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ClerkManagement.QueryModel
{
    public class ClerkProjection : Projection, IClerkProjection
    {
        public ClerkProjection(IEventPersistance eventStore) : base(eventStore)
        {
            Clerks = ImmutableList<Clerk>.Empty;
        }

        public ImmutableList<Clerk> Clerks { get; private set; }

        protected async override Task SubscribeToEvents()
        {
            await EventStore.SubscribeToNew<CreatedClerkEvent>(AggregateRoot.Clerk, OnClerkCreated);
        }

        protected override async Task GetPersistedEvents()
        {
            var events = await EventStore.ReadAllFromAggregate<CreatedClerkEvent>(AggregateRoot.Clerk);
            events.ForEach(OnClerkCreated);
        }

        private void OnClerkCreated(CreatedClerkEvent evnt)
        {
            Clerks = Clerks.Add(new Clerk(evnt.EntityId, evnt.Name, evnt.Description, evnt.CreatedTimestamp));
        }
    }
}
