using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADbackend.Models;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : Controller
    {
        private readonly MainDatabase mainDatabase;

        public SellerController(MainDatabase mainDatabase)
        {
            this.mainDatabase = mainDatabase;
        }


        [HttpGet]
        [Route("getmovies")]
        public async Task<IActionResult> GetMovies()
        {
            List<Movie> movies = await this.mainDatabase.movies.ToListAsync();

            List<SendMovies> sendMovies = new List<SendMovies>();

            foreach (Movie movie in movies)
            {
                if(movie.Language == "English")
                {
                    sendMovies.Add(new SendMovies() { Description = movie.Description, Id = movie.Id, Title = movie.Title });
                }
            }

            return Ok(sendMovies);
        }

        [HttpGet]
        [Route("yourmovies")]

        public async Task<IActionResult> YourMovies()
        {
            return Ok(new List<TitlePurchase>() { new TitlePurchase { Title = "xcv", purchases = 12 }, new TitlePurchase { Title = "eefe", purchases = 132 }, new TitlePurchase { Title = "fe", purchases = 123 } });
        }

        [HttpDelete]
        [Route("deletemovie")]

        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await this.mainDatabase.movies.FindAsync(id);

            if(movie == null)
            {
                return NotFound();
            }

            this.mainDatabase.movies.Remove(movie);
            await mainDatabase.SaveChangesAsync();

            return Ok();
        }

    }
}
