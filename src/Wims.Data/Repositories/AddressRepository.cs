using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wims.Data.Models;

namespace Wims.Data.Repositories
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(DbContext defaultContext) : base(defaultContext)
        {
        }

        public async Task<AddressDb> CreateAsync(AddressDb addressDb)
        {
            if (addressDb == null)
            {
                throw new ArgumentNullException(nameof(addressDb));
            }

            await Context.AddAsync(addressDb);
            await Context.SaveChangesAsync();
            return addressDb;
        }

        public async Task<ICollection<AddressDb>> GetAllAsync()
        {
            return await Context.Query<AddressDb>().ToListAsync();
        }

        public async Task<AddressDb> GetAsync(int id)
        {
            return await Context.Query<AddressDb>().SingleAsync(x => x.Id == id);
        }

        public async Task<AddressDb> UpdateAsync(AddressDb addressDb)
        {
            if (addressDb == null)
            {
                throw new ArgumentNullException(nameof(addressDb));
            }

            Context.Update(addressDb);
            await Context.SaveChangesAsync();
            return addressDb;
        }

        public async Task DeleteAsync(int id)
        {
            var toDelete = new AddressDb { Id = id };
            Context.Remove(toDelete);
            await Context.SaveChangesAsync();
        }
    }
}
