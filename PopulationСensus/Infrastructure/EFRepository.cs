using Microsoft.EntityFrameworkCore;
using PopulationСensus.Data;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using System.Linq.Expressions;

namespace PopulationСensus.Infrastructure
{   
    public class EFRepository<T> : IRepository<T> where T : Entity
    {
        private readonly СensusContext context;

        public EFRepository(СensusContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }     
        public async Task<T?> FindAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public async Task<T> FirstOrDefult(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task<List<T>> FindWhere(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<T> UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

    }
}
