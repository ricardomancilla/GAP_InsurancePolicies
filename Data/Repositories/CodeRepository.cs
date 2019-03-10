using Domain.DbContextContracts;
using Domain.EntityModel;
using Domain.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class CodeRepository : Repository<CodeModel>, ICodeRepository
    {
        public CodeRepository(IContext dbContext)
            : base(dbContext)
        { }
    }
}
