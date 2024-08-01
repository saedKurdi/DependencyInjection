using aspTask3DependencyInjection.Entities.Concretes;
using aspTask3DependencyInjection.Repositories.Interfaces;
using aspTask3DependencyInjection.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspTask3DependencyInjection.Services.Concretes
{
    public class FastFoodService : IFastFoodService
    {
        private readonly IBaseRepository<FastFood> _repository;

        // parametric constructor : 
        public FastFoodService(IBaseRepository<FastFood> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(FastFood fastFood)
        {
           await _repository.AddAsync(fastFood);
            await SaveChangesAsync();
        }

        public async Task<ICollection<FastFood>> GetAllAsync()
        {
           var allFastFoods = await _repository.GetAllAsync();
            return allFastFoods;
        }

        public async Task<FastFood> GetByIdAsync(int id)
        {
            var food = await _repository.GetByIdAsync(id);
            return food;
        }

        public async Task RemoveAsync(FastFood fastFood)
        {
            await _repository.RemoveAsync(fastFood);
           await SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
           await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(FastFood fastFood)
        {
            await _repository.UpdateAsync(fastFood);
        }
    }
}
