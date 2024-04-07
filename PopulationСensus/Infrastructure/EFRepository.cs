using Microsoft.EntityFrameworkCore;
using PopulationСensus.Data;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using System.Linq.Expressions;
//Репозиторий представляет собой концепцию хранения коллекции для сущностей определенного типа.
//Репозиторий — это коллекция. Коллекция, которая содержит сущности и
//может фильтровать и возвращать результат обратно в зависимости от
//требований вашего приложения. Где и как он хранит эти объекты является ДЕТАЛЬЮ РЕАЛИЗАЦИИ
namespace PopulationСensus.Infrastructure
{    //where T : Entity - ограничивает параметр типа T, требуя, чтобы он был типом, наследующимся от класса Entity.
    public class EFRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ELibraryContext context;

        public EFRepository(ELibraryContext context)
        {
            this.context = context;
        }

        //NotImplementedException пока не подерживается вызов  исключение
        public async Task<T> AddAsync(T entity)
        {
            //Устанавливает состояние сущности `entity` в `Added`,
            //что сигнализирует о том, что эта сущность должна быть добавлена в базу данных.
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
