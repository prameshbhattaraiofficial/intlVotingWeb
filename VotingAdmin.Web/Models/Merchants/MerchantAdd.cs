using System.ComponentModel.DataAnnotations;

namespace VotingAdmin.Web.Models.Merchants
{
    public class MerchantAdd
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MinLength(3, ErrorMessage = "Invalid email."), MaxLength(254, ErrorMessage = "Invalid email.")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Invalid GenderId")]
        public int GenderId { get; set; }

        public string Department { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public IFormFile ProfileImage { get; set; }
        public string AccessCode { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        public string ConfirmPassword { get; set; }

        public bool IsActive { get; set; }
        public string PANNumber { get; set; }
        public string OrganizationName { get; set; }
        public string RegistrationNumber { get; set; }
        public string DirectorName { get; set; }
        public IFormFile PANDocument { get; set; }
    }
}
