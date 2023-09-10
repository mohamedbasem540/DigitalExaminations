using BaseDB;
using Microsoft.EntityFrameworkCore;
using ModelBuilderConfig.Configurations.ExamModels;

namespace DAL
{
    public class DBContext : BaseContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            _ = modelBuilder.ApplyConfiguration(new ExamConfiguration());
            _ = modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            _ = modelBuilder.ApplyConfiguration(new AnswerConfiguration());
        }
    }
}