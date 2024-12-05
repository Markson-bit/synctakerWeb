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
        public DbSet<TaskModel> TaskModel { get; set; }
        public DbSet<Status> Status { get; set; }

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

            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.Project)
                .WithMany()
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey(t => t.StatusId);

            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.AssignedTo)
                .WithMany()
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.Reviewer)
                .WithMany()
                .HasForeignKey(t => t.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.Tester)
                .WithMany()
                .HasForeignKey(t => t.TestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
    //}
}