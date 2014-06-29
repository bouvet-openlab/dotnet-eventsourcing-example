using System.Web.Http;
using Owin;

namespace SponsorPortal.ApplicationManagement.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            ConfigureWebApi(builder);
        }

        private void ConfigureWebApi(IAppBuilder builder)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            builder.UseWebApi(config);
        }
    }
}