using System.ComponentModel.DataAnnotations;

namespace VotingAdmin.Web.Dtos.ResetPassword
{
    public class ResetPasswordDto
    {
        public int userId { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        public string newPassword { get; set; }
        [Required(ErrorMessage = "ConfirmPassword Is Required")]
        [Compare("newPassword")]
        public string confirmPassword { get; set; }
    }
}
