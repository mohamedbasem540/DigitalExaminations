using Entities.DBModels.ExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Entities.EnumData.DBEnum;

namespace ModelBuilderConfig.Configurations.ExamModels
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            #region Exam 1

            #region multiple choice

            _ = builder.HasData(new Question
            {
                Id = 1,
                Fk_Exam = 1,
                QuestionText = "This is a test (multiple choice) question",
                QuestionType = QuestionTypeEnum.MultipleChoice
            });

            #endregion

            #region true/false

            _ = builder.HasData(new Question
            {
                Id = 2,
                Fk_Exam = 1,
                QuestionText = "This is a test (true, false) question 2",
                QuestionType = QuestionTypeEnum.TrueFalse
            });

            #endregion

            #region fill in the blank

            _ = builder.HasData(new Question
            {
                Id = 3,
                Fk_Exam = 1,
                QuestionText = "This is a test (fill in the blank) question, .....",
                QuestionType = QuestionTypeEnum.FillInTheBlank
            });

            #endregion

            #region essay

            _ = builder.HasData(new Question
            {
                Id = 4,
                Fk_Exam = 1,
                QuestionText = "This is a test (essay) question," +
                "Do you agree or disagree with the following statement?",
                QuestionType = QuestionTypeEnum.Essay
            });

            #endregion

            #endregion
        }
    }
}
