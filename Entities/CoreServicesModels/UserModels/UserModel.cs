using Entities.RequestFeatures;

namespace Entities.CoreServicesModels.UserModels
{
    public class UserParameters : RequestParameters
    {
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName(nameof(EmailAddress))]
        public string EmailAddress { get; set; }

        [DisplayName(nameof(CreatedAtFrom))]
        public DateTime? CreatedAtFrom { get; set; }

        [DisplayName(nameof(CreatedAtTo))]
        public DateTime? CreatedAtTo { get; set; }
    }

    public class UserModel : BaseEntity
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
        public string FullName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(UserName))]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName(nameof(EmailAddress))]
        [StringLength(100, ErrorMessage = PropertyAttributeConstants.StringLength100Msg)]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }
    }

    public class UserCreateModel : UserEditModel
    {
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        [DisplayName(nameof(Password))]
        public string Password { get; set; }
    }

    public class UserEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(FirstName))]
        public string FirstName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(LastName))]
        public string LastName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [StringLength(50, ErrorMessage = PropertyAttributeConstants.StringLength50Msg)]
        [DisplayName(nameof(UserName))]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName(nameof(EmailAddress))]
        [StringLength(100, ErrorMessage = PropertyAttributeConstants.StringLength100Msg)]
        public string EmailAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }
    }

}
