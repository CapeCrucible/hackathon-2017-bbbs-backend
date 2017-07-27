using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebService.Services;

namespace AspNetCoreWebService.Helpers
{
    public class TransformHelpers
    {
        public static UserAccountModel UserAccountToModel(UserAccount account)
        {
            return new UserAccountModel
            {
                Id = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Password = account.Password,
                UserName = account.UserName,
                UserTypeId = account.UserTypeId,
                Age = account.Age,
                PictureUrl = account.PictureUrl
            };
        }

        public static List<UserAccountModel> ListUserAccountToModel(List<UserAccount> UserAccounts)
        {
            List<UserAccountModel> userAccountModels = new List<UserAccountModel>();
            foreach (var userAccount in UserAccounts)
            {
                userAccountModels.Add(UserAccountToModel(userAccount));
            }
            return userAccountModels;
        }

        public static UserAccount ModelToUserAccount(UserAccountModel account)
        {
            return new UserAccount
            {
                Id = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Password = account.Password,
                UserName = account.UserName,
                UserTypeId = account.UserTypeId,
                Age = account.Age,
                PictureUrl = account.PictureUrl
            };
        }

        public static UserAddressModel ModelToAddress(UserAddress address)
        {
            return new UserAddressModel
            {
                City = address.City,
                Id = address.Id,
                State = address.State,
                StreetLine1 = address.StreetLine1,
                StreetLine2 = address.StreetLine2,
                Zip = address.Zip
            };
        }

        public static UserAccountViewModel ModelToUserAccountViewModel(UserAccountModel model)
        {
            return new UserAccountViewModel
            {
                FirstName = model.FirstName,
                Id = model.Id,
                LastName = model.LastName,
                UserName = model.UserName,
                UserTypeId = model.UserTypeId,
                Age = model.Age,
                PictureUrl = model.PictureUrl
            };
        }

        public static UserAccountModel UserAccountViewModelToModel(UserAccountViewModel viewModel)
        {
            return new UserAccountModel
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                UserName = viewModel.UserName,
                UserTypeId = viewModel.UserTypeId,
                Id = viewModel.Id,
                Age = viewModel.Age,
                PictureUrl = viewModel.PictureUrl
            };
        }

        public static List<UserAccountViewModel> ListUserAccountModelToViewModel(List<UserAccountModel> UserAccounts)
        {
            List<UserAccountViewModel> userAccountModels = new List<UserAccountViewModel>();
            foreach (var userAccount in UserAccounts)
            {
                userAccountModels.Add(ModelToUserAccountViewModel(userAccount));
            }
            return userAccountModels;
        }

        public static UserAccountViewModel DtoToUserAccountViewModel(UserAccount model)
        {
            return new UserAccountViewModel
            {
                FirstName = model.FirstName,
                Id = model.Id,
                LastName = model.LastName,
                UserName = model.UserName,
                UserTypeId = model.UserTypeId,
                Age = model.Age,
                PictureUrl = model.PictureUrl
            };
        }

        public static ConsolidatedUserInformationResponseModel UserInputModelToUserResponseModel(ConsolidatedUserInformationInputModel model)
        {
            return new ConsolidatedUserInformationResponseModel(){
                address = model.UserAddress,
                contactInfo = model.ContactInfo,
                interests = model.Interests,
                user = new UserAccountViewModel()
                {
                    FirstName = model.UserAccount.FirstName,
                    LastName = model.UserAccount.LastName,
                    UserName = model.UserAccount.UserName,
                    UserTypeId = model.UserAccount.UserTypeId,
                    Id = model.UserAccount.Id,
                    Age = model.UserAccount.Age,
                    PictureUrl = model.UserAccount.PictureUrl
                }
            };
        }

        public static ConsolidatedUserInformationResponseModel UserAccountToConsResModel(UserAccount parentAccount)
        {
            return new ConsolidatedUserInformationResponseModel()
            {
                address = AddressService.GetAddressForUser(parentAccount.Id),
                contactInfo = ContactInfoService.GetUserContactInfo(parentAccount.Id),
                interests = InterestService.GetUserInterests(parentAccount.Id),
                user = DtoToUserAccountViewModel(parentAccount)
            };
        }
    }
}
