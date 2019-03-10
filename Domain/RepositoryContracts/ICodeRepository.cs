using Domain.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.RepositoryContracts
{
    public interface ICodeRepository : IRepository<CodeModel>
    {
        IEnumerable<CodeModel> FindByWithRelations(Expression<Func<CodeModel, bool>> predicate);
    }
}
