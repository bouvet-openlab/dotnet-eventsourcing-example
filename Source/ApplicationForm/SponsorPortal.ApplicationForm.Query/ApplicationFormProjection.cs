using System;
using System.Collections.Immutable;
using System.Diagnostics;
using SponsorPortal.ApplicationForm.Contracts;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm.Query
{
    public class ApplicationFormProjection : Projection
    {
        public ImmutableList<ApplicationForm> ApplicationForms { get; private set; }

        public ApplicationFormProjection(IEventStore eventStore) : base(eventStore)
        {
            ApplicationForms = ImmutableList<ApplicationForm>.Empty;
        }

        public override void SubscribeToEvents()
        {
            EventStore.Subscribe<CreatedNewApplicationFormEvent>(OnNewApplicationCreated);
        }

        private void OnNewApplicationCreated(CreatedNewApplicationFormEvent evnt)
        {
            Debug.WriteLine((string) ("Received event " + evnt));

            ApplicationForms = ApplicationForms.Add(new ApplicationForm(evnt.Id,
                                                                        evnt.Organization,
                                                                        evnt.Email,
                                                                        evnt.Amount,
                                                                        evnt.Title,
                                                                        evnt.Text,
                                                                        evnt.Status,
                                                                        evnt.CreatedTimestamp));
        }
    }
}
