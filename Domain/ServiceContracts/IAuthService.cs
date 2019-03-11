using Domain.ViewModel;

namespace Domain.ServiceContracts
{
    public interface IAuthService
    {
        UserVM Authenticate(string userName, string password);

        UserVM Find(object id);
    }
}
