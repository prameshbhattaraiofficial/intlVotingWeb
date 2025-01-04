using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.Users.UserDetails;
using VotingAdmin.Web.Models.ResetPassword;
using VotingAdmin.Web.Models.Roles;
using VotingAdmin.Web.Models.Users;
using VotingAdmin.Web.Services.Http.Voting;

namespace VotingAdmin.Web.Data.Repository.Users
{
    public class UsersRepo : BaseRepository, IUsersRepo
    {
        private readonly IDgHttpClient _dgHttpClient;
        public UsersRepo(IDgHttpClient dgHttpClient)
        {
            _dgHttpClient = dgHttpClient;
        }

        public async Task<BaseDgApiResponse<UserDetailsmdl>> AddUsers(UserDetailsmdl userDetails)
        {
            var bodyContent = AddUserFormContent(userDetails);
            var (statusCode, userDetail) = await _dgHttpClient.PostAsync<BaseDgApiResponse<UserDetailsmdl>>(DgApiUris.CreateUserUri, bodyContent);
            return userDetail;
        }

        public async Task<BaseDgApiResponse<UserDetailsmdl>> AssignUserRole(int userid, int[] roleid)
        {
            var bodyContent = GetJsonStringContent(roleid);
            var (statusCode, userDetail) = await _dgHttpClient.PostAsync<BaseDgApiResponse<UserDetailsmdl>>(DgApiUris.AssignUserToRole + "?userId=" + userid, bodyContent);
            return userDetail;
        }

        public async Task<BaseDgApiResponse<string>> ChangeAccessCodeAsync(ChangeAccessCode accessCode)
        {
            var bodyContent = GetJsonStringContent(accessCode);
            var (statusCode, AccessCode) = await _dgHttpClient.PostAsync<BaseDgApiResponse<string>>(DgApiUris.ChangeAcessCode, bodyContent);
            return AccessCode;
        }

        public async Task<BaseDgApiResponse<string>> ChangePasswordAsync(ChangePassword changePassword)
        {
            var bodyContent = GetJsonStringContent(changePassword);
            var (statusCode, changePasswordDetails) = await _dgHttpClient.PostAsync<BaseDgApiResponse<string>>(DgApiUris.ChangePassword, bodyContent);
            return changePasswordDetails;
        }

        public async Task<BaseDgApiResponse<UpdateUserDetails>> EditUsers(UpdateUserDetails userDetail)
        {
            var bodyContent = UpdateUserFormContent(userDetail);
            var (_, userdata) = await _dgHttpClient.PutAsync<BaseDgApiResponse<UpdateUserDetails>>(DgApiUris.UpdateUserUri, bodyContent);
            return userdata;
        }

        public async Task<BaseDgApiResponse<UsersList>> GetAllUsersAsync(UserListRequest request)
        {
            var bodyContent = GetJsonStringContent(request);

            var (_, userDetailsList) = await _dgHttpClient.PostAsync<BaseDgApiResponse<UsersList>>(DgApiUris.GetAllUsersDetailsUri, bodyContent);
            userDetailsList.Data.SortBy = request.SortBy;
            userDetailsList.Data.SortOrder = request.SortOrder;

            return userDetailsList;
        }

        public async Task<BaseDgApiResponse<UserDetails>> GetUserById(int Id)
        {
            var (_, userDetails) = await _dgHttpClient.GetAsync<BaseDgApiResponse<UserDetails>>(DgApiUris.GetUsersDetailsByIdUri + "?userId=" + Id);
            return userDetails;
        }

        public async Task<BaseDgApiResponse<UsersRoleResponse>> GetUserRole(int userid)
        {
            var (_, userRoleDetails) = await _dgHttpClient.GetAsync<BaseDgApiResponse<UsersRoleResponse>>(DgApiUris.GetUserToRole + "?userId=" + userid);
            return userRoleDetails;
        }

        public async Task<BaseDgApiResponse<UserDetails>> RemoveUsers(int Id)
        {
            var (_, userDetail) = await _dgHttpClient.DeleteAsync<BaseDgApiResponse<UserDetails>>(DgApiUris.RemoveUserUri + "?userId=" + Id);
            return userDetail;
        }

        public async Task<BaseDgApiResponse<ResetPassword>> ResetUserPassword(ResetPassword resetPassword)
        {
            var bodyContent = GetJsonStringContent(resetPassword);
            var (statusCode, ResetpasswordDetails) = await _dgHttpClient.PostAsync<BaseDgApiResponse<ResetPassword>>(DgApiUris.ResetUserPassword, bodyContent);
            return ResetpasswordDetails;
        }
        public async Task<BaseDgApiResponse<string>> MerchantChangePasswordAsync(ChangePassword changePassword)
        {
            var bodyContent = GetJsonStringContent(changePassword);
            var (statusCode, changePasswordDetails) = await _dgHttpClient.PostAsync<BaseDgApiResponse<string>>(DgApiUris.MerchantChangePassword, bodyContent);
            return changePasswordDetails;
        }
         public async Task<BaseDgApiResponse<string>> UserChangePasswordAsync(ChangePassword changePassword)
        {
            var bodyContent = GetJsonStringContent(changePassword);
            var (statusCode, changePasswordDetails) = await _dgHttpClient.PostAsync<BaseDgApiResponse<string>>(DgApiUris.UserChangePassword, bodyContent);
            return changePasswordDetails;
        }



        public async Task<bool> ValidateAccessCode(ValidateAccessCode validateAccessCode)
        {
            var bodyContent = GetJsonStringContent(validateAccessCode);
            var (statusCode, AcccessCode) = await _dgHttpClient.PostAsync<bool>(DgApiUris.ValidateAcessCode, bodyContent);
            return AcccessCode;
        }
    }
}
