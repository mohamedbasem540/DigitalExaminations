using Entities.ResponseFeatures;

namespace Entities.AuthenticationModels
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DataType(DataType.Password)]
        [DisplayName(nameof(OldPassword))]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DataType(DataType.Password)]
        [DisplayName(nameof(NewPassword))]
        public string NewPassword { get; set; }
    }

    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(UserName))]
        public string UserName { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DataType(DataType.Password)]
        [DisplayName(nameof(Password))]
        public string Password { get; set; }
    }

    public class UserAuthenticatedDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Fk_Student { get; set; }

        public TokenResponse Token { get; set; }
        public TokenResponse RefreshToken { get; set; }
    }
}
