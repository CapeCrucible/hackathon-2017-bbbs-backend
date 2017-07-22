using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System;
using System.Collections.Generic;
using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;

namespace AspNetCoreWebService.Repositories
{
    public class TypesRepository
    {
        
        public static List<UserTypeModel> GetAllUserTypes()
        {
            using (var context = new bbbsDbContext())
            {
                var modelList = new List<UserTypeModel>();
                foreach (var type in context.UserTypes)
                {
                    modelList.Add(AutoMapperGenericsHelper<UserType, UserTypeModel>.Convert(type));
                }
                return modelList;
            }
        }
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
