using Microsoft.EntityFrameworkCore;
using Wims.Data.Models;

namespace Wims.Data
{
    public class DefaultContext : DbContext
    {
        public DbSet<AddressDb> Addresses { get; set; }
        public DbSet<EventDb> Events { get; set; }
        public DbSet<LocationDb> Locations { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options) { }
    }
}
