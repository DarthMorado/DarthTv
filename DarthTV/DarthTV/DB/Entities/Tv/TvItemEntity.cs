using DarthTV.Classes.Enums;
using DarthTV.Classes.Obdm;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DarthTV.DB.Entities.Tv
{
    public class TvItemEntity : BaseEntity
    {
        public DateTime Modified { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public int YearFrom { get; set; }
        public int YearTo { get; set; }
        public string Rated { get; set; }
        public DateTime? Released { get; set; }
        public int RuntimeMinutes { get; set; }
        public List<TvGenreEntity> Genres { get; set; }
        [ForeignKey("DirectorId")]
        public List<TvPersonEntity> Directors { get; set; }
        [ForeignKey("WriterId")]
        public List<TvPersonEntity> Writers { get; set; }
        [ForeignKey("ActorId")]
        public List<TvPersonEntity> Actors { get; set; }
        public string Plot { get; set; }
        public List<TvLanguageEntity> Languages { get; set; }
        public List<TvCountryEntity> Country { get; set; }
        public string Awards { get; set; }
        public string PosterUrl { get; set; }
        //"Ratings": [
        //],
        //public List<OmdbRatingSource> Ratings { get; set; }
        public double? Metascore { get; set; }
        public double? ImdbRating { get; set; }
        public string ImdbID { get; set; }
        public TvType Type { get; set; }
        public int? SeasonsCount { get; set; }
        //public string DVD { get; set; }
        //public string BoxOffice { get; set; }
        //public string Production { get; set; }
        //public string Website { get; set; }

        public List<TvSeasonEntity> Seasons { get; set; } = new List<TvSeasonEntity>();
     
    }
}
