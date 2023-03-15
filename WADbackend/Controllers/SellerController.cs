using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetMovies(String email)
        {
            List<Seller> sellers = await this.mainDatabase.sellers.ToListAsync();

            Seller seller = null;

            foreach (Seller s in sellers)
            {
                if (s.Email == email)
                {
                    seller = s;
                }
            }

            if (seller == null)
            {
                return BadRequest();
            }

            List<SellerMovies> sellerMovies = new List<SellerMovies>();

            List<Movie> movies = await this.mainDatabase.movies.ToListAsync();

            foreach (Movie movie in movies)
            {
                if (movie.Seller.Id == seller.Id)
                {
                    sellerMovies.Add(new SellerMovies() { id = movie.Id, title = movie.Title, description = movie.Description  });
                }
            }

            return Ok(sellerMovies);
        }

        [HttpGet]
        [Route("yourmovies")]
        [Authorize]
        public async Task<IActionResult> YourMovies(String email)
        {
            List<Seller> sellers = await this.mainDatabase.sellers.ToListAsync();

            Seller seller = null;

            foreach (Seller s in sellers)
            {
                if(s.Email == email)
                {
                    seller = s;
                }
            }

            if(seller == null)
            {
                return BadRequest();
            }

            List<SellerYourMovies> yourSellerMovies = new List<SellerYourMovies>();

            List<Movie> movies = await this.mainDatabase.movies.ToListAsync();

            foreach(Movie movie in movies)
            {
                if(movie.Seller.Id == seller.Id)
                {
                    yourSellerMovies.Add(new SellerYourMovies() {id = movie.Id, Title = movie.Title, purchases = 0 });
                }
            }

            List<Ticket> tickets = await this.mainDatabase.tickets.ToListAsync();

            foreach (Ticket ticket in tickets)
            {
                String title = ticket.Title;
                
                for(int i = 0; i < yourSellerMovies.Count; i++)
                {
                    SellerYourMovies sellerYourMovies = yourSellerMovies[i];

                    if(Equals(title, sellerYourMovies.Title))
                    {
                        sellerYourMovies.purchases = sellerYourMovies.purchases + 1;
                        yourSellerMovies[i] = sellerYourMovies;
                    }
                }
            }

            return Ok(yourSellerMovies);

        }

        [HttpDelete]
        [Route("deletemovie")]
        [Authorize]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await this.mainDatabase.movies.FindAsync(id);

            if(movie == null)
            {
                return NotFound();
            }

            this.mainDatabase.movies.Remove(movie);
            await mainDatabase.SaveChangesAsync();
            
            return Ok(id);
        }

    }
}
