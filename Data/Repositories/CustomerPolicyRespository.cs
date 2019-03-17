using Domain.DbContextContracts;
using Domain.EntityModel;
using Domain.RepositoryContracts;
using System;

namespace Data.Repositories
{
    public class CustomerPolicyRepository : Repository<CustomerPolicyModel>, ICustomerPolicyRepository
    {
        public CustomerPolicyRepository(IContext dbContext)
            :base(dbContext)
        { }

        public override CustomerPolicyModel Insert(CustomerPolicyModel entity)
        {
            entity.CreateDate = DateTime.Now;
            return base.Insert(entity);
        }

        public override void Update(CustomerPolicyModel entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
