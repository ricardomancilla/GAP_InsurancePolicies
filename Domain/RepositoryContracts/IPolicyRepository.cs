using Domain.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.RepositoryContracts
{
    public interface IPolicyRepository : IRepository<PolicyModel>
    {
        IEnumerable<PolicyModel> FindByWithRelations(Expression<Func<PolicyModel, bool>> predicate);
    }
}
