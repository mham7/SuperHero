﻿global using Microsoft.EntityFrameworkCore;
namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server= .\\SQLEXPRESS;Database=superherodb;Trusted_Connection=true;MultipleActiveResultSets=True; TrustServerCertificate=true; ");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }

    }
}
