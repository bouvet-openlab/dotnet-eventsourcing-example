using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
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

namespace SponsorPortal.Tests.Integration
{
    public abstract class IntegrationTestContext
    {
        private readonly IUnityContainer _container;

        protected IntegrationTestContext()
        {
            _container = new UnityContainer();
        }

        protected void ConfigureDefaultIoC()
        {
            _container.RegisterType<ICommandHandler<CreateClerkCommand>, ClerkService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IClerkRepository, ClerkRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IEventPersistance, EventStoreEventPersistance>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ICommandDispatcher, CommandDispatcher>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IClerkProjection, ClerkProjection>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IApplicationFormRespository, ApplicationFormRepository>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ICommandHandler<CreateNewApplicationFormCommand>, ApplicationFormService>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IApplicationFormProjection, ApplicationFormProjection>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ApplicationFormController>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ClerkController>(new ContainerControlledLifetimeManager());

            // Add dependencies...

            IoC.RegisterContainer(_container);
        }

        protected void ConfigureCustomIoC(IEnumerable<KeyValuePair<object, Tuple<object, LifetimeManager>>> dependencies)
        {
            foreach (var dependency in dependencies)
            {
                var serviceDefinition = dependency.Key;
                var serviceImplementation = dependency.Value.Item1;
                var lifetimeManager = dependency.Value.Item2;

                if (lifetimeManager != null)
                    _container.RegisterType(serviceDefinition.GetType(), serviceImplementation.GetType(), lifetimeManager);
                else
                    _container.RegisterType(serviceDefinition.GetType(), serviceImplementation.GetType());
            }
            IoC.RegisterContainer(_container);
        }
    }
}
