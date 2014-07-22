using System;
using System.Diagnostics;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Diagnostics;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.WebApi;
using Newtonsoft.Json.Serialization;
using Owin;
using SponsorPortal.ApplicationManagement.CommandModel;
using SponsorPortal.ApplicationManagement.CommandModel.Interfaces;
using SponsorPortal.ApplicationManagement.Commands;
using SponsorPortal.ApplicationManagement.QueryModel;
using SponsorPortal.ApplicationManagement.QueryModel.Interfaces;
using SponsorPortal.ClerkManagement.CommandModel;
using SponsorPortal.ClerkManagement.CommandModel.Interfaces;
using SponsorPortal.ClerkManagement.Commands;
using SponsorPortal.ClerkManagement.QueryModel;
using SponsorPortal.ClerkManagement.QueryModel.Interfaces;
using SponsorPortal.EventStore;
using SponsorPortal.Infrastructure;
using SponsorPortal.Logging;
using SponsorPortal.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace SponsorPortal.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            try
            {
                ConfigureLogging();
                var container = ConfigureIoC();
                InitializeEventStore(container);
                InitializeProjections(container);
                ConfigureErrorHandling(builder);
                ConfigureWebApi(builder, container);
            }
            catch (Exception ex)
            {
                Log.Msg(this, log => log.Error("An error occurred during startup configuration", ex));
            }
        }

        private void ConfigureLogging()
        {
            Log.InitializeLogFactory(new DebugLogFactory(), new Log4NetLogFactory());
            Log.Msg(this, log => log.Info("Log framework initialized"));
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