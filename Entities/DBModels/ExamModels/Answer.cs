using Entities.DBModels.StudentExamModels;

namespace Entities.DBModels.ExamModels
{
    public class Answer : ImageEntity
    {
        [ForeignKey(nameof(Question))]
        [DisplayName(nameof(Question))]
        public int Fk_Question { get; set; }

        [DisplayName(nameof(Question))]
        public Question Question { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(AnswerText))]
        [DataType(DataType.MultilineText)]
        public string AnswerText { get; set; }

        [DisplayName(nameof(IsCorrect))]
        public bool IsCorrect { get; set; }

        [DisplayName(nameof(StudentExamAnswers))]
        public List<StudentExamAnswer> StudentExamAnswers { get; set; }
    }
}
