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
        public DbSet<User> User { get; set; }

        public DbSet<Project> Project { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        //}
    }
}