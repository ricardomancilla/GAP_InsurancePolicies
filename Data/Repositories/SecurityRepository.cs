using Domain.DbContextContracts;
using Domain.RepositoryContracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class SecurityRepository<T> : ISecurityRepository<T> where T : class
    {
        protected IContext _dbContext;
        private DbSet<T> _dbSet;

        public SecurityRepository(IContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
