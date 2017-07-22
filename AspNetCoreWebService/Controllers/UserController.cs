using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Controllers
{
    public class UserController
    {
        [Route("api/[controller]")]
        public class TypesController : Controller
        {
            // GET: api/values
            [HttpGet]
            [Route("GetAllUserTypes")]
            public IEnumerable<UserTypeModel> GetAllUserTypes()
            {
                return TypeService.GetAllUserTypes();
            }
        }
    }
}
