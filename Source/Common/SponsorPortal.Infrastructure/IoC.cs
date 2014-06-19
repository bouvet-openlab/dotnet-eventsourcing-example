using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace SponsorPortal.Infrastructure
{
    public static class IoC
    {
        private static IUnityContainer _container;

        public static void RegisterContainer(IUnityContainer container)
        {
            _container = container;
        }

        public static TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }

        public static IEnumerable<TService> ResolveAll<TService>()
        {
            var result = new List<TService>();
            if (IsRegistered<TService>())
            {
                var services = _container.ResolveAll<TService>().ToList();

                if (!services.Any())
                {
                    var service = _container.Resolve<TService>();
                    if (service != null)
                    {
                        result.Add(service);
                    }
                }
                else
                {
                    result.AddRange(services);
                }
            }
            return result;
        }

        public static bool IsRegistered<TService>()
        {
            return _container.IsRegistered<TService>();
        }
    }
}
