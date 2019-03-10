using API.IoC;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json;
using System.Web;
using System.Web.Http;

namespace API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;
            IContainer container = IoC_Factory.GetContainer();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
