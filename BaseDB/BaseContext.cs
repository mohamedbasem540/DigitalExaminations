using Entities.DBModels.ExamModels;
using Entities.DBModels.SharedModels;
using Entities.DBModels.StudentExamModels;
using Entities.DBModels.StudentModels;
using Entities.DBModels.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BaseDB
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        #region User 
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        #endregion

        #region Student 
        public DbSet<Student> Students { get; set; }
        #endregion

        #region Exam 
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Exam> Questions { get; set; }
        public DbSet<Exam> Answers { get; set; }
        #endregion

        #region Student Exam 
        public DbSet<StudentExam> StudentExams { get; set; }
        public DbSet<StudentExamAnswer> StudentExamAnswers { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
              .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity))))
            {
                _ = modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        _ = x.Property("CreatedAt")
                            .HasDefaultValueSql("getutcdate()");
                    });
            }

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
               .Where(t => t.ClrType.IsSubclassOf(typeof(AuditEntity))))
            {
                _ = modelBuilder.Entity(
                    entityType.Name,
                    x =>
                    {
                        _ = x.Property("LastModifiedAt")
                            .HasDefaultValueSql("getutcdate()");
                    });
            }
        }
    }
}