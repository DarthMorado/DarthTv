namespace DarthTV.DB.Entities.Tv
{
    public class TvEpisodeEntity : BaseEntity
    {
        public string Title { get; set; } // "Episode #3.2",
        public DateTime? Released { get; set; } // "Released": "2025-02-13",
        public int? EpisodeNumber { get; set; } // "Episode": "2",
        public double? imdbRating { get; set; } // "imdbRating": "N/A",
        public string imdbID { get; set; } // "imdbID": "tt31322395"
    }
}
