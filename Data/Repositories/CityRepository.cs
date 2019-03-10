using Data.Interfaces;
using Domain.EntityModel;
using Domain.RepositoryContracts;

namespace Data.Repositories
{
    public class CityRepository : Repository<CityModel>, ICityRepository
    {
        public CityRepository(IContext dbContext)
            :base(dbContext)
        { }
    }
}
