using ActiveCitizens.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveCitizens.Core
{
    public class ActiveCitizensContext : DbContext
    {
        private const string dbConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=ActiveCitizens;Trusted_Connection=True;";
        
        public DbSet<Marker> Markers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

    }
}
