using Entities.DBModels.ExamModels;
using Entities.DBModels.StudentModels;

namespace Entities.DBModels.StudentExamModels
{
    public class StudentExam : BaseEntity
    {
        [ForeignKey(nameof(Exam))]
        [DisplayName(nameof(Exam))]
        public int Fk_Exam { get; set; }

        [DisplayName(nameof(Exam))]
        public Exam Exam { get; set; }

        [ForeignKey(nameof(Student))]
        [DisplayName(nameof(Student))]
        public int Fk_Student { get; set; }

        [DisplayName(nameof(Student))]
        public Student Student { get; set; }

        [DisplayName(nameof(QuestionCount))]
        public int QuestionCount { get; set; }

        [DisplayName(nameof(SuccessCount))]
        public int SuccessCount { get; set; }

        [DisplayName(nameof(FailedCount))]
        public int FailedCount => QuestionCount - SuccessCount;

        [DisplayName(nameof(StudentExamAnswers))]
        public List<StudentExamAnswer> StudentExamAnswers { get; set; }
    }
}
