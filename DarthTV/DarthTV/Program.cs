using DarthTV.Classes.Options;
using DarthTV.DB.Repositories;
using DarthTV.Services;
using Microsoft.EntityFrameworkCore;

namespace DarthTV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DarthTV.DB.Database>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            ConfigureServices(builder.Services);
            ConfigureOptions(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IOmdbService, OmdbService>();
            services.AddTransient<ITvService, TvService>();

            services.AddTransient<ITvItemRepository, TvItemRepository>();
            services.AddScoped(typeof(IDbRepository<>), typeof(BaseRepository<>));


        }

        private static void ConfigureOptions(IServiceCollection services, ConfigurationManager config)
        {
            services.Configure<OmdbOptions>(config.GetSection(nameof(OmdbOptions)));
        }
    }
}
