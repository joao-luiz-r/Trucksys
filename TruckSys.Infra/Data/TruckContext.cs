using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
