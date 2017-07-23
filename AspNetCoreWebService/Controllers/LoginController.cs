using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AspNetCoreWebService.Controllers
{
    [Route("api/[controller]")]
    public class LoginController
    {
        [HttpPost]
        [Route("Login")]
        public UserAccountViewModel Login( [FromBody] LoginRequestModel model )
        {
            return UserAccountService.DoLogin(model);
        }
    }

}