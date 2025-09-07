using DarthTV.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DarthTV.DB.Repositories
{
    public class BaseRepository<T> : IDbRepository<T>
        where T : BaseEntity
    {
        internal readonly Database _db;

        public BaseRepository(Database db)
        {
            _db = db;
        }

        public async Task<int> CreateAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            _db.SaveChanges();
            return entity.Id;
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            var results = _db.Set<T>().Where(predicate).ToList();
            return results;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var result = await _db.Set<T>().FindAsync(id);
            return result;
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
        }
    }
}
