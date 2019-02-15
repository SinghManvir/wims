using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wims.Data.Models;

namespace Wims.Data.Repositories
{
    public class VenueRepository : BaseRepository, IVenueRepository
    {
        public VenueRepository(DbContext defaultContext) : base(defaultContext)
        {
        }

        public async Task<VenueDb> CreateAsync(VenueDb venueDb)
        {
            if (venueDb == null)
            {
                throw new ArgumentNullException(nameof(venueDb));
            }

            await Context.AddAsync(venueDb);
            await Context.SaveChangesAsync();
            return venueDb;
        }

        public async Task DeleteAsync(int id)
        {
            var toDelete = new VenueDb { Id = id };
            Context.Remove(toDelete);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<VenueDb>> GetAllAsync()
        {
            return await GetQueryableWithIncludes().ToListAsync();
        }

        public async Task<VenueDb> GetAsync(int id)
        {
            return await GetQueryableWithIncludes().SingleAsync(x => x.Id == id);
        }

        public async Task<VenueDb> UpdateAsync(VenueDb venueDb)
        {
            if (venueDb == null)
            {
                throw new ArgumentNullException(nameof(venueDb));
            }

            Context.Update(venueDb);
            await Context.SaveChangesAsync();
            return venueDb;
        }

        private IQueryable<VenueDb> GetQueryableWithIncludes()
        {
            return Context.Set<VenueDb>().Include(x => x.Address);
        }
    }
}
