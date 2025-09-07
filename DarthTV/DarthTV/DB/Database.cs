using DarthTV.DB.Entities.Admin;
using DarthTV.DB.Entities.Tv;
using Microsoft.EntityFrameworkCore;

namespace DarthTV.DB
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options)
            : base(options)
        {
        }

        public DbSet<ConfigurationEntity> Configurations { get; set; }

        public DbSet<TvCountryEntity> Countries { get; set; }
        public DbSet<TvGenreEntity> Genres { get; set; }
        public DbSet<TvItemEntity> Items { get; set; }
        public DbSet<TvLanguageEntity> Languages { get; set; }
        public DbSet<TvPersonEntity> People { get; set; }
        public DbSet<TvSeasonEntity> Seasons { get; set; }
        public DbSet<TvEpisodeEntity> Episodes { get; set; }
    }
}
