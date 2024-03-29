﻿using Microsoft.EntityFrameworkCore;
using WADbackend.Models;

namespace WADbackend
{
    public class MainDatabase:DbContext 
    {
        public MainDatabase(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public MainDatabase()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Seller> sellers { get; set; }

        public DbSet<Buyer> buyers { get; set; }

        public DbSet<Ticket> tickets { get; set; }

        public DbSet<Movie> movies { get; set; }
    }
}
