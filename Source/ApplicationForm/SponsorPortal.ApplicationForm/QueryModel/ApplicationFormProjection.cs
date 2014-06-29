using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SponsorPortal.ApplicationManagement.Core.Events;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationManagement.Core.QueryModel
{
    public class ApplicationFormProjection : Projection, IApplicationFormProjection
    {
        public ImmutableList<ApplicationForm> ApplicationForms { get; private set; }

        public ApplicationFormProjection(IEventPersistance eventStore) : base(eventStore)
        {
            ApplicationForms = ImmutableList<ApplicationForm>.Empty;
        }

        public override async Task SubscribeToEvents()
        {
            await EventStore.SubscribeToNew<CreatedNewApplicationFormEvent>(AggregateRoots.ApplicationForm, OnNewApplicationCreated);
        }

        public async Task GetAllExistingEventsOfInterest()
        {
            var events = await EventStore.ReadAllFromAggregate<CreatedNewApplicationFormEvent>(AggregateRoots.ApplicationForm);
            events.ForEach(OnNewApplicationCreated);
        }

        private void OnNewApplicationCreated(CreatedNewApplicationFormEvent evnt)
        {
            Debug.WriteLine("Received " + evnt.GetType().Name);

            ApplicationForms = ApplicationForms.Add(new ApplicationForm(evnt.EntityId,
                                                                        evnt.Organization,
                                                                        evnt.Email,
                                                                        evnt.Amount,
                                                                        evnt.Title,
                                                                        evnt.Text,
                                                                        evnt.Status,
                                                                        evnt.CreatedTimestamp));
        }

        private void OnClerkAssignedToApplication(ClerkAssignedToApplicationFormEvent evnt)
        {
            Debug.WriteLine("Received " + evnt.GetType().Name);

            var application = ApplicationForms.Single(app => app.Id == evnt.ApplicationFormId);
            var updatedApplicationForm = new ApplicationForm(application.Id,
                                                             application.Organization,
                                                             application.Email,
                                                             application.Amount,
                                                             application.Title,
                                                             application.Text,
                                                             application.Status,
                                                             application.CreatedTimestamp,
                                                             application.UpdatedTimestamp,
                                                             evnt.ClerkId,
                                                             application.History);

            ReplaceApplicationForm(evnt.ApplicationFormId, updatedApplicationForm);
        }

        private void ReplaceApplicationForm(Guid id, ApplicationForm newApplicationForm)
        {
            ApplicationForms = ApplicationForms.Replace(ApplicationForms.Single(app => app.Id == id), newApplicationForm);
        }
    }
}
