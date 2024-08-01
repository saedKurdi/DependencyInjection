using aspTask3DependencyInjection.Contexts;
using aspTask3DependencyInjection.Entities.Concretes;
using aspTask3DependencyInjection.Repositories.Interfaces;

namespace aspTask3DependencyInjection.Repositories.Concretes
{
    public class FastFoodRepository : BaseRepository<FastFood>,IFastFoodRepository
    {
        public FastFoodRepository(FastFoodDbContext context) : base(context) { }
        public FastFoodRepository() : base() { }
    }
}
