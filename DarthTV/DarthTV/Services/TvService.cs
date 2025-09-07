using DarthTV.Classes.Obdm;
using DarthTV.DB.Entities.Tv;
using DarthTV.DB.Repositories;

namespace DarthTV.Services
{
    public interface ITvService
    {
        TvEpisodeEntity ConvertFromOmbd(OmdbEpisode season);
        TvSeasonEntity ConvertFromOmbd(OmdbSeason season);
        TvItemEntity ConvertFromOmdb(OmdbFullItem item);

        Task<List<TvItemEntity>> SearchAsync(string searchString);
        Task<TvItemEntity> GetById(int id);
        Task<TvItemEntity> GetByImdbId(string id);
    }

    public class TvService : ITvService
    {
        private readonly IDbRepository<TvGenreEntity> _genresRepository;
        private readonly ITvItemRepository _repository;
        private readonly IOmdbService _omdbService;

        public TvService(//IDbRepository<TvGenreEntity> genresRepository,
            IOmdbService omdbService,
            ITvItemRepository repository)
        {
            _repository = repository;
            _omdbService = omdbService;
        }

        public async Task<List<TvItemEntity>> SearchAsync(string searchString)
        {
            var results = new List<TvItemEntity>();
            // Try search db

            //Search Online OMDB
            var fastResults = _omdbService.Search(searchString);

            if (fastResults is null || fastResults.totalResults == 0)
            {
                return results;
            }

            foreach (var fastResult in fastResults.Search)
            {
                var imdbId = fastResult.imdbID;
                var item = await GetByImdbId(imdbId);
                if (item is not null)
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public async Task<TvItemEntity> GetById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item;
        }

        public async Task<TvItemEntity> GetByImdbId(string imdbId)
        {
            if (String.IsNullOrWhiteSpace(imdbId))
            {
                return null;
            }

            // Search in DB
            var item = _repository.GetByImdbId(imdbId);
            if (item is not null)
            {
                return item;
            }

            // Search in OMDB
            var fullOmdbInfo = _omdbService.GetOmdbInfo(imdbId);
            var newItem = ConvertFromOmdb(fullOmdbInfo);
            await _repository.CreateAsync(newItem);

            return newItem;
        }

        public TvItemEntity ConvertFromOmdb(OmdbFullItem item)
        {
            var result = new TvItemEntity();

            int intValue;
            DateTime dateValue;
            List<string>? parts;

            result.Title = item.Title;

            if (!String.IsNullOrWhiteSpace(item.Year))
            {
                item.Year = item.Year.Trim();
                if (int.TryParse(item.Year, out intValue))
                {
                    result.Year = intValue;
                }
                else if (item.Year.Contains('-'))
                {
                    //"Year": "2005–2017",
                    parts = item.Year.Split('-').Where(x => !String.IsNullOrWhiteSpace(x)).ToList();
                    parts.Sort();
                    if (int.TryParse(parts[0], out intValue))
                    {
                        result.YearFrom = intValue;
                    }
                    if (parts.Count > 1 && int.TryParse(parts[1], out intValue))
                    {
                        result.YearTo = intValue;
                    }
                }
            }

            result.Rated = item.Rated;

            if (DateTime.TryParse(item.Released, out dateValue))
            {
                result.Released = dateValue;
            }

            if (!String.IsNullOrWhiteSpace(item.Runtime))
            {
                parts = item.Runtime.Split(' ').Where(x => !String.IsNullOrWhiteSpace(x)).ToList();
                if (parts.Count > 1 && parts[1].ToLower() == "min")
                {
                    if (int.TryParse(parts[0], out intValue))
                    {
                        result.RuntimeMinutes = intValue;
                    }
                }
            }

            if (!String.IsNullOrWhiteSpace(item.Genre))
            {
                //"Genre": "Adventure, Drama, Fantasy",
                parts = item.Genre.Split(new char[] { ' ', ',' }).Where(x => !String.IsNullOrWhiteSpace(x)).ToList();
                result.Genres = new List<TvGenreEntity>();

            }

            result.PosterUrl = item.Poster;

            result.Genres = new();
            result.Directors = new();
            result.Writers = new();
            result.Actors = new();
            
            result.Plot = item.Plot;
            result.Languages = new();
            result.Country = new();
            result.Awards = "";

            //result.Ratings = null;
            result.Metascore = null;
            result.ImdbRating = null;
            result.ImdbID = item.imdbID;
            if (!String.IsNullOrWhiteSpace(item.Type))
            {
                if (item.Type.ToLower() == "movie")
                {
                    result.Type = Classes.Enums.TvType.Movie;
                }
                else if (item.Type.ToLower() == "series")
                {
                    result.Type = Classes.Enums.TvType.Series;
                }
                else
                {
                    result.Type = Classes.Enums.TvType.Unknown;
                }
            }
            else
            {
                result.Type = Classes.Enums.TvType.Unknown;
            }
            
            result.SeasonsCount = null;
            //result.DVD = null;
            //result.BoxOffice = null;
            //result.Production = null;
            //result.Website = null;

            result.Modified = DateTime.UtcNow;

            return result;
        }

        public TvEpisodeEntity ConvertFromOmbd(OmdbEpisode season)
        {
            if (season is null)
            {
                return null;
            }
            var result = new TvEpisodeEntity()
            {
                Title = season.Title,
                imdbID = season.imdbID
            };

            if (int.TryParse(season.Episode, out var intEpisode))
            {
                result.EpisodeNumber = intEpisode;
            }
            
            if (DateTime.TryParse(season.Released, out var dateReleased))
            {
                result.Released = dateReleased;
            }
            
            if (double.TryParse(season.imdbRating, out var dblRating))
            {
                result.imdbRating = dblRating;
            }
            
            return result;
        }

        public TvSeasonEntity ConvertFromOmbd(OmdbSeason season)
        {
            var result = new TvSeasonEntity()
            {
                Title = season.Title
            };

            if (int.TryParse(season.Season, out var intSeason))
            {
                result.SeasonNumber = intSeason;
            }

            if (season.Episodes is not null && season.Episodes.Any())
            {
                result.Episodes = season.Episodes.Select(x => ConvertFromOmbd(x)).ToList();
            }

            return result;
        }
    }
}
