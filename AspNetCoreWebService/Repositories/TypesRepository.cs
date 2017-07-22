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
    }
}
