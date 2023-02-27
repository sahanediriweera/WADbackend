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
            String lorem = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            return Ok(new List<UpcomingMovies> { new UpcomingMovies() { Id = 1, Title = "Some", Description = lorem }, new UpcomingMovies() { Id = 2, Title = "Some", Description = lorem }, new UpcomingMovies() { Id = 3, Title = "Some", Description = lorem }});
        }

        [HttpGet]
        [Route("search")]

        public async Task<IActionResult> SearchMovies(String Name)
        {
            return Ok(new List<MovieSearch> { new MovieSearch() { Title = " titke", ImageUrl = "d:/batman.jpg", Description = "wer" }, new MovieSearch() { Title = " titke", ImageUrl = "d:/batman.jpg", Description = "wer" }, new MovieSearch() { Title = " titke", ImageUrl = "d:/batman.jpg", Description = "wer" } });
        }

    }
}
