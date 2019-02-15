using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wims.Data.Models;

namespace Wims.Data
{
    public class DefaultContext : DbContext
    {
        public DbSet<AddressDb> Addresses { get; set; }
        public DbSet<EventDb> Events { get; set; }
        public DbSet<VenueDb> Venues { get; set; }
        public DbSet<SevadaarDb> Sevadaars { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options) { }

        public override int SaveChanges()
        {
            SetModifiedInformation();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            SetModifiedInformation();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetModifiedInformation()
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.Entity is BaseEntity entity)
                {
                    if (entity.createdDateUtc == null)
                        entity.createdDateUtc = DateTime.UtcNow;

                    entity.modifiedDateUtc = DateTime.UtcNow;
                }
            }
        }
    }
}
