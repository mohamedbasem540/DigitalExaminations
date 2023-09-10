using Entities.DBModels.StudentExamModels;

namespace Entities.DBModels.ExamModels
{
    public class Exam : BaseEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(100, ErrorMessage = PropertyAttributeConstants.StringLength100Msg)]
        [DisplayName(nameof(Name))]
        public string Name { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Instrucations))]
        [DataType(DataType.MultilineText)]
        public string Instrucations { get; set; }

        [DisplayName(nameof(IsPublished))]
        public bool IsPublished { get; set; }

        [DisplayName(nameof(Questions))]
        public List<Question> Questions { get; set; }

        [DisplayName(nameof(StudentExams))]
        public List<StudentExam> StudentExams { get; set; }
    }
}
