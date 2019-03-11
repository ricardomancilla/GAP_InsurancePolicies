using Domain.DbContextContracts;
using Domain.EntityModel;
using Domain.RepositoryContracts;

namespace Data.Repositories
{
    public class AuthRepository : SecurityRepository<UserModel>, IAuthRepository
    {
        public AuthRepository(IContext dbContext)
            :base(dbContext)
        { }
    }
}