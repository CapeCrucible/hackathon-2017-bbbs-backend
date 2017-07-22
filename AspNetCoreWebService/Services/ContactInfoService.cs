using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Repositories;

namespace AspNetCoreWebService.Services
{
    public class ContactInfoService
    {
        public static ContactInfoModel GetUserContactInfo(int userId)
        {
            return ContactInfoRepository.GetUserContactInfo(userId);
        }
        
        public static ContactInfoModel CreateUserContactInfo(ContactInfoModel contactInfoModel)
        {
            return ContactInfoRepository.CreateUserContactInfo(contactInfoModel);
        }

        public static ContactInfoModel UpdateUserContactInfo(ContactInfoModel contactInfoModel)
        {
            return ContactInfoRepository.UpdateUserContactInfo(contactInfoModel);
        }
    }
}
