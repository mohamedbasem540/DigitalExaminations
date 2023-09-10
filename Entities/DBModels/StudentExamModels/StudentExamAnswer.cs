using Entities.DBModels.ExamModels;

namespace Entities.DBModels.StudentExamModels
{
    public class StudentExamAnswer : BaseEntity
    {
        [ForeignKey(nameof(StudentExam))]
        [DisplayName(nameof(StudentExam))]
        public int Fk_StudentExam { get; set; }

        [DisplayName(nameof(StudentExam))]
        public StudentExam StudentExam { get; set; }

        [ForeignKey(nameof(Question))]
        [DisplayName(nameof(Question))]
        public int Fk_Question { get; set; }

        [DisplayName(nameof(Question))]
        public Question Question { get; set; }

        [ForeignKey(nameof(Answer))]
        [DisplayName(nameof(Answer))]
        public int Fk_Answer { get; set; }

        [DisplayName(nameof(Answer))]
        public Answer Answer { get; set; }

        [DisplayName(nameof(IsCorrect))]
        public bool IsCorrect { get; set; }
    }
}
