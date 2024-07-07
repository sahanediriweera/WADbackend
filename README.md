# Movie Ticketing Application Backend

This project is the backend WebAPI for a movie ticketing application. It provides a set of APIs used by the frontend to ensure effective functioning of the movie ticketing system. The project includes authentication and authorization mechanisms to secure the APIs.

The frontend of this project can be found at [Movie Ticketing Application Frontend](https://github.com/sahanediriweera/webapplicationdevelopmentproject/).

## Functionality

The Movie Ticketing Application Backend provides the following functionality:

- **User Authentication and Authorization**: Ensures that only authenticated and authorized users can access the protected resources.
- **Movie Management**: Allows adding, updating, and deleting movie information.
- **Showtime Management**: Manages showtimes for movies.
- **Ticket Booking**: Allows users to book tickets for movies.
- **User Management**: Handles user registration, login, and profile management.

## Technologies Used

- **Backend**: ASP.NET Core WebAPI
- **Database**: Entity Framework Core
- **Authentication and Authorization**: JWT (JSON Web Token)
- **Programming Language**: C#

## Project Structure

The project is structured into several key components:

- **Controllers**: Handle HTTP requests and return responses.
- **Models**: Define the data structures.
- **Repositories**: Handle data access and database operations.
- **Middleware**: Manage custom middleware for logging, error handling, etc.

## Getting Started

To use the movie ticketing application backend, follow these steps:

1. **Clone the Project Repository**: Clone the project repository to your local machine.
   ```bash
   git clone https://github.com/sahanediriweera/WADbackend.git
   cd WADbackend
   ```

2. **Update Project Dependencies**: Update the project dependencies using the appropriate package manager.
   ```bash
   dotnet restore
   ```

3. **Run the Application**: Run the application using the `dotnet run` command. Make sure you have the .NET SDK installed on your machine.
   ```bash
   dotnet run
   ```

## Database

The database for this application is implemented using Entity Framework Core. The backend is responsible for managing the database schema and executing database operations. Make sure to configure the database connection string in the `appsettings.json` file.

## Authentication and Authorization

The movie ticketing application backend includes authentication and authorization mechanisms to secure the APIs. This ensures that only authenticated and authorized users can access the protected resources. JWT (JSON Web Token) is used for securing the APIs.

## Contributing

Contributions to the movie ticketing application backend are welcome. If you have any bug fixes, improvements, or new features to contribute, please follow these steps:

1. **Fork the Repository**: Fork the repository to your GitHub account.
2. **Create a New Branch**: Create a new branch for your feature or bug fix.
3. **Make Changes**: Make the necessary changes and commit them.
4. **Push Changes**: Push your changes to your forked repository.
5. **Submit a Pull Request**: Submit a pull request describing your changes.

Please ensure that your code adheres to the project's coding guidelines and includes appropriate tests.

### Example Code Snippet

Here is an example of a simple API endpoint in the backend:

```csharp
﻿using Microsoft.AspNetCore.Authorization;
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

            var movie = await this.mainDatabase.movies.FirstOrDefaultAsync(x => x.Id == buyTicket.id);

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
        [Authorize]
        public async Task<IActionResult> EditBuyTicket(EditBuyTicket editBuyTicket)
        {
            var ticket = await this.mainDatabase.tickets.FindAsync(editBuyTicket.id);
            
            if(ticket == null)
            {
                return NotFound();
            }
            ticket.DateTime = editBuyTicket.Date + "," + editBuyTicket.Time;

            this.mainDatabase.Entry(ticket).State = EntityState.Modified;
            await this.mainDatabase.SaveChangesAsync();

            return Ok();
        }
    }
}
```

## Installation and Setup

To install and set up the Movie Ticketing Application Backend, follow these steps:

### Prerequisites

- .NET SDK
- SQL Server or any other compatible database
- Git

### Steps

1. **Clone the Repository**: Clone the project repository from GitHub.
   ```bash
   git clone https://github.com/sahanediriweera/WADbackend.git
   cd WADbackend
   ```

2. **Install Dependencies**: Navigate to the project directory and install the necessary dependencies.
   ```bash
   dotnet restore
   ```

3. **Update Database Connection**: Update the database connection string in the `appsettings.json` file.

4. **Run Migrations**: Apply the database migrations to set up the database schema.
   ```bash
   dotnet ef database update
   ```

5. **Run the Application**: Start the application using the `dotnet run` command.
   ```bash
   dotnet run
   ```

## Usage

- **User Registration**: Use the `/api/auth/register` endpoint to register a new user.
- **User Login**: Use the `/api/auth/login` endpoint to authenticate a user and obtain a JWT token.
- **Get Movies**: Use the `/api/movies` endpoint to retrieve a list of movies.
- **Add Movie**: Use the `/api/movies` endpoint to add a new movie (requires authentication).
- **Book Ticket**: Use the `/api/tickets` endpoint to book a ticket for a movie (requires authentication).

## Project Lead

- **Sahan Ediriweera**

We appreciate your interest and involvement in the development of this project!
