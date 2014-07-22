using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SponsorPortal.ApplicationManagement.Events;
using SponsorPortal.ApplicationManagement.QueryModel.ApplicationFormAggregate;
using SponsorPortal.ApplicationManagement.QueryModel.Interfaces;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;
using SponsorPortal.Logging;

namespace SponsorPortal.ApplicationManagement.QueryModel
{
    public class ApplicationFormProjection : Projection, IApplicationFormProjection
    {
        public ImmutableList<ApplicationForm> ApplicationForms { get; private set; }

        public ApplicationFormProjection(IEventPersistance eventStore) : base(eventStore)
        {
            ApplicationForms = ImmutableList<ApplicationForm>.Empty;
        }

        protected override async Task SubscribeToEvents()
        {
            await EventStore.SubscribeToNew<CreatedNewApplicationFormEvent>(AggregateRoot.ApplicationForm, OnNewApplicationCreated);
        }

        protected override async Task GetPersistedEvents()
        {
            var events = await EventStore.ReadAllFromAggregate<CreatedNewApplicationFormEvent>(AggregateRoot.ApplicationForm);
            events.ForEach(OnNewApplicationCreated);
        }

        private void OnNewApplicationCreated(CreatedNewApplicationFormEvent evnt)
        {
            Log.Msg(this, log => log.Info("Received " + evnt.GetType().Name));

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
            Log.Msg(this, log => log.Info("Received " + evnt.GetType().Name));

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
                                                             "",
                                                             application.History);

            ReplaceApplicationForm(evnt.ApplicationFormId, updatedApplicationForm);
        }

        private void ReplaceApplicationForm(Guid id, ApplicationForm newApplicationForm)
        {
            ApplicationForms = ApplicationForms.Replace(ApplicationForms.Single(app => app.Id == id), newApplicationForm);
        }
    }
}
