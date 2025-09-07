using DarthTV.DB.Entities;
using System.Linq.Expressions;

namespace DarthTV.DB.Repositories
{
    public interface IDbRepository<T> where T : BaseEntity
    {
        // Basic operations
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Add and update
        Task<int> CreateAsync(T entity);
        void Update(T entity);

        // Delete
        void Delete(T entity);

        // Save changes
        Task<int> SaveChangesAsync();
    }
}
