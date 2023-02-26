using Microsoft.AspNetCore.Mvc;
using WADbackend.Models;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        [HttpGet]
        [Route("english")]

        public async Task<IActionResult> EnglishMovies()
        {
            return Ok(new List<LanguageMovies> { new LanguageMovies() { Name= "nm", Purchases = 12 }, new LanguageMovies() { Name = "nm", Purchases = 12 }, new LanguageMovies() { Name = "nm", Purchases = 12 }, });
        }

        [HttpGet]
        [Route("sinhala")]

        public async Task<IActionResult> SinhalaMovies()
        {
            return Ok(new List<LanguageMovies> { new LanguageMovies() { Name = "nm", Purchases = 12 }, new LanguageMovies() { Name = "nm", Purchases = 12 }, new LanguageMovies() { Name = "nm", Purchases = 12 }, });
        }

        [HttpGet]
        [Route("tamil")]

        public async Task<IActionResult> TamilMovies()
        {
            return Ok(new List<LanguageMovies> { new LanguageMovies() { Name = "nm", Purchases = 12 }, new LanguageMovies() { Name = "nm", Purchases = 12 }, new LanguageMovies() { Name = "nm", Purchases = 12 }, });
        }

        [HttpGet]
        [Route("upcoming")]

        public async Task<IActionResult> UpcomingMovies()
        {
            return Ok(new List<UpcomingMovies> { new UpcomingMovies() { Id = 1, Title = "Some", Description = "Description" }, new UpcomingMovies() { Id = 2, Title = "Some", Description = "Description" }, new UpcomingMovies() { Id = 3, Title = "Some", Description = "Description" }});
        }

        [HttpGet]
        [Route("search")]

        public async Task<IActionResult> SearchMovies(String Name)
        {
            return Ok(new List<MovieSearch> { new MovieSearch() { Title = " titke", ImageUrl = "d:/batman.jpg", Description = "wer" }, new MovieSearch() { Title = " titke", ImageUrl = "d:/batman.jpg", Description = "wer" }, new MovieSearch() { Title = " titke", ImageUrl = "d:/batman.jpg", Description = "wer" } });
        }

    }
}
