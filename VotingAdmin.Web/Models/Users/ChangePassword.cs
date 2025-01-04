using System.ComponentModel.DataAnnotations;

namespace VotingAdmin.Web.Models.Users
{
    public class ChangePassword
    {
        [DataType(DataType.Password)]
        [Required]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Not Strong Password")]

        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }
    }
}
