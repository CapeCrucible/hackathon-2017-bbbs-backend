using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebService.Controllers
{
    [Route("api/[controller]")]
    public class ContactController
    {
        // GET: api/values
        [HttpGet]
        [Route("GetUserContactInfo")]
        public ContactInfoModel GetUserContactInfo(int userId)
        {
            return ContactInfoService.GetUserContactInfo(userId);
        }
       
        [HttpPost]
        [Route("CreateUserContactInfo")]
        public ContactInfoModel CreateUserContactInfo(ContactInfoModel contactInfoModel)
        {
            return ContactInfoService.CreateUserContactInfo(contactInfoModel);
        }
        
        // GET: api/values
        [HttpGet]
        [Route("GetAddress")]
        public UserAddressModel GetAddress(int addressId)
        {
            return AddressService.GetAddress(addressId);
        }
        
        [HttpPost]
        [Route("CreateUserAddress")]
        public UserAddressModel CreateUserAddress(UserAddressModel userAddressModel)
        {
            return AddressService.CreateUserAddress(userAddressModel);
        }
    }
}
