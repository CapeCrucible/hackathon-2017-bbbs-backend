using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebService.Controllers
{
    [Route("api/[controller]")]
    public class LoginController
    {

        [HttpPost]
        [Route("Login")]
        public UserAccountModel Login(LoginRequestModel LoginRequest)
        {
            return UserAccountService.DoLogin(LoginRequest);
        }
    }

}