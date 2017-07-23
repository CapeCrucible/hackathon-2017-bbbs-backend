using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                UserTypeId = account.UserTypeId
            };
        }

        public static List<UserAccountModel> ListUserAccountToModel(List<UserAccount> UserAccounts)
        {
            List<UserAccountModel> userAccountModels = new List<UserAccountModel>();
            foreach (var userAccount in UserAccounts)
            {
                UserAccountToModel(userAccount);
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
                UserTypeId = account.UserTypeId
            };
        }
    }
}
