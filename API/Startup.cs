using API.IoC;
using Autofac;
using Autofac.Integration.WebApi;
using Business.Services;
using Domain.ServiceContracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Owin;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;
            IContainer container = IoC_Factory.GetContainer();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Secret"]);
        //    services.AddAuthentication(x =>
        //    {
        //        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    })
        //    .AddJwtBearer(x =>
        //    {
        //        x.Events = new JwtBearerEvents
        //        {
        //            OnTokenValidated = context =>
        //            {
        //                var userService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();
        //                var userId = int.Parse(context.Principal.Identity.Name);
        //                var user = userService.Find(userId);
        //                if (user == null)
        //                {
        //                    context.Fail("Unauthorized");
        //                }
        //                return Task.CompletedTask;
        //            }
        //        };
        //        x.RequireHttpsMetadata = false;
        //        x.SaveToken = true;
        //        x.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            IssuerSigningKey = new SymmetricSecurityKey(key),
        //            ValidateIssuer = false,
        //            ValidateAudience = false
        //        };
        //    });
        //    services.AddScoped<IAuthService, AuthService>();
        //}

        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    app.UseAuthentication();
        //}
    }
}