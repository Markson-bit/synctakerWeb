using Microsoft.EntityFrameworkCore;

namespace synctakerAPI.Core
{
    public class AppDbContext : DbContext
    {
        //public IConfiguration _config { get; set; }
        //public AppDbContext(IConfiguration config)
        //{
        //    _config = config;
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        //}

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
