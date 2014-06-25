using System.Web.Http;
using Microsoft.Owin.Cors;
using Microsoft.Practices.Unity;
using Owin;
using SponsorPortal.EventStore;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.CommandApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            ConfigureWebApi(builder);
            ConfigureUnity();
            ActivateProjectionsEventSubscriptions();
            InitializeEventPersistance();
        }

        private void ConfigureWebApi(IAppBuilder builder)
        {
            builder.UseCors(CorsOptions.AllowAll);

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            builder.UseWebApi(config);
        }

        private void ConfigureUnity()
        {
            var container = new UnityContainer();
            //container.RegisterType<IEventStore, SponsorPortalEventStore>(new ContainerControlledLifetimeManager());
            //container.RegisterType<ReceivalProjection>(new ContainerControlledLifetimeManager());
            //container.RegisterType<ICommandHandler<ReceivingNewApplicationFormCommand>, ReceivalCommandHandler>(new ContainerControlledLifetimeManager());
            container.RegisterType<IEventPersistance, NEventStoreEventPersistance>(new ContainerControlledLifetimeManager());

            IoC.RegisterContainer(container);
        }

        private void InitializeEventPersistance()
        {
            var eventPersistance = IoC.Resolve<IEventPersistance>();
            eventPersistance.Initialize();
        }

        private void ActivateProjectionsEventSubscriptions()
        {
            //var projection = IoC.Resolve<ReceivalProjection>();
            //projection.SubscribeToEvents();
        }
    }
}