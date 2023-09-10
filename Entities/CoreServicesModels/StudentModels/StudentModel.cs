using Entities.CoreServicesModels.UserModels;
using Entities.RequestFeatures;

namespace Entities.CoreServicesModels.StudentModels
{
    public class StudentParameters : RequestParameters
    {
        public int Fk_User { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName(nameof(EmailAddress))]
        public string EmailAddress { get; set; }

        [DisplayName(nameof(SchoolName))]
        public string SchoolName { get; set; }

        [DisplayName(nameof(GradeName))]
        public string GradeName { get; set; }
    }

    public class StudentModel : BaseEntity
    {
        [ForeignKey(nameof(User))]
        [DisplayName(nameof(User))]
        public int Fk_User { get; set; }

        [DisplayName(nameof(User))]
        public UserModel User { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(100, ErrorMessage = PropertyAttributeConstants.StringLength100Msg)]
        [DisplayName(nameof(SchoolName))]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(GradeName))]
        public string GradeName { get; set; }
    }

    public class StudentCreateModel : UserCreateModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(100, ErrorMessage = PropertyAttributeConstants.StringLength100Msg)]
        [DisplayName(nameof(SchoolName))]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(GradeName))]
        public string GradeName { get; set; }
    }

    public class StudentEditModel : UserEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(100, ErrorMessage = PropertyAttributeConstants.StringLength100Msg)]
        [DisplayName(nameof(SchoolName))]
        public string SchoolName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(GradeName))]
        public string GradeName { get; set; }
    }
}
