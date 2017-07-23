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
        public UserAccountViewModel Login( [FromBody] JObject jmodel )
        {
            var request = new LoginRequestModel()
            {
                UserName = jmodel["UserName"].ToObject<string>(),
                Password = jmodel["Password"].ToObject<string>()
            };
            return UserAccountService.DoLogin(request);
        }
    }

}