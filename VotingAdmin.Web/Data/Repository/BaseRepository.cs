using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using VotingAdmin.Web.Dtos.contest;
using VotingAdmin.Web.Dtos.Menus;
using VotingAdmin.Web.Helper;
using VotingAdmin.Web.Models.Users;

namespace VotingAdmin.Web.Data.Repository
{
    public class BaseRepository
    {
        protected virtual StringContent GetJsonStringContent(object inputDataObj)
        {
            return new StringContent(JsonConvert.SerializeObject(inputDataObj), Encoding.UTF8, "application/json");
        }
        protected virtual MultipartFormDataContent AddUserFormContent(UserDetailsmdl inputDataObj)
        {
            var multipartFormContent = new MultipartFormDataContent();

            //Add other fields
            if (inputDataObj.Id != 0)
            {
                multipartFormContent.Add(new StringContent(inputDataObj.Id.ToString()), "Id");
            }
            multipartFormContent.Add(new StringContent(inputDataObj.UserName), "UserName");
            multipartFormContent.Add(new StringContent(inputDataObj.FullName), "FullName");
            multipartFormContent.Add(new StringContent(inputDataObj.Email), "Email");
            multipartFormContent.Add(new StringContent(inputDataObj.Mobile), "Mobile");
            multipartFormContent.Add(new StringContent(inputDataObj.Address), "Address");
            multipartFormContent.Add(new StringContent(inputDataObj.Gender.ToString()), "Gender");
            if (inputDataObj.Department != null)
            {
                multipartFormContent.Add(new StringContent(inputDataObj.Department), name: "Depertment");
            }
            if (inputDataObj.DateOfBirth != null || inputDataObj.DateOfJoining != null)
            {
                multipartFormContent.Add(new StringContent(inputDataObj.DateOfBirth.ToString()), "DateOfBirth");
                multipartFormContent.Add(new StringContent(inputDataObj.DateOfJoining.ToString()), "DateOfJoining");
            }
            multipartFormContent.Add(new StringContent(inputDataObj.Password), "Password");
            multipartFormContent.Add(new StringContent(inputDataObj.IsActive.ToString()), "IsActive");



            if (inputDataObj.ProfileImage is not null && inputDataObj.ProfileImage.Length > 0)
            {
                var bytes = FileHelper.GenerateByteArrayFromFile(inputDataObj.ProfileImage);
                multipartFormContent.Add(bytes, "ProfileImage", inputDataObj.ProfileImage.FileName);
            }
            return multipartFormContent;

        }
        protected virtual MultipartFormDataContent AddSubContestContent(AddSubContest inputDataObj)
        {
            var multipartFormContent = new MultipartFormDataContent();

            multipartFormContent.Add(new StringContent(inputDataObj.ContestId.ToString()), "ContestId");

            if (inputDataObj.SubContestDtos != null && inputDataObj.SubContestDtos.Any())
            {
                for (int i = 0; i < inputDataObj.SubContestDtos.Count(); i++)
                {
                    multipartFormContent.Add(new StringContent(inputDataObj.SubContestDtos[i].SubContestName), @$"SubContestDtos[{i}].SubContestName");
                    multipartFormContent.Add(new StringContent(inputDataObj.SubContestDtos[i].SubContestDesc), @$"SubContestDtos[{i}].SubContestDesc");
                    if (inputDataObj.SubContestDtos[i].BannerImg is not null && inputDataObj.SubContestDtos[i].BannerImg.Length > 0)
                    {
                        var bytes = FileHelper.GenerateByteArrayFromFile(inputDataObj.SubContestDtos[i].BannerImg);
                        multipartFormContent.Add(bytes, @$"SubContestDtos[{i}].BannerImg", inputDataObj.SubContestDtos[i].BannerImg.FileName);
                    }
                    if (inputDataObj.SubContestDtos[i].SliderImg is not null && inputDataObj.SubContestDtos[i].SliderImg.Length > 0)
                    {
                        var bytes = FileHelper.GenerateByteArrayFromFile(inputDataObj.SubContestDtos[i].SliderImg);
                        multipartFormContent.Add(bytes, @$"SubContestDtos[{i}].SliderImg", inputDataObj.SubContestDtos[i].SliderImg.FileName);
                    }

                }
            }


            return multipartFormContent;




        }
        protected virtual MultipartFormDataContent UpdateUserFormContent(UpdateUserDetails inputDataObj)
        {
            var multipartFormContent = new MultipartFormDataContent();

            //Add other fields
            if (inputDataObj.id != 0)
            {
                multipartFormContent.Add(new StringContent(inputDataObj.id.ToString()), "Id");
            }
            multipartFormContent.Add(new StringContent(inputDataObj.fullName), "FullName");
            if (inputDataObj.address != null)
            {
                multipartFormContent.Add(new StringContent(inputDataObj.address), "Address");
            }
            multipartFormContent.Add(new StringContent(inputDataObj.gender.ToString()), "Gender");
            if (inputDataObj.department != null)
            {
                multipartFormContent.Add(new StringContent(inputDataObj.department), name: "Depertment");
            }
            multipartFormContent.Add(new StringContent(inputDataObj.dateOfBirth.ToString()), "DateOfBirth");
            multipartFormContent.Add(new StringContent(inputDataObj.dateOfJoining.ToString()), "DateOfJoining");
            multipartFormContent.Add(new StringContent(inputDataObj.isActive.ToString()), "IsActive");



            if (inputDataObj.ProfileImage is not null && inputDataObj.ProfileImage.Length > 0)
            {
                var bytes = FileHelper.GenerateByteArrayFromFile(inputDataObj.ProfileImage);
                multipartFormContent.Add(bytes, "ProfileImage", inputDataObj.ProfileImage.FileName);
            }
            return multipartFormContent;

        }

        protected virtual MultipartFormDataContent AddMenuFormContent(AddMenu inputDataObj)
        {
            var multipartFormContent = new MultipartFormDataContent();

            //Add other fields

            multipartFormContent.Add(new StringContent(inputDataObj.Title), "Title");
            multipartFormContent.Add(new StringContent(inputDataObj.ParentId.ToString()), "ParentId");
            multipartFormContent.Add(new StringContent(inputDataObj.MenuUrl), "MenuUrl");
            multipartFormContent.Add(new StringContent(inputDataObj.IsActive.ToString()), "IsActive");
            multipartFormContent.Add(new StringContent(inputDataObj.DisplayOrder.ToString()), "DisplayOrder");

            if (inputDataObj.ImagePath is not null && inputDataObj.ImagePath.Length > 0)
            {
                var bytes = FileHelper.GenerateByteArrayFromFile(inputDataObj.ImagePath);
                multipartFormContent.Add(bytes, "MenuImage", inputDataObj.ImagePath.FileName);
            }
            return multipartFormContent;

        }
        protected virtual MultipartFormDataContent updateMenuFormContent(UpdateMenu inputDataObj)
        {
            var multipartFormContent = new MultipartFormDataContent();


            multipartFormContent.Add(new StringContent(inputDataObj.Id.ToString()), "Id");
            multipartFormContent.Add(new StringContent(inputDataObj.Title), "Title");
            multipartFormContent.Add(new StringContent(inputDataObj.ParentId.ToString()), "ParentId");
            multipartFormContent.Add(new StringContent(inputDataObj.MenuUrl), "MenuUrl");
            multipartFormContent.Add(new StringContent(inputDataObj.IsActive.ToString()), "IsActive");
            multipartFormContent.Add(new StringContent(inputDataObj.DisplayOrder.ToString()), "DisplayOrder");

            if (inputDataObj.ImagePath is not null && inputDataObj.ImagePath.Length > 0)
            {
                var bytes = FileHelper.GenerateByteArrayFromFile(inputDataObj.ImagePath);
                multipartFormContent.Add(bytes, "MenuImage", inputDataObj.ImagePath.FileName);
            }
            return multipartFormContent;

        }


        protected virtual MultipartFormDataContent AddContestContent(AddContestDto inputDataObj)
        {
            var multipartFormContent = new MultipartFormDataContent();

            multipartFormContent.Add(new StringContent(inputDataObj.MerchantId.ToString()), "MerchantId");
            multipartFormContent.Add(new StringContent(inputDataObj.ContestName), "ContestName");
            multipartFormContent.Add(new StringContent(inputDataObj.ContestDesc), "ContestDesc");
            multipartFormContent.Add(new StringContent(inputDataObj.StartDateTime.ToString()), "StartDateTime");
            multipartFormContent.Add(new StringContent(inputDataObj.EndDateTime.ToString()), "EndDateTime");
            multipartFormContent.Add(new StringContent(inputDataObj.PriorityOrder.ToString()), "PriorityOrder");
            multipartFormContent.Add(new StringContent(inputDataObj.PricePerVote.ToString()), "PricePerVote");
            multipartFormContent.Add(new StringContent(inputDataObj.IsActive.ToString()), "IsActive");

            if (inputDataObj.BannerImg is not null && inputDataObj.BannerImg.Length > 0)
            {
                var bytes = FileHelper.GenerateByteArrayFromFile(inputDataObj.BannerImg);
                multipartFormContent.Add(bytes, "BannerImg", inputDataObj.BannerImg.FileName);
            }

            if (inputDataObj.SliderImg is not null && inputDataObj.SliderImg.Length > 0)
            {
                var bytes = FileHelper.GenerateByteArrayFromFile(inputDataObj.SliderImg);
                multipartFormContent.Add(bytes, "SliderImg", inputDataObj.SliderImg.FileName);
            }

            if (inputDataObj.SubContests != null && inputDataObj.SubContests.Any())
            {
                for (int i = 0; i < inputDataObj.SubContests.Count(); i++)
                {
                    multipartFormContent.Add(new StringContent(inputDataObj.SubContests[i].SubContestName), @$"SubContests[{i}].SubContestName");
                    multipartFormContent.Add(new StringContent(inputDataObj.SubContests[i].SubContestDesc), @$"SubContests[{i}].SubContestDesc");
                    multipartFormContent.Add(new StringContent(inputDataObj.SubContests[i].IsActive.ToString()), @$"SubContests[{i}].IsActive");
                    if (inputDataObj.SubContests[i].BannerImg is not null && inputDataObj.SubContests[i].BannerImg.Length > 0)
                    {
                        var bytes = FileHelper.GenerateByteArrayFromFile(inputDataObj.SubContests[i].BannerImg);
                        multipartFormContent.Add(bytes, @$"SubContests[{i}].BannerImg", inputDataObj.SubContests[i].BannerImg.FileName);
                    }
                    if (inputDataObj.SubContests[i].SliderImg is not null && inputDataObj.SubContests[i].SliderImg.Length > 0)
                    {
                        var bytes = FileHelper.GenerateByteArrayFromFile(inputDataObj.SubContests[i].SliderImg);
                        multipartFormContent.Add(bytes, @$"SubContests[{i}].SliderImg", inputDataObj.SubContests[i].SliderImg.FileName);
                    }

                }
            }


            return multipartFormContent;




        }



        protected virtual MultipartFormDataContent ToFormContent<TModel>(TModel inputDataObj)
        {
            var multipartFormContent = new MultipartFormDataContent();

            var properties = typeof(TModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in properties)
            {

                if (prop.PropertyType == typeof(int))
                {
                    multipartFormContent.Add(new StringContent(prop.GetValue(inputDataObj)?.ToString()), prop.Name);
                }
                if (prop.PropertyType == typeof(long))
                {
                    multipartFormContent.Add(new StringContent(prop.GetValue(inputDataObj)?.ToString()), prop.Name);
                }
                if (prop.PropertyType == typeof(decimal))
                {
                    multipartFormContent.Add(new StringContent(prop.GetValue(inputDataObj)?.ToString()), prop.Name);
                }
                if (prop.PropertyType == typeof(bool))
                {
                    multipartFormContent.Add(new StringContent(prop.GetValue(inputDataObj)?.ToString()), prop.Name);
                }
                if (prop.PropertyType == typeof(DateTime))
                {
                    multipartFormContent.Add(new StringContent(prop.GetValue(inputDataObj)?.ToString()), prop.Name);
                }
                if (prop.PropertyType == typeof(IFormFile))
                {
                    var image = (IFormFile)prop.GetValue(inputDataObj);
                    if (image is not null && image.Length > 0)
                    {
                        var bytes = FileHelper.GenerateByteArrayFromFile(image);
                        multipartFormContent.Add(bytes, prop.Name, image.FileName);
                    }
                }
                if (prop.PropertyType == typeof(string) && prop.GetValue(inputDataObj) != null)
                {
                    multipartFormContent.Add(new StringContent(prop.GetValue(inputDataObj)?.ToString()), prop.Name);

                }

            }

            return multipartFormContent;

        }
    }
}
