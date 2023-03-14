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

            Seller createSeller = new Seller() { Email = signUpSeller.Email, Name = signUpSeller.Name, Password = signUpSeller.Password };

            await this._mainDatabase.sellers.AddAsync(createSeller);
            await this._mainDatabase.SaveChangesAsync();

            return Ok(sellers);
        }

        [HttpPost]
        [Route("buyer")]
        public async Task<IActionResult> SignUpBuyer(SignUpBuyer signUpBuyer)
        {
            if(signUpBuyer.Password != signUpBuyer.confirmPassword)
            {
                return BadRequest();
            }

            List<Buyer> buyers = await this._mainDatabase.buyers.ToListAsync();

            bool isPresent = false;

            foreach(Buyer buyer in buyers)
            {
                if(buyer.Email == signUpBuyer.Email)
                {
                    isPresent = true;
                }
            }

            if (!isPresent)
            {
                return BadRequest();
            }

            Buyer createbuyer = new Buyer() { Email = signUpBuyer.Email, Name = signUpBuyer.Name, Password = signUpBuyer.Password };

            await this._mainDatabase.buyers.AddAsync(createbuyer);
            await this._mainDatabase.SaveChangesAsync();

            return Ok(createbuyer);
        }
    }
}
