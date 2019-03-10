using Data.Interfaces;
using Domain.EntityModel;
using Domain.RepositoryContracts;

namespace Data.Repositories
{
    public class DepartmentRepository : Repository<DepartmentModel>, IDepartmentRepository
    {
        public DepartmentRepository(IContext dbContext)
            :base(dbContext)
        { }
    }
}
