using GymFitnessGuide.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymFitnessGuide.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Profile> Profiles { get; set; } = null!;
        public DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public DbSet<TestQuestion> TestQuestions { get; set; } = null!;
        public DbSet<TestAnswer> TestAnswers { get; set; } = null!;
        public DbSet<Recommendation> Recommendations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-Many Users and Profiles
            modelBuilder.Entity<UserProfile>()
                .HasKey(up => new { up.UserId, up.ProfileId });

            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProfiles)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserProfile>()
                .HasOne(up => up.Profile)
                .WithMany(p => p.UserProfiles)
                .HasForeignKey(up => up.ProfileId);

            // One-to-Many TestQuestion and TestAnswer
            modelBuilder.Entity<TestAnswer>()
                .HasOne(ta => ta.Question)
                .WithMany(tq => tq.TestAnswers)
                .HasForeignKey(ta => ta.QuestionId);

            // One-to-Many User and TestAnswer
            modelBuilder.Entity<TestAnswer>()
                .HasOne(ta => ta.User)
                .WithMany(u => u.TestAnswers)
                .HasForeignKey(ta => ta.UserId);

            // One-to-Many Profile and Recommendation
            modelBuilder.Entity<Recommendation>()
                .HasOne(r => r.Profile)
                .WithMany(p => p.Recommendations)
                .HasForeignKey(r => r.ProfileId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
