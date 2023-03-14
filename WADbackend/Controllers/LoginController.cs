using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private readonly MainDatabase mainDatabase;

        public LoginController(MainDatabase mainDatabase)
        {
            this.mainDatabase = mainDatabase;
        }

        [HttpPost]
        [Route("loginbuyer")]
        public async Task<IActionResult> LoginBuyer(Login login)
        {
            List<Buyer> buyers = await this.mainDatabase.buyers.ToListAsync();

            if(buyers == null)
            {
                return BadRequest();
            }

            Buyer buyer = null;

            foreach(var buyer1 in buyers)
            {
                if ((buyer1.Email == login.Email) && buyer1.Password == login.Password)
                {
                    buyer = buyer1;
                }
            }

            if(buyer == null)
            {
                return NotFound();
            }

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

        public async Task<IActionResult> LoginSeller(Login login)
        {
            List<Seller> sellers = await this.mainDatabase.sellers.ToListAsync();

            if(sellers == null)
            {
                return BadRequest();
            }

            Seller seller = null;

            foreach(var seller1 in sellers)
            {
                if ((seller1.Email == login.Email) && seller1.Password == login.Password)
                {
                    seller = seller1;
                }
            }

            if(seller == null)
            {
                return NotFound();
            }

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
    }
}
