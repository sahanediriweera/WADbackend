using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyTicketController : Controller
    {
        [HttpPost]
        [Route("buyticket")]
        [Authorize]
        public async Task<IActionResult> BuyTicket()
        {
            return Ok();
        }

        [HttpPut]
        [Route("editbuyticket")]

        public async Task<IActionResult> EditBuyTicket()
        {
            return Ok();
        }
    }
}
