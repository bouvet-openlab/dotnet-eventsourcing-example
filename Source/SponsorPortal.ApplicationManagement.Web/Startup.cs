using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Microsoft.Owin.Logging;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using Newtonsoft.Json.Serialization;
using Owin;
using SponsorPortal.ApplicationManagement.Core.CommandModel;
using SponsorPortal.ApplicationManagement.Core.CommandModel.Interfaces;
using SponsorPortal.ApplicationManagement.Core.Commands;
using SponsorPortal.ApplicationManagement.Core.QueryModel;
using SponsorPortal.ApplicationManagement.Core.QueryModel.Interfaces;
using SponsorPortal.ApplicationManagement.Web;
using SponsorPortal.ClerkManagement.CommandModel;
using SponsorPortal.ClerkManagement.Commands;
using SponsorPortal.ClerkManagement.Interfaces;
using SponsorPortal.ClerkManagement.QueryModel;
using SponsorPortal.EventStore;
using SponsorPortal.Infrastructure;

[assembly: OwinStartup(typeof(Startup))]
namespace SponsorPortal.ApplicationManagement.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            try
            {
                var container = ConfigureIoC();
                InitializeEventStore(container);
                InitializeProjections(container);
                ConfigureErrorHandling(builder);
                ConfigureWebApi(builder, container);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + "\n\n" + ex.StackTrace);
            }
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

            container.RegisterType<ICommandHandler<CreateClerkCommand>, ClerkService>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommandHandler<CreateNewApplicationFormCommand>, ApplicationFormService>(new ContainerControlledLifetimeManager());

            container.RegisterType<IApplicationFormProjection, ApplicationFormProjection>(new ContainerControlledLifetimeManager());
            container.RegisterType<IClerkProjection, ClerkProjection>(new ContainerControlledLifetimeManager());

            container.RegisterType<IClerkRepository, ClerkRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IApplicationFormRespository, ApplicationFormRepository>(new ContainerControlledLifetimeManager());

            container.RegisterType<ApplicationFormController>();
            container.RegisterType<ClerkController>();

            container.RegisterType<IEventPersistance, EventStoreEventPersistance>(new ContainerControlledLifetimeManager());
            container.RegisterType<ICommandDispatcher, CommandDispatcher>(new ContainerControlledLifetimeManager());

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

        private void InitializeProjections(IUnityContainer container)
        {
            var projections = container.ResolveAll<ApplicationFormProjection>();
            projections.ForEach(async proj => await proj.Initialize());
        }

        private void ConfigureWebApi(IAppBuilder builder, IUnityContainer container)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = new UnityDependencyResolver(container);
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            builder.UseWebApi(config);
        }
    }

}