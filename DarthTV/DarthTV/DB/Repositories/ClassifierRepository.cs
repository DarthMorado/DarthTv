using DarthTV.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DarthTV.DB.Repositories
{
    public interface IClassifierRepository<T> : IDbRepository<T>
        where T : ClassifierEntity
    {
        public Task<T> FindByValue(string value);
    }

    public class ClassifierRepository<T> : BaseRepository<T>, IClassifierRepository<T>
        where T : ClassifierEntity
    {
        public ClassifierRepository(Database db)
            : base(db)
        {
            
        }

        public async Task<T> FindByValue(string value)
        {
            var results = await base._db.Set<T>().Where(x => x.Value == value).ToListAsync();
            if (results != null && results.Any())
            {
                return results.First();
            }
            return null; 
        }
    }
}
