using DarthTV.DB.Entities.Tv;

namespace DarthTV.DB.Repositories
{
    public interface ITvItemRepository : IDbRepository<TvItemEntity>
    {
        public TvItemEntity GetByImdbId(string imdbId);
    }

    public class TvItemRepository : BaseRepository<TvItemEntity>, ITvItemRepository
    {
        public TvItemRepository(Database db)
            :base(db)
        {
            
        }
        public TvItemEntity GetByImdbId(string imdbId)
        {
            var results = _db.Set<TvItemEntity>().Where(x => x.ImdbID == imdbId)?.ToList();
            if (results is not null && results.Any())
            {
                return results.First();
            }
            return null;
        }
    }
}
