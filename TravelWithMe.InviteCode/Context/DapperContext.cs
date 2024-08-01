using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace TravelWithMe.InviteCode.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.InviteCode>(entity =>
            {
                entity.HasKey(e => e.InviteCodeId);
                entity.Property(e => e.InviteCodeId).ValueGeneratedOnAdd();
                entity.Property(e => e.Code).HasMaxLength(255).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.EventId).IsRequired();
                entity.Property(e => e.IsActive).HasConversion(
                    v => v ? 1 : 0,
                    v => v == 1
                ).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
                entity.Property(e => e.ValidDate);
            });
        }

        public DbSet<Entities.InviteCode> InviteCodes { get; set; }

        public IDbConnection CreateConnection() => new OracleConnection(_connectionString);
    }
}
