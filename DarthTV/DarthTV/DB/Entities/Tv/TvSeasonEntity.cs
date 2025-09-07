using DarthTV.Classes.Obdm;

namespace DarthTV.DB.Entities.Tv
{
    public class TvSeasonEntity : BaseEntity
    {
        public List<TvEpisodeEntity> Episodes { get; set; } = new List<TvEpisodeEntity>();
        public string Title { get; set; } // "Title": "Game of Thrones",
        public int SeasonNumber { get; set; } // "Season": "1",
    }
}
