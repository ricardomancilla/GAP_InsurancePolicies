using Domain.DbContextContracts;
using Domain.EntityModel;
using Domain.RepositoryContracts;

namespace Data.Repositories
{
    public class CustomerPolicyRepository : Repository<CustomerPolicyModel>, ICustomerPolicyRepository
    {
        public CustomerPolicyRepository(IContext dbContext)
            :base(dbContext)
        { }
    }
}
