using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.ResetPassword;
using VotingAdmin.Web.Dtos.Users.UserDetails;
using VotingAdmin.Web.Models.ResetPassword;
using VotingAdmin.Web.Models.Roles;
using VotingAdmin.Web.Models.Users;

namespace VotingAdmin.Web.Services.Users
{
    public interface IUsersServices
    {
        Task<BaseDgApiResponse<UsersList>> GetAllUsersAsync(UserListRequest request);
        Task<BaseDgApiResponse<UserDetails>> GetUserById(int Id);
        Task<BaseDgApiResponse<UserDetailsmdl>> AddUsers(UserDetails userDetails);
        Task<BaseDgApiResponse<UpdateUserDetails>> EditUsers(UpdateUserDetailsDto userDetails);
        Task<BaseDgApiResponse<UserDetails>> DeleteUsers(int id);
        Task<BaseDgApiResponse<UserDetailsmdl>> AssignUserRole(int userid, int[] roleid);
        Task<BaseDgApiResponse<UsersRoleResponse>> GetUserRole(int userid);
        Task<BaseDgApiResponse<ResetPassword>> ResetUserPassword(ResetPasswordDto resetPassword);
        Task<BaseDgApiResponse<string>> MerchantChangePassword(ChangePassword changePassword);
        Task<BaseDgApiResponse<string>> UserChangePassword(ChangePassword changePassword);
        Task<BaseDgApiResponse<string>> ChangePassword(ChangePassword changePassword);
        Task<BaseDgApiResponse<string>> ChangeAccessCodeAsync(ChangeAccessCode accessCode);
        Task<bool> ValidateAccessCode(ValidateAccessCode validateAccessCode);


    }
}
