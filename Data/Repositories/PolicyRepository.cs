using Domain.DbContextContracts;
using Domain.EntityModel;
using Domain.RepositoryContracts;
using System;

namespace Data.Repositories
{
    public class PolicyRepository : Repository<PolicyModel>, IPolicyRepository
    {
        public PolicyRepository(IContext dbContext)
            :base(dbContext)
        { }

        public override PolicyModel Insert(PolicyModel entity)
        {
            entity.CreateDate = DateTime.Now;
            return base.Insert(entity);
        }

        public override void Update(PolicyModel entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            base.Update(entity);
        }

        public override void Delete(PolicyModel entity)
        {
            entity.DeleteDate = DateTime.Now;
            base.Update(entity);
        }
    }
}
