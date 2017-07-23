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
                UserTypeId = account.UserTypeId
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
    }
}
