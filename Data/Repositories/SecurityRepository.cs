using Domain.DbContextContracts;
using Domain.EntityModel;
using Domain.RepositoryContracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class SecurityRepository
    {
        protected InsurancesContext _dbContext;
        private DbSet<UserModel> _dbSet;

        public SecurityRepository()
        {
            _dbContext = new InsurancesContext();
            _dbSet = _dbContext.Set<UserModel>();
        }

        public IQueryable<UserModel> FindBy(Expression<Func<UserModel, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
