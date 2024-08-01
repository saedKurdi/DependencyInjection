using aspTask3DependencyInjection.Contexts;
using aspTask3DependencyInjection.Entities.Abstracts.AbstractClasses;
using aspTask3DependencyInjection.Entities.Concretes;
using aspTask3DependencyInjection.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspTask3DependencyInjection.Repositories.Concretes
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseProductEntity, new()
    {
        private readonly FastFoodDbContext _context;
        private readonly DbSet<T> _table;

        public BaseRepository(FastFoodDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public BaseRepository() { }

        public async Task AddAsync(T entity)
        {
            // _context.Set<T>().Add(entity);
            await _table.AddAsync(entity);
        }

        public async Task<ICollection<FastFood>> GetAllAsync()
        {
            var list =  await _context.FastFoods.ToListAsync();
            return list;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            // return _context?.Set<T>().FirstOrDefault(a => a.Id == id);
            return await _table.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task RemoveAsync(T entity)
        {
            var aut = (_context?.Set<T>().FirstOrDefault(a => a.Id == entity.Id)) ?? throw new ArgumentNullException("Author is NULL");
            // _context?.Set<T>().Remove(aut);
            _table.Remove(entity);
        }

        public async Task RemoveAsync(int id)
        {
            var aut = (_context?.Set<T>().FirstOrDefault(a => a.Id == id)) ?? throw new ArgumentNullException("Author is NULL");
            // _context?.Set<T>().Remove(aut);
            _table.Remove(aut);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                // Attach the entity to the context and mark it as modified
                _context.Entry(entity).State = EntityState.Modified;

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error updating entity: {ex.Message}");
                throw;
            }
        }
    }
}
