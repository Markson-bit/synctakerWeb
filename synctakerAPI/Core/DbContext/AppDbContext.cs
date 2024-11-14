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
        public DbSet<Project2User> Project2User { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project2User>()
                .HasKey(pu => new { pu.ProjectId, pu.UserId });

            modelBuilder.Entity<Project2User>()
                .HasOne(pu => pu.Project)
                .WithMany(p => p.ProjectUsers)
                .HasForeignKey(pu => pu.ProjectId);

            modelBuilder.Entity<Project2User>()
                .HasOne(pu => pu.User)
                .WithMany(u => u.ProjectUsers)
                .HasForeignKey(pu => pu.UserId);
        }
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    //}
}