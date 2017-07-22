using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Repositories
{
    public class TypesRepository
    {
        public UserTypeModel CreateUserContactInfo(UserTypeModel userTypeModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newUserType = _context.Add(AutoMapperGenericsHelper<UserTypeModel, UserType>
                    .Convert(userTypeModel));
                return AutoMapperGenericsHelper<UserType, UserTypeModel>.Convert(newUserType.Entity);
            }
        }
    }
}
