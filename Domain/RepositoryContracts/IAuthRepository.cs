using Domain.EntityModel;

namespace Domain.RepositoryContracts
{
    public interface IAuthRepository : ISecurityRepository<UserModel>
    {
    }
}
