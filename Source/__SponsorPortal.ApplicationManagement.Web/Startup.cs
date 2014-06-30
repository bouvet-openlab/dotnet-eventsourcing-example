using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Owin;

namespace SponsorPortal.ApplicationManagement.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var ioc = new ContainerBuilder();
            ioc.RegisterType<>()

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.DependencyResolver = 
            builder.UseWebApi(config);
        }
    }

    public class TestController : ApiController
    {
        [HttpGet]
        [Route("test")]
        public string Get()
        {
            return "hello from webapi owin...";
        }
    }
}
