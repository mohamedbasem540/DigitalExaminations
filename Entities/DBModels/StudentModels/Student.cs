using Entities.DBModels.StudentExamModels;
using Entities.DBModels.UserModels;

namespace Entities.DBModels.StudentModels
{
    [Index(nameof(Fk_User), IsUnique = true)]
    public class Student : ImageEntity
    {
        [ForeignKey(nameof(User))]
        [DisplayName(nameof(User))]
        public int Fk_User { get; set; }

        [DisplayName(nameof(User))]
        public User User { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(100, ErrorMessage = PropertyAttributeConstants.StringLength100Msg)]
        [DisplayName(nameof(SchoolName))]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(GradeName))]
        public string GradeName { get; set; }

        [DisplayName(nameof(StudentExams))]
        public List<StudentExam> StudentExams { get; set; }
    }
}
