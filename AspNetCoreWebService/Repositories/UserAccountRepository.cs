using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreWebService.Repositories
{
    public class UserAccountRepository
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

        public static UserAccountModel CreateUser(UserAccountModel userModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var user = _context.UserAccounts.Add(new UserAccount{
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.UserName,
                    UserTypeId = userModel.UserTypeId
                });
                _context.SaveChanges();
                return AutoMapperGenericsHelper<UserAccount, UserAccountModel>.Convert(user.Entity);
            }
        }

    }
}
