using Domain.DbContextContracts;
using Domain.EntityModel;
using Domain.RepositoryContracts;

namespace Data.Repositories
{
    public class CustomerRepository : Repository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(IContext dbContext)
            :base(dbContext)
        { }
    }
}
