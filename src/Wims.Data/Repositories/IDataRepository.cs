using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wims.Data.Repositories
{
    public interface IDataRepository<T>
    {
        Task<T> GetAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<T> CreateAsync(T dbEntity);
        Task<T> UpdateAsync(T dbEntity);
        Task DeleteAsync(int id);
    }
}
