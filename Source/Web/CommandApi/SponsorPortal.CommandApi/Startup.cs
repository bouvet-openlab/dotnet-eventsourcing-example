using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Practices.Unity;
using Owin;
using SponsorPortal.ApplicationForm;
using SponsorPortal.EventStore;
using SponsorPortal.Infrastructure;

[assembly: OwinStartup(typeof(SponsorPortal.CommandApi.Startup))] 
namespace SponsorPortal.CommandApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            ConfigureWebApi(builder);
            ConfigureUnity();
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
            container.RegisterType<IEventPersistance, EventStoreEventPersistance>(new ContainerControlledLifetimeManager());
            container.RegisterType<IApplicationFormRespository, ApplicationFormRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommandHandler<CreateNewApplicationFormCommand>, ApplicationFormService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommandHandler<AssignClerkCommand>, ApplicationFormService>(new ContainerControlledLifetimeManager());

            IoC.RegisterContainer(container);
        }

        private void InitializeEventPersistance()
        {
            var eventPersistance = IoC.Resolve<IEventPersistance>();
            eventPersistance.Initialize();
        }
    }
}