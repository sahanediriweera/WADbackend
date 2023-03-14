using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WADbackend.Models;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private readonly MainDatabase _mainDatabase;

        public LoginController(MainDatabase mainDatabase)
        {
            _mainDatabase = mainDatabase;
        }

        [HttpPost]
        [Route("loginbuyer")]
        public async Task<IActionResult> LoginBuyer()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new AuthenticatedResponse { token = tokenString });
        }

        [HttpPost]
        [Route("loginseller")]

        public async Task<IActionResult> LoginSeller()
        {
            return Ok();
        }
    }
}
