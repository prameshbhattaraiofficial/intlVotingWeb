namespace VotingAdmin.Web.Dtos.Merchants
{
    public class MerchantListItem
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public string Department { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string ProfileImagePath { get; set; }
        public string AccessCode { get; set; }
        public bool IsMerchant { get; set; }
        public string MerchantId { get; set; }
        public string PANNumber { get; set; }
        public string OrganizationName { get; set; }
        public string RegistrationNumber { get; set; }
        public string DirectorName { get; set; }
        public string PANDocumentPath { get; set; }
        public bool IsActive { get; set; }
    }
}
