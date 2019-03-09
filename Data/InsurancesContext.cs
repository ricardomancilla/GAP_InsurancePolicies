using Domain.EntityModel;
using Data.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Data
{
    public class InsurancesContext : DbContext, IContext
    {
        public InsurancesContext() : base("name=GAP_InsurancePolicies")
        { }

        public DbSet<AgencyModel> Agencies { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<CodeCategoryModel> CodeCategories { get; set; }
        public DbSet<CodeModel> Codes { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<CustomerPolicyModel> CustomerPolicies { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<PolicyModel> Policies { get; set; }
    }
}
