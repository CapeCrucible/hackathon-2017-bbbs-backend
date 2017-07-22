using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Services
{
    public class UserAccountService
    {
        public static UserAccountModel GetUserAccount(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                return AutoMapperGenericsHelper<UserAccount, UserAccountModel>.Convert(
                    _context.UserAccounts.FirstOrDefault(x => x.Id == userId));
            }
        }

        public static List<UserAccountModel> GetUserAccountsByType(int typeId)
        {
            using (var _context = new bbbsDbContext())
            {
                List<UserAccountModel> userAccountModels = new List<UserAccountModel>();
                foreach (var userAccount in _context.UserAccounts.Where(x => x.UserTypeId == typeId).ToList())
                {
                    userAccountModels.Add(AutoMapperGenericsHelper<UserAccount, UserAccountModel>.Convert(userAccount));
                }
                return userAccountModels;
            }
        }
    }
}
