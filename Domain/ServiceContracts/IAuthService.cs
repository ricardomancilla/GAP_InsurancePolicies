using Domain.EntityModel;
using Domain.ViewModel;

namespace Domain.ServiceContracts
{
    public interface IAuthService
    {
        UserVM ValidateUser(string userName, string password);
    }
}
