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

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Json(new UserVM()
            {
                Username = user.Username,
                Email = user.Email,
                Token = tokenString
            });
        }
    }
}
