using Entities.CoreServicesModels.ExamModels;
using Entities.CoreServicesModels.StudentModels;
using Entities.DBModels.ExamModels;
using Entities.DBModels.StudentModels;
using Entities.RequestFeatures;

namespace Entities.CoreServicesModels.StudentExamModels
{
    public class StudentExamParameters : RequestParameters
    {
        [ForeignKey(nameof(Exam))]
        [DisplayName(nameof(Exam))]
        public int Fk_Exam { get; set; }

        [ForeignKey(nameof(Student))]
        [DisplayName(nameof(Student))]
        public int Fk_Student { get; set; }

        public bool IncludeAnswers { get; set; }
    }

    public class StudentExamModel : BaseEntity
    {
        [ForeignKey(nameof(Exam))]
        [DisplayName(nameof(Exam))]
        public int Fk_Exam { get; set; }

        [DisplayName(nameof(Exam))]
        public ExamModel Exam { get; set; }

        [ForeignKey(nameof(Student))]
        [DisplayName(nameof(Student))]
        public int Fk_Student { get; set; }

        [DisplayName(nameof(Student))]
        public StudentModel Student { get; set; }

        [DisplayName(nameof(QuestionCount))]
        public int QuestionCount { get; set; }

        [DisplayName(nameof(SuccessCount))]
        public int SuccessCount { get; set; }

        [DisplayName(nameof(FailedCount))]
        public int FailedCount { get; set; }

        [DisplayName(nameof(StudentExamAnswers))]
        public List<StudentExamAnswerModel> StudentExamAnswers { get; set; }
    }
}
