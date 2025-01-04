using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Users.UserDetails;
using VotingAdmin.Web.Models.ResetPassword;
using VotingAdmin.Web.Models.Roles;
using VotingAdmin.Web.Models.Users;

namespace VotingAdmin.Web.Data.Repository.Users
{
    public interface IUsersRepo
    {
        Task<BaseDgApiResponse<UsersList>> GetAllUsersAsync(UserListRequest request);
        Task<BaseDgApiResponse<UserDetails>> GetUserById(int Id);
        Task<BaseDgApiResponse<UserDetailsmdl>> AddUsers(UserDetailsmdl userDetails);
        Task<BaseDgApiResponse<UpdateUserDetails>> EditUsers(UpdateUserDetails userDetails);
        Task<BaseDgApiResponse<UserDetails>> RemoveUsers(int id);
        Task<BaseDgApiResponse<UserDetailsmdl>> AssignUserRole(int userid, int[] roleid);
        Task<BaseDgApiResponse<UsersRoleResponse>> GetUserRole(int userid);
        Task<BaseDgApiResponse<ResetPassword>> ResetUserPassword(ResetPassword resetPassword);
        Task<BaseDgApiResponse<string>> MerchantChangePasswordAsync(ChangePassword changePassword);
        Task<BaseDgApiResponse<string>> UserChangePasswordAsync(ChangePassword changePassword);
        Task<BaseDgApiResponse<string>> ChangePasswordAsync(ChangePassword changePassword);
        Task<BaseDgApiResponse<string>> ChangeAccessCodeAsync(ChangeAccessCode accessCode);
        Task<bool> ValidateAccessCode(ValidateAccessCode validateAccessCode);
    }
}
