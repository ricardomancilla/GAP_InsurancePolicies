using Domain.DbContextContracts;
using Domain.EntityModel;
using Domain.RepositoryContracts;

namespace Data.Repositories
{
    public class AgencyRepository : Repository<AgencyModel>, IAgencyRepository
    {
        public AgencyRepository(IContext dbContext)
            : base(dbContext)
        { }
    }
}
