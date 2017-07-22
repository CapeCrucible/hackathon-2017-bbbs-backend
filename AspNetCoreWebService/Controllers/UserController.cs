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
            return UserAccountService.CreateUserAccount(inputModel);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public ConsolidatedUserInformationModel UpdateUserInformation(ConsolidatedUserInformationModel model)
        {
            return new ConsolidatedUserInformationModel
            {
                ContactInfoModel = ContactInfoService.UpdateUserContactInfo(model.ContactInfoModel),
                UserAccountModel = UserAccountService.UpdateUserAccount(model.UserAccountModel),
                UserAddressModel = AddressService.UpdateUserAddress(model.UserAddressModel)
            };
        }

        [HttpPost]
        [Route("CreateConsolidatedUser")]
        public ConsolidatedUserInformationModel CreateConsolidatedUser(ConsolidatedUserInformationModel model)
        {
            ConsolidatedUserInformationModel newModel = new ConsolidatedUserInformationModel();

            newModel.UserAccountModel = UserAccountService.CreateUserAccount(model.UserAccountModel);
            newModel.UserAddressModel = AddressService.CreateUserAddress(model.UserAddressModel);
            model.ContactInfoModel.AddressId = newModel.UserAddressModel.Id;
            newModel.ContactInfoModel = ContactInfoService.CreateUserContactInfo(model.ContactInfoModel);

            return newModel;
        }
    }
}
