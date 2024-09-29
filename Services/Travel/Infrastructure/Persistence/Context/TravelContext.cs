using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelWithMe.Travel.Domain.Entities;

namespace TravelWithMe.Travel.Persistence.Context
{
    public class TravelContext : DbContext
    {
        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {
        }

        public DbSet<TravelWithMe.Travel.Domain.Entities.Travel> Travels { get; set; }
        public DbSet<TravelDetail> TravelDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TravelWithMe.Travel.Domain.Entities.Travel>()
                .HasMany(x => x.TravelDetails)
                .WithOne(x => x.Travel)
                .HasForeignKey(x => x.TravelId);
        }
    }
}
