using Entities.CoreServicesModels.ExamModels;
using Entities.RequestFeatures;

namespace Entities.CoreServicesModels.StudentExamModels
{
    public class StudentExamAnswerParameters : RequestParameters
    {

    }

    public class StudentExamAnswerModel : BaseEntity
    {
        [ForeignKey(nameof(StudentExam))]
        [DisplayName(nameof(StudentExam))]
        public int Fk_StudentExam { get; set; }

        [DisplayName(nameof(StudentExam))]
        public StudentExamModel StudentExam { get; set; }

        [ForeignKey(nameof(Question))]
        [DisplayName(nameof(Question))]
        public int Fk_Question { get; set; }

        [DisplayName(nameof(Question))]
        public QuestionModel Question { get; set; }

        [ForeignKey(nameof(Answer))]
        [DisplayName(nameof(Answer))]
        public int Fk_Answer { get; set; }

        [DisplayName(nameof(Answer))]
        public AnswerModel Answer { get; set; }

        [DisplayName(nameof(IsCorrect))]
        public bool IsCorrect { get; set; }
    }
}
