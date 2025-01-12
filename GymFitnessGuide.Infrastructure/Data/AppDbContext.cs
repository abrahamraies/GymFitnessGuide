using GymFitnessGuide.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymFitnessGuide.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<UserCategory> UserCategories { get; set; } = null!;
        public DbSet<TestQuestion> TestQuestions { get; set; } = null!;
        public DbSet<TestAnswer> TestAnswers { get; set; } = null!;
        public DbSet<Recommendation> Recommendations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-Many Users and Categories
            modelBuilder.Entity<UserCategory>()
                .HasKey(up => new { up.UserId, up.CategoryId });

            modelBuilder.Entity<UserCategory>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserCategories)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<UserCategory>()
                .HasOne(up => up.Category)
                .WithMany(p => p.UserCategories)
                .HasForeignKey(up => up.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many TestQuestion and TestAnswer
            modelBuilder.Entity<TestAnswer>()
                .HasOne(ta => ta.Question)
                .WithMany(tq => tq.TestAnswers)
                .HasForeignKey(ta => ta.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many Category and TestQuestion
            modelBuilder.Entity<TestQuestion>()
                .HasOne(q => q.Category)
                .WithMany(c => c.TestQuestions)
                .HasForeignKey(q => q.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many User and TestAnswer
            modelBuilder.Entity<TestAnswer>()
                .HasOne(ta => ta.User)
                .WithMany(u => u.TestAnswers)
                .HasForeignKey(ta => ta.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many Category and Recommendation
            modelBuilder.Entity<Recommendation>()
                .HasOne(r => r.Category)
                .WithMany(p => p.Recommendations)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
