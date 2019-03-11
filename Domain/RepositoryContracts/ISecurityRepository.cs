using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.RepositoryContracts
{
    public interface ISecurityRepository<T> where T : class
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void SaveChanges();
    }
}
