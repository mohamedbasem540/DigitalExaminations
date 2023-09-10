using Entities.DBModels.ExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModelBuilderConfig.Configurations.ExamModels
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            #region Exam 1

            #region multiple choice

            _ = builder.HasData(new Answer
            {
                Id = 1,
                Fk_Question = 1,
                AnswerText = "This is a test answer 1",
                IsCorrect = true
            });
            _ = builder.HasData(new Answer
            {
                Id = 2,
                Fk_Question = 1,
                AnswerText = "This is a test answer 2",
            });
            _ = builder.HasData(new Answer
            {
                Id = 3,
                Fk_Question = 1,
                AnswerText = "This is a test answer 3",
            });
            _ = builder.HasData(new Answer
            {
                Id = 4,
                Fk_Question = 1,
                AnswerText = "This is a test answer 4",
            });

            #endregion

            #region true/false

            _ = builder.HasData(new Answer
            {
                Id = 5,
                Fk_Question = 2,
                AnswerText = "True",
                IsCorrect = true
            });
            _ = builder.HasData(new Answer
            {
                Id = 6,
                Fk_Question = 2,
                AnswerText = "False",
            });

            #endregion

            #region fill in the blank

            _ = builder.HasData(new Answer
            {
                Id = 7,
                Fk_Question = 3,
                AnswerText = "This is a test answer 1",
                IsCorrect = true
            });
            _ = builder.HasData(new Answer
            {
                Id = 8,
                Fk_Question = 3,
                AnswerText = "This is a test answer 2",
            });
            _ = builder.HasData(new Answer
            {
                Id = 9,
                Fk_Question = 3,
                AnswerText = "This is a test answer 3",
            });
            #endregion

            #region essay

            _ = builder.HasData(new Answer
            {
                Id = 10,
                Fk_Question = 4,
                AnswerText = "Yes",
                IsCorrect = true
            });
            _ = builder.HasData(new Answer
            {
                Id = 11,
                Fk_Question = 4,
                AnswerText = "No",
            });
            #endregion

            #endregion
        }
    }
}
