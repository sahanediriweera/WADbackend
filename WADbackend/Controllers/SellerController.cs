using Microsoft.AspNetCore.Mvc;
using WADbackend.Models;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : Controller
    {
        [HttpGet]
        [Route("getmovies")]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(new List<SendMovies>() { new Models.SendMovies() { Id = 1, Title = "title", Description = "description", Image = "https://via.placeholder.com/150" } });
        }

        [HttpGet]
        [Route("yourmovies")]

        public async Task<IActionResult> YourMovies()
        {
            return Ok(new List<TitlePurchase>() { new TitlePurchase { Title = "xcv", purchases = 12 }, new TitlePurchase { Title = "eefe", purchases = 132 }, new TitlePurchase { Title = "fe", purchases = 123 } });
        }
    }
}
