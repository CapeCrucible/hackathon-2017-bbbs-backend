using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Controllers;
using AspNetCoreWebService.Repositories;

namespace AspNetCoreWebService.Services
{
    public class TypeService
    {
        internal static IEnumerable<UserTypeModel> GetAllUserTypes()
        {
            return bbbsDbRepository.GetAllUserTypes();
        }
    }
}
