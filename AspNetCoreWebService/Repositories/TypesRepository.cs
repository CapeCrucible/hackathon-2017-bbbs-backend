using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System.Collections.Generic;


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
                    modelList.Add(new UserTypeModel {
                        Id = type.Id,
                        UserTypeName = type.UserTypeName
                    });
                }
                return modelList;
            }
        }
        public static UserTypeModel CreateUserContactInfo(UserTypeModel userTypeModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newUserType = _context.Add(new UserType {
                    UserTypeName = userTypeModel.UserTypeName
                });
                _context.SaveChanges();
                userTypeModel.Id = newUserType.Entity.Id;
                return userTypeModel;
            }
        }
    }
}
