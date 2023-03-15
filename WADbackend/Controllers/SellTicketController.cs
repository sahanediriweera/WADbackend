using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADbackend.Models;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellTicketController : Controller
    {
        private readonly MainDatabase mainDatabase;

        public SellTicketController(MainDatabase mainDatabase)
        {
            this.mainDatabase = mainDatabase;
        }


        [HttpPost]
        [Route("sellticket")]
        [Authorize]
        public async Task<IActionResult> SellMovie(SellTicket sellTicket)
        {
            List<Seller> sellers = await this.mainDatabase.sellers.ToListAsync();

            Seller owner = null;

            foreach(Seller seller in sellers)
            {
                if(seller.Email == sellTicket.Email)
                {
                    owner = seller;
                }
            }

            if(owner == null)
            {
                return BadRequest();
            }

            List<Movie> movies = await this.mainDatabase.movies.ToListAsync();

            bool isPresent = false;

            foreach(Movie movie in movies)
            {
                if(movie.Title == sellTicket.Name)
                {
                    isPresent = true;
                }
            }

            if (isPresent)
            {
                return BadRequest();
            }

            Movie createMovie = new Movie() { Title = sellTicket.Name, AccountNumber = sellTicket.AccountNumber, Cost = sellTicket.Cost, DateTime = sellTicket.Date + "," + sellTicket.Time, Description = sellTicket.Description, Language = sellTicket.Language, Rating = sellTicket.Rating };

            createMovie.Seller = owner;

            await mainDatabase.movies.AddAsync(createMovie);
            owner.movies.Add(createMovie);
            this.mainDatabase.Entry(owner).State = EntityState.Modified;
            await mainDatabase.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("buyticket")]
        [Authorize]
        public async Task<IActionResult> EditSellMovie(SellTicket sellTicket)
        {
            List<Seller> sellers = await this.mainDatabase.sellers.ToListAsync();

            Seller owner = null;

            foreach (Seller seller in sellers)
            {
                if (seller.Email == sellTicket.Email)
                {
                    owner = seller;
                }
            }

            if (owner == null)
            {
                return BadRequest();
            }

            var movie = await this.mainDatabase.movies.FirstOrDefaultAsync(x => x.Id == sellTicket.id);

            if (movie == null)
            {
                return NotFound();
            }

            movie.Rating = sellTicket.Rating;
            movie.AccountNumber = sellTicket.AccountNumber;
            movie.Cost = sellTicket.Cost;
            movie.Description = sellTicket.Description;
            movie.DateTime = sellTicket.Date+","+sellTicket.Time;
            movie.Language = sellTicket.Language;
            movie.Title = sellTicket.Name;
            

            this.mainDatabase.Entry(movie).State = EntityState.Modified;
            await this.mainDatabase.SaveChangesAsync();

            return Ok();
        }
    }
}
