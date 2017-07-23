using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Repositories;
using Catalog.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebService.Helpers;

namespace AspNetCoreWebService.Services
{
    public class UserAccountService
    {
        internal static UserAccountModel GetUserAccount(int userId)
        {
            return UserAccountRepository.GetUserAccount(userId);
        }

        internal static IEnumerable<UserAccountModel> GetUserAccountsByType(int typeId)
        {
            return UserAccountRepository.GetUserAccountsByType(typeId);
        }

        internal static UserAccountModel CreateUserAccount(UserAccountModel inputModel)
        {
            return UserAccountRepository.CreateUser(inputModel);
        }

        internal static UserAccountModel UpdateUserAccount(UserAccountModel userAccountModel)
        {
            return UserAccountRepository.UpdateUserAccount(userAccountModel);
        }

        internal static UserAccountViewModel DoLogin(LoginRequestModel requestModel)
        {
            var userAccountModel = UserAccountRepository.GetUserByLogin(requestModel);
            return new UserAccountViewModel()
            {
                Id = userAccountModel.Id,
                UserName = userAccountModel.UserName,
                UserTypeId = userAccountModel.UserTypeId,
                FirstName = userAccountModel.FirstName,
                LastName = userAccountModel.LastName
            };
        }
    }
}
