using Domain.ServiceContracts;
using Domain.ViewModel;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseApiController
    {
        IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost, ActionName("LogIn")]
        public async Task<IHttpActionResult> Authenticate(UserVM filter)
        {
            var result = await Task.FromResult(_service.Authenticate(filter.Username, filter.Password));

            if (result.StatusCode != HttpStatusCode.OK)
                return Result(result);

            ((UserVM)result.Result).Token = Authorization.TokenGenerator.GenerateTokenJwt(((UserVM)result.Result).Username);

            return Result(result);
        }
    }
}
