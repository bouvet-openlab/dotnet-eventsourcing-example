using System.Collections.Immutable;
using System.Diagnostics;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
{
    public class ApplicationFormProjection : Projection
    {
        public ImmutableList<ApplicationFormDTO> ApplicationForms { get; private set; }

        public ApplicationFormProjection(IEventStore eventStore) : base(eventStore)
        {
            ApplicationForms = ImmutableList<ApplicationFormDTO>.Empty;
        }

        public override void SubscribeToEvents()
        {
            EventStore.Subscribe<CreatedNewApplicationFormEvent>(OnNewApplicationCreated);
        }

        private void OnNewApplicationCreated(CreatedNewApplicationFormEvent evnt)
        {
            Debug.WriteLine("Received event " + evnt);

            ApplicationForms = ApplicationForms.Add(new ApplicationFormDTO(evnt.Organization, evnt.Email, evnt.Amount, evnt.Title,evnt.Text));
        }
    }
}
