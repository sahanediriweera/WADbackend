using Microsoft.AspNetCore.Mvc;
using WADbackend.Models;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellTicketController : Controller
    {
        [HttpPost]
        [Route("sellticket")]
        public async Task<IActionResult> BuyMovie(SellTicket sellTicket)
        {
            return StatusCode(201);
        }
    }
}
