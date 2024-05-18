using PopulationСensus.Domain.Entities;
using System.Linq.Expressions;

namespace PopulationСensus.Domain.Services
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> FindAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> FindWhere(Expression<Func<T, bool>> predicate);
        Task<List<int>> FindWhereId(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> FirstOrDefult(Expression<Func<T, bool>> predicate);
    }
}
