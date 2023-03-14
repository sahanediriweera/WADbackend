using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WADbackend.Models;

namespace WADbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyTicketController : Controller
    {
        private readonly MainDatabase mainDatabase;

        public BuyTicketController(MainDatabase mainDatabase)
        {
            this.mainDatabase = mainDatabase;
        }


        [HttpPost]
        [Route("buyticket")]
        [Authorize]
        public async Task<IActionResult> BuyTicket(BuyTicket buyTicket)
        {
            List<Buyer> buyers = await this.mainDatabase.buyers.ToListAsync();

            Buyer buyer = null;

            foreach(Buyer buyer1 in buyers)
            {
                if(buyer1.Email == buyTicket.email)
                {
                    buyer = buyer1;
                }
            }

            if(buyer == null)
            {
                return NotFound();
            }

            List<Movie> movies = await this.mainDatabase.movies.ToListAsync();

            Movie movie = null;

            foreach(Movie movie1 in movies)
            {
                if(movie1.Title == buyTicket.movieName)
                {
                    movie = movie1;
                }
            }

            if(movie == null)
            {
                return BadRequest();
            }

            Ticket ticket = new Ticket() { Buyer = buyer, Title = movie.Title, DateTime = (buyTicket.Date + "," + buyTicket.Time) };

            await this.mainDatabase.tickets.AddAsync(ticket);
            await this.mainDatabase.SaveChangesAsync();
            var tick = await this.mainDatabase.tickets.OrderByDescending(e => e.Id).FirstOrDefaultAsync();
            if(tick != null)
            {
                buyer.Tickets.Add(tick);
                this.mainDatabase.Entry(buyer).State = EntityState.Modified;
                await this.mainDatabase.SaveChangesAsync();

                return Ok();
            } else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Route("editbuyticket")]

        public async Task<IActionResult> EditBuyTicket()
        {
            return Ok();
        }
    }
}
