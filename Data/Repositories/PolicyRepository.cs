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

        public override void Insert(PolicyModel entity)
        {
            entity.CreateDtm = DateTime.Now;
            base.Insert(entity);
        }

        public override void Update(PolicyModel entity)
        {
            entity.LastUpdateDtm = DateTime.Now;
            base.Update(entity);
        }
    }
}
