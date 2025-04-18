using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMvcExamProject.Models;

namespace MyMvcExamProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Book-Question relationship (One-to-Many)
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasOne(q => q.Book)
                      .WithMany(b => b.Questions)
                      .HasForeignKey(q => q.BookId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Question-Option relationship (One-to-Many)
            modelBuilder.Entity<Option>(entity =>
            {
                entity.HasOne(o => o.Question)
                      .WithMany(q => q.Options)
                      .HasForeignKey(o => o.QuestionId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ExamResult relationships
            modelBuilder.Entity<ExamResult>(entity =>
            {
                entity.HasOne(er => er.Book)
                      .WithMany(b => b.ExamResults)
                      .HasForeignKey(er => er.BookId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(er => er.User)
                      .WithMany(u => u.ExamResults)
                      .HasForeignKey(er => er.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}