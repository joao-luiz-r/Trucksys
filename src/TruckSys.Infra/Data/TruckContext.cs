using Microsoft.EntityFrameworkCore;
using TruckSys.Entities;

namespace TruckSys.Infra.Data
{
    public class TruckContext : DbContext
    {

        public TruckContext(DbContextOptions<TruckContext> options) : base(options)
        {

        }

        public DbSet<Truck> Trucks {get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>().ToTable("Trucks");
        }
    }
}

