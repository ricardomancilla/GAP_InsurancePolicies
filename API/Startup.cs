using API.IoC;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System.Web.Http;

namespace API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //ConfigureAuth(app);

            var config = GlobalConfiguration.Configuration;
            IContainer container = IoC_Factory.GetContainer();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(config);
        }
    }
}