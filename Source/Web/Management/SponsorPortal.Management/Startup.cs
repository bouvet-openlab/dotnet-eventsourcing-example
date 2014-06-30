using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using Owin;
using SponsorPortal.ApplicationManagement.Core.CommandModel;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.ApplicationManagement.Core.QueryModel;
using SponsorPortal.ApplicationManagement.Web;
using SponsorPortal.EventStore;
using SponsorPortal.Infrastructure;

[assembly: OwinStartup(typeof(Startup))]
namespace SponsorPortal.ApplicationManagement.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var container = ConfigureIoC();
            InitializeEventStore(container);
            InitializeProjections(container);
            ConfigureErrorHandling(builder);
            ConfigureWebApi(builder, container);
            
        }

        private void ConfigureErrorHandling(IAppBuilder builder)
        {
            builder.UseErrorPage(new ErrorPageOptions
            {
                ShowExceptionDetails = true,
                ShowEnvironment = true,
                ShowCookies = false,
                ShowSourceCode = true,
            });
        }

        private IUnityContainer ConfigureIoC()
        {
            var container = new UnityContainer();

            container.RegisterType<ICommandHandler<CreateNewApplicationFormCommand>, ApplicationFormService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IApplicationFormProjection, ApplicationFormProjection>(new ContainerControlledLifetimeManager());
            container.RegisterType<IApplicationFormRespository, ApplicationFormRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IEventPersistance, EventStoreEventPersistance>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommandDispatcher, CommandDispatcher>();
            container.RegisterType<ApplicationFormController>();

            /*
            container.RegisterTypes(
                AllClasses.FromAssemblies(Assembly.GetExecutingAssembly())
                    .Where(t => typeof (Projection).IsAssignableFrom(t)));
            */

            IoC.RegisterContainer(container);
            return container;
        }

        private void InitializeEventStore(IUnityContainer container)
        {
            var eventstore = container.Resolve<IEventPersistance>();
            eventstore.Initialize();
        }

        private async void InitializeProjections(IUnityContainer container)
        {
            var projection = container.Resolve<ApplicationFormProjection>();
            await projection.GetAllExistingEventsOfInterest();
        }

        private void ConfigureWebApi(IAppBuilder builder, IUnityContainer container)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new UnityDependencyResolver(container);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            builder.UseWebApi(config);
        }
    }
}