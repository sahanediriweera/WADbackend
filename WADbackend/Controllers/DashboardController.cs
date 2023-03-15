using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADbackend.Models;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        private readonly MainDatabase mainDatabase;

        public DashboardController(MainDatabase mainDatabase) { this.mainDatabase = mainDatabase; }

        [HttpGet]
        [Route("english")]

        public async Task<IActionResult> EnglishMovies()
        {
            List<Movie> movies = await this.mainDatabase.movies.ToListAsync();

            List<MovieList> sendMovies = new List<MovieList>();

            foreach (Movie movie in movies)
            {
                if (movie.Language == "English")
                {
                    sendMovies.Add(new MovieList() { Name = movie.Title, purchases = (movie.Cost == null) ? 0 : movie.Cost });
                }
            }

            return Ok(sendMovies);
        }

        [HttpGet]
        [Route("sinhala")]

        public async Task<IActionResult> SinhalaMovies()
        {
            List<Movie> movies = await this.mainDatabase.movies.ToListAsync();

            List<MovieList> sendMovies = new List<MovieList>();

            foreach (Movie movie in movies)
            {
                if (movie.Language == "Sinhala")
                {
                    sendMovies.Add(new MovieList() { Name = movie.Title, purchases = (movie.Cost == null) ? 0 : movie.Cost });
                }
            }

            return Ok(sendMovies);
        }

        [HttpGet]
        [Route("tamil")]

        public async Task<IActionResult> TamilMovies()
        {
            List<Movie> movies = await this.mainDatabase.movies.ToListAsync();

            List<MovieList> sendMovies = new List<MovieList>();

            foreach (Movie movie in movies)
            {
                if (movie.Language == "Tamil")
                {
                    sendMovies.Add(new MovieList() { Name = movie.Title, purchases = (movie.Cost == null) ? 0 : movie.Cost });
                }
            }

            return Ok(sendMovies);
        }

        [HttpGet]
        [Route("upcoming")]

        public async Task<IActionResult> UpcomingMovies()
        {
            List<Movie> movies = await this.mainDatabase.movies.ToListAsync();

            List<SendMovies> sendMovies = new List<SendMovies>();

            foreach (Movie movie in movies)
            {
                sendMovies.Add(new SendMovies() { Description = movie.Description, Id = movie.Id, Title = movie.Title });  
            }

            return Ok(sendMovies);
        }

        [HttpGet]
        [Route("search")]

        public async Task<IActionResult> SearchMovies(String Name)
        {
            List<Movie> movies = await this.mainDatabase.movies.ToListAsync();

            List<SendMovies> sendMovies = new List<SendMovies>();


            if (Equals(Name, "."))
            {
                foreach (Movie movie in movies)
                {
                    
                    sendMovies.Add(new SendMovies() { Description = movie.Description, Id = movie.Id, Title = movie.Title });
                    
                }

                return Ok(sendMovies);
            }


            foreach (Movie movie in movies)
            {
                if (movie.Title.Contains(Name))
                {
                    sendMovies.Add(new SendMovies() { Description = movie.Description, Id = movie.Id, Title = movie.Title });
                }
            }

            return Ok(sendMovies);
        }

    }
}
