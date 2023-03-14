using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADbackend.Models;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignUpController : Controller
    {

        private readonly MainDatabase _mainDatabase;

        public SignUpController(MainDatabase mainDatabase)
        {
            _mainDatabase = mainDatabase;
        }

        [HttpPost]
        [Route("seller")]

        public async Task<IActionResult> SignUpSeller(SignUpSeller signUpSeller)
        {

            if(signUpSeller.Password != signUpSeller.confirmPassword)
            {
                return BadRequest();
            }

            List<Seller> sellers = await this._mainDatabase.sellers.ToListAsync();

            bool isPresent = false;

            foreach(Seller seller in sellers)
            {
                if(seller.Email == signUpSeller.Email)
                {
                    isPresent = true;
                }
            }

            if(isPresent == true)
            {
                return BadRequest();
            }

            Seller createSeller = new Seller()
            {
                Email = signUpSeller.Email,
                Name = signUpSeller.Name,
                Password = signUpSeller.Password
            };

            await this._mainDatabase.sellers.AddAsync(createSeller);
            await this._mainDatabase.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        [Route("buyer")]
        public async Task<IActionResult> SignUpBuyer(SignUpBuyer signUpBuyer)
        {


            return Ok();
        }
    }
}
