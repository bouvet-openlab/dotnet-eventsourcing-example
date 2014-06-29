using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SponsorPortal.EventStore;
using SponsorPortal.Infrastructure;
using Unity.WebApi;

[assembly: OwinStartup(typeof(SponsorPortal.QueryApi.Startup))] 
namespace SponsorPortal.QueryApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var container = ConfigureIoC();
            ConfigureWebApi(builder, container);
            InitializeEventPersistance();
            ActivateProjectionsEventSubscriptions();
        }

        private void ConfigureWebApi(IAppBuilder builder, IUnityContainer container)
        {
            builder.UseCors(CorsOptions.AllowAll);
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new UnityDependencyResolver(container);
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            builder.UseWebApi(config);
        }

        private IUnityContainer ConfigureIoC()
        {
            var container = new UnityContainer();
            container.RegisterType<IEventPersistance, EventStoreEventPersistance>(new ContainerControlledLifetimeManager());
            container.RegisterType<IApplicationFormProjection, ApplicationFormProjection>(new ContainerControlledLifetimeManager());
            
            IoC.RegisterContainer(container);

            return container;
        }

        private void InitializeEventPersistance()
        {
            var eventPersistance = IoC.Resolve<IEventPersistance>();
            eventPersistance.Initialize();
        }

        private void ActivateProjectionsEventSubscriptions()
        {
            var projection = IoC.Resolve<IApplicationFormProjection>();
            
            Task.Run(() =>
            {
                projection.GetAllExistingEventsOfInterest();
                projection.SubscribeToEvents();
            }).Wait();
        }
    }
}