using aspTask3DependencyInjection.Entities.Abstracts.AbstractClasses;
using aspTask3DependencyInjection.Entities.Concretes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspTask3DependencyInjection.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseProductEntity,new()
    {
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveAsync(int id);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<ICollection<FastFood>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
