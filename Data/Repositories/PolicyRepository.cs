using Domain.EntityModel;
using Domain.RepositoryContracts;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class PolicyRepository : Repository<PolicyModel>, IPolicyRepository
    {
        public PolicyRepository(IContext dbContext)
            :base(dbContext)
        { }

        public IEnumerable<PolicyModel> FindByWithRelations(Expression<Func<PolicyModel, bool>> predicate)
        {
            return base.FindByWithRelations().Include(x => x.CustomerPolicies).Where(predicate);
        }

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
