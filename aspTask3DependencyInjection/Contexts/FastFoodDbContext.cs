using aspTask3DependencyInjection.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace aspTask3DependencyInjection.Contexts
{
    public class FastFoodDbContext : DbContext
    {
        // parametric constructor for db context ( initialize in startup ) :
        public FastFoodDbContext(DbContextOptions<FastFoodDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        // tables below : 
        public DbSet<FastFood> FastFoods { get; set; }
    }
}
