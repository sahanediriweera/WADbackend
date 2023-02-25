using Microsoft.AspNetCore.Mvc;
using WADbackend.Models;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyerController : Controller
    {
        [HttpPost]
        [Route("buyticket")]
        public async Task<IActionResult> BuyMovie(BuyTicket buyTicket)
        {
            return StatusCode(201);
        }
    }
}
