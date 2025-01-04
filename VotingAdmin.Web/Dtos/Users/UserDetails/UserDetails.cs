using System.ComponentModel.DataAnnotations;
using VotingAdmin.Web.Common.Paging;

namespace VotingAdmin.Web.Dtos.Users.UserDetails
{
    public class UsersList : PagedResponse<UserDetails>
    {

    }

    public enum Gender
    {
        Male = 1,
        Female,
        Others
    }

    public class UserDetails
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Fullname is required!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [MaxLength(10)]
        [MinLength(10, ErrorMessage = "Phone number cann't be less than 10 digit!")]
        [RegularExpression(@"[89]\d{9}$", ErrorMessage = "Please enter a valid Nepal phone number.")]

        public string Mobile { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Select Gender")]
        public int Gender { get; set; }
        public string Department { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string ProfileImagePath { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password Doesn't Match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public bool IsActive { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
