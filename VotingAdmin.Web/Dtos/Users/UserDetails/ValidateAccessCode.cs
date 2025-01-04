using System.ComponentModel.DataAnnotations;

namespace VotingAdmin.Web.Dtos.Users.UserDetails
{
    public class ValidateAccessCode
    {
        public string accessCode { get; set; }
    }
    public class ChangeAccessCode
    {
        [Required(ErrorMessage = "Enter Your Password.")]
        [DataType(DataType.Password)]
        public string currentPassword { get; set; }
        [Required(ErrorMessage = "Enter Access Code")]
        [DataType(DataType.Password)]
        public string newPIN { get; set; }

        [Compare(nameof(newPIN), ErrorMessage = "Access Code Doesnot Match.")]
        [DataType(DataType.Password)]
        public string confirmPIN { get; set; }
    }
}
