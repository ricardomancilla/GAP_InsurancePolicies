using Data.Repositories;
using Domain.ServiceContracts;
using Domain.ViewModel;
using System.Linq;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private AuthRepository _repository;

        public AuthService()
        {
            _repository = new AuthRepository();
        }

        public UserVM ValidateUser(string userName, string password)
        {
            var user = _repository.FindBy(x => x.Username.Equals(userName) && x.Password.Equals(password)).FirstOrDefault();

            if (user == null)
                return null;

            return new UserVM()
            {
                UserID = user.UserID,
                Username = user.Username,
                Password = user.Password
            };
        }
    }
}
