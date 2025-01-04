using System.ComponentModel.DataAnnotations;

namespace Voting.Core.Models.Merchants
{
    public class MerchantUpdate
    {
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Invalid Id.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MinLength(3, ErrorMessage = "Invalid email."), MaxLength(254, ErrorMessage = "Invalid email.")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Invalid GenderId.")]
        public int GenderId { get; set; }
        
        public string Department { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public IFormFile ProfileImage { get; set; }
        public bool IsActive { get; set; }
        public string PANNumber { get; set; }
        public string OrganizationName { get; set; }
        public string RegistrationNumber { get; set; }
        public string DirectorName { get; set; }
        public IFormFile PANDocument { get; set; }
    }
}
