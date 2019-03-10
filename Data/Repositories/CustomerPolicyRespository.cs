using Domain.DbContextContracts;
using Domain.EntityModel;
using Domain.RepositoryContracts;

namespace Data.Repositories
{
    public class CustomerPolicyRespository : Repository<CustomerPolicyModel>, ICustomerPolicyRespository
    {
        public CustomerPolicyRespository(IContext dbContext)
            :base(dbContext)
        { }
    }
}
