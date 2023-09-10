using Entities.DBModels.ExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModelBuilderConfig.Configurations.ExamModels
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            _ = builder.HasData(new Exam
            {
                Id = 1,
                Name = "Test Exam 1",
                Instrucations = "This is a test exam",
                IsPublished = true,
            });
        }
    }
}
