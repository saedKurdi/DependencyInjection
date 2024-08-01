using aspTask3DependencyInjection.Entities.Concretes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspTask3DependencyInjection.Services.Interfaces
{
    public interface IFastFoodService
    {
        Task AddAsync(FastFood fastFood);
        Task RemoveAsync(FastFood fastFood);
        Task RemoveAsync(int id);
        Task UpdateAsync(FastFood fastFood);
        Task<FastFood> GetByIdAsync(int id);
        Task<ICollection<FastFood>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
