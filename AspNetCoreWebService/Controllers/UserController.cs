using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Controllers
{
    [Route("api/[controller]")]
    public class UserController
    {
        // GET: api/values
        [HttpGet]
        [Route("GetAllUserTypes")]
        public IEnumerable<UserTypeModel> GetAllUserTypes()
        {
            return TypeService.GetAllUserTypes();
        }

        // GET: api/values
        [HttpGet]
        [Route("User/{userId}")]
        public UserAccountModel GetUserAccount(int userId)
        {
            return UserAccountService.GetUserAccount(userId);
        }

        // GET: api/values
        [HttpGet]
        [Route("UsersByType/{typeId}")]
        public IEnumerable<UserAccountModel> GetUserAccountsByType(int typeId)
        {
            return UserAccountService.GetUserAccountsByType(typeId);
        }

        // GET: api/values
        [HttpPost]
        [Route("CreateUser")]
        public UserAccountModel CreateUser(UserAccountModel inputModel)
        {
            return UserAccountService.CreateUser(inputModel);
        }
    }
}
