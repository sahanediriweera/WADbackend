using Microsoft.AspNetCore.Mvc;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyTicketController : Controller
    {
        [HttpPost]
        [Route("buyticket")]
        public async Task<IActionResult> BuyTicket()
        {
            return Ok();
        }
    }
}
