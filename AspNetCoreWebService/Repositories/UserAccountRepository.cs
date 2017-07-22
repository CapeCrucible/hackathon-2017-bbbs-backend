using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;

namespace AspNetCoreWebService.Repositories
{
    public class UserAccountRepository
    {
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
