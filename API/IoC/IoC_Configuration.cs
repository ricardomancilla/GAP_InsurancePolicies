﻿using Autofac;
using AutoMapper;
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
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<CityService>().As<ICityService>();
            builder.RegisterType<CodeService>().As<ICodeService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerPolicyService>().As<ICustomerPolicyService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<PolicyService>().As<IPolicyService>();

            builder.RegisterType<AgencyRepository>().As<IAgencyRepository>();
            builder.RegisterType<AuthRepository>().As<IAuthRepository>();
            builder.RegisterType<CityRepository>().As<ICityRepository>();
            builder.RegisterType<CodeRepository>().As<ICodeRepository>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<CustomerPolicyRepository>().As<ICustomerPolicyRepository>();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>();
            builder.RegisterType<PolicyRepository>().As<IPolicyRepository>();

            return builder.Build();
        }
    }
}