using AutoMapper;
using VotingAdmin.Web.Data.Repository.Users;
using VotingAdmin.Web.Dtos;
using VotingAdmin.Web.Dtos.ResetPassword;
using VotingAdmin.Web.Dtos.Users.UserDetails;
using VotingAdmin.Web.Models.ResetPassword;
using VotingAdmin.Web.Models.Roles;
using VotingAdmin.Web.Models.Users;

namespace VotingAdmin.Web.Services.Users
{
    public class UsersServices : IUsersServices
    {
        private readonly IUsersRepo _users;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public UsersServices(IUsersRepo users, IConfiguration config, IMapper mapper)
        {
            _users = users;
            _config = config;
            _mapper = mapper;
        }

        public Task<BaseDgApiResponse<UserDetailsmdl>> AddUsers(UserDetails userDetails)
        {
            var userDetailsmdl = new UserDetailsmdl
            {
                UserName = userDetails.UserName,
                FullName = userDetails.FullName,
                Email = userDetails.Email,
                Mobile = userDetails.Mobile ?? "",
                Address = userDetails.Address ?? "",
                Gender = userDetails.Gender,
                Department = userDetails.Department,
                DateOfBirth = userDetails.DateOfBirth,
                DateOfJoining = userDetails.DateOfJoining,
                ProfileImage = userDetails.ProfileImage,
                Password = userDetails.Password,
                IsActive = true,
                Profileimagepath = userDetails.ProfileImagePath
            };

            var result = _users.AddUsers(userDetailsmdl);
            return result;
        }

        public Task<BaseDgApiResponse<UserDetailsmdl>> AssignUserRole(int userid, int[] roleid)
        {
            var result = _users.AssignUserRole(userid, roleid);
            return result;
        }

        public async Task<BaseDgApiResponse<string>> ChangeAccessCodeAsync(ChangeAccessCode accessCode)
        {
            var result = await _users.ChangeAccessCodeAsync(accessCode);
            return result;
        }

        public async Task<BaseDgApiResponse<string>> ChangePassword(ChangePassword changePassword)
        {

            var result = await _users.ChangePasswordAsync(changePassword);
            return result;
        }

        public Task<BaseDgApiResponse<UserDetails>> DeleteUsers(int id)
        {
            var result = _users.RemoveUsers(id);
            return result;
        }

        public Task<BaseDgApiResponse<UpdateUserDetails>> EditUsers(UpdateUserDetailsDto userDetails)
        {
            var model = new UpdateUserDetails()
            {
                id = userDetails.id,
                fullName = userDetails.fullName,
                ProfileImage = userDetails.ProfileImage,
                gender = userDetails.gender,
                dateOfBirth = userDetails.dateOfBirth,
                dateOfJoining = userDetails.dateOfJoining,
                address = userDetails.address,
                isActive = userDetails.isActive
            };

            var result = _users.EditUsers(model);
            return result;
        }

        public async Task<BaseDgApiResponse<UsersList>> GetAllUsersAsync(UserListRequest request)
        {
            var usersList = await _users.GetAllUsersAsync(request);

            return usersList;
        }

        public async Task<BaseDgApiResponse<UserDetails>> GetUserById(int Id)
        {
            BaseDgApiResponse<UserDetails> result = await _users.GetUserById(Id);
            return result;
        }

        public async Task<BaseDgApiResponse<UsersRoleResponse>> GetUserRole(int userid)
        {
            var result = await _users.GetUserRole(userid);
            return result;
        }

        public async Task<BaseDgApiResponse<ResetPassword>> ResetUserPassword(ResetPasswordDto resetPassword)
        {
            ResetPassword reset = new ResetPassword() { confirmPassword = resetPassword.confirmPassword, userId = resetPassword.userId, newPassword = resetPassword.newPassword };
            var result = await _users.ResetUserPassword(reset);
            return result;
        }

        public async Task<BaseDgApiResponse<string>> MerchantChangePassword(ChangePassword changePassword)
        {

            var result = await _users.MerchantChangePasswordAsync(changePassword);
            return result;
        }
        public async Task<BaseDgApiResponse<string>> UserChangePassword(ChangePassword changePassword)
        {

            var result = await _users.UserChangePasswordAsync(changePassword);
            return result;
        }

        public async Task<bool> ValidateAccessCode(ValidateAccessCode validateAccessCode)
        {
            var result = await _users.ValidateAccessCode(validateAccessCode);
            return result;
        }
    }
}
