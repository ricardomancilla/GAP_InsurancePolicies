using Autofac;
using Business.Services;
using Data;
using Data.Repositories;
using Domain.DbContextContracts;
using Domain.RepositoryContracts;
using Domain.ServiceContracts;

namespace API.IoC
{
    public class IoC_Configuration : IIoC_Configuration
    {
        public IContainer Container(ContainerBuilder builder)
        {
            builder.RegisterType<InsurancesContext>().As<IContext>();

            builder.RegisterType<AgencyService>().As<IAgencyService>();
            builder.RegisterType<CityService>().As<ICityService>();
            builder.RegisterType<CodeService>().As<ICodeService>();

            builder.RegisterType<AgencyRepository>().As<IAgencyRepository>();
            builder.RegisterType<CityRepository>().As<ICityRepository>();
            builder.RegisterType<CodeRepository>().As<ICodeRepository>();

            return builder.Build();
        }
    }
}