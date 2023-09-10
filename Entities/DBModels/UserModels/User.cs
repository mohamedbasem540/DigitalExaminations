using Entities.DBModels.StudentModels;

namespace Entities.DBModels.UserModels
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User : BaseEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(FirstName))]
        public string FirstName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(LastName))]
        public string LastName { get; set; }

        [DisplayName(nameof(FullName))]
        public string FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(UserName))]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [PasswordPropertyText]
        [DisplayName(nameof(Password))]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName(nameof(EmailAddress))]
        [StringLength(100, ErrorMessage = PropertyAttributeConstants.StringLength100Msg)]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        [DisplayName(nameof(Student))]
        public Student Student { get; set; }

        [DisplayName(nameof(RefreshTokens))]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
