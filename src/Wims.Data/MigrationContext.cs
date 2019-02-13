using Microsoft.EntityFrameworkCore;
using Wims.Data.Models;

namespace Wims.Data
{
    public class MigrationContext : DbContext
    {
        public DbSet<AddressDb> Addresses { get; set; }
        public DbSet<EventDb> Events { get; set; }
        public DbSet<LocationDb> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\wimsDev;Database=Wims-Migration;Trusted_Connection=True;");
        }
    }
}
