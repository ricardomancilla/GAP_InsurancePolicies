using Business.Services;
using Domain.ServiceContracts;
using Domain.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost, ActionName("LogIn")]
        public async Task<IHttpActionResult> Authenticate(UserVM filter)
        {
            var user = await Task.FromResult(_service.Authenticate(filter.Username, filter.Password));

            if (user == null)
                return BadRequest("Username or password is incorrect");

            var tokenString = Authorization.TokenGenerator.GenerateTokenJwt(user.Username);

            return Json(new UserVM()
            {
                Username = user.Username,
                Email = user.Email,
                Token = tokenString
            });
        }
    }
}
