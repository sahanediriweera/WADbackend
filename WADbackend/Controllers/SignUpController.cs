using Microsoft.AspNetCore.Mvc;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignUpController : Controller
    {
        [HttpPost]
        [Route("seller")]

        public async Task<IActionResult> SignUpSeller()
        {
            return Ok();
        }

        [HttpPost]
        [Route("buyer")]
        public async Task<IActionResult> SignUpBuyer()
        {
            return Ok();
        }
    }
}
