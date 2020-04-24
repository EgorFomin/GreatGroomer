using Great_Groomer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Great_Groomer.Database
{
    public class GreatGroomerDbContext : DbContext
    {
        public GreatGroomerDbContext() : base("name=GreatGroomerContext") 
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Groomer> Groomers { get; set; }
        public DbSet<GroomService> GroomServices { get; set; }
        public DbSet<GroomBooking> GroomBookings { get; set; }
        public DbSet<Species> Species { get; set; }
    }
}