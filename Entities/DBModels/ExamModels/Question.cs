using Entities.DBModels.StudentExamModels;
using static Entities.EnumData.DBEnum;

namespace Entities.DBModels.ExamModels
{
    public class Question : ImageEntity
    {
        [ForeignKey(nameof(Exam))]
        [DisplayName(nameof(Exam))]
        public int Fk_Exam { get; set; }

        [DisplayName(nameof(Exam))]
        public Exam Exam { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(QuestionText))]
        [DataType(DataType.MultilineText)]
        public string QuestionText { get; set; }

        [DisplayName(nameof(QuestionType))]
        public QuestionTypeEnum QuestionType { get; set; }

        [DisplayName(nameof(Answers))]
        public List<Answer> Answers { get; set; }

        [DisplayName(nameof(StudentExamAnswers))]
        public List<StudentExamAnswer> StudentExamAnswers { get; set; }
    }
}
