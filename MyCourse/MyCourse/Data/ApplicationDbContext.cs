using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCourse.Models;


namespace MyCourse.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }


        public DbSet<Tutor> Tutors { get; set; }

        public DbSet<Level>Levels { get; set; }

        public DbSet<Benefit> Benefits { get; set; }

        public Background Background { get; set; }

        public DbSet<Background> Backgrounds { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity(typeof(Country)).HasData(
                 new Country { Id = 1, Name = "Azerbaijan" },
                 new Country { Id = 2, Name = "Turkey" },
                 new Country { Id = 3, Name = "usa" }
                );

            builder.Entity(typeof(City)).HasData(
               new City { Id = 1, Name = "baku" ,CountryId=1},
               new City { Id = 2, Name = "sumqayit", CountryId=1},
               new City { Id = 3, Name = "istanbul" ,CountryId=2},
               new City { Id=4, Name = "ankara", CountryId = 2 },
               new City { Id = 5, Name = "Memfis", CountryId = 3 },
               new City { Id = 6, Name = "Manhetten", CountryId = 3 },
               new City { Id = 7, Name = "vashington", CountryId = 3 },
               new City { Id = 8, Name = "Detroit", CountryId = 3 }
              ); 
        }



    }
}
