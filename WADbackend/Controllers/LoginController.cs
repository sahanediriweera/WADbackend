using Microsoft.AspNetCore.Mvc;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("loginbuyer")]
        public async Task<IActionResult> LoginBuyer()
        {
            return Ok();
        }

        [HttpPost]
        [Route("loginseller")]

        public async Task<IActionResult> LoginSeller()
        {
            return Ok();
        }
    }
}
