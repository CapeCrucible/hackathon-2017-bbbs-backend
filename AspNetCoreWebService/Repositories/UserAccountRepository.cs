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
                var newUser = _context.Add(AutoMapperGenericsHelper<UserAccountModel, UserAccount>
                    .Convert(userModel));
                return AutoMapperGenericsHelper<UserAccount, UserAccountModel>.Convert(newUser.Entity);
            }
        }

        public static UserAccountModel UpdateUserAccount(UserAccountModel userModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var existingUser = _context.UserAccounts.FirstOrDefault(x => x.Id == userModel.Id);

                if (existingUser != null)
                {
                    existingUser.FirstName = userModel.FirstName;
                    existingUser.LastName = userModel.LastName;
                    existingUser.UserName = userModel.UserName;
                    existingUser.UserTypeId = userModel.UserTypeId;
                    _context.SaveChanges();
                    return AutoMapperGenericsHelper<UserAccount, UserAccountModel>.Convert(existingUser);
                }
            }
            return null;
        }

    }
}
