using System.ComponentModel.DataAnnotations;

namespace VotingAdmin.Web.Dtos.Auth
{
    public class MerchantLoginRequest
    {
        [Required]
        public string GrantType { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string RefreshToken { get; set; }
    }
}
