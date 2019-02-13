using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wims.Data.Models;

namespace Wims.Data.Repositories
{
    public interface IAddressRepository
    {
        Task<AddressDb> GetAsync(int id);
        Task<ICollection<AddressDb>> GetAllAsync();
        Task<AddressDb> CreateAsync(AddressDb addressDb);
        Task<AddressDb> UpdateAsync(AddressDb addressDb);
        Task DeleteAsync(int id);
    }
}
