using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Catalog.Common.Utilities;

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
        [Route("GetUserAccount")]
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
        public ConsolidatedUserInformationResponseModel CreateConsolidatedUser([FromBody] JObject jmodel )//ConsolidatedUserInformationResponseModel Model)

        {

            //var 
            //var Model = JsonConvert.DeserializeObject<ConsolidatedUserInformationResponseModel>(jmodel.ToString());
            
            var Model = new ConsolidatedUserInformationResponseModel()
            {
                User = jmodel["user"].ToObject<UserAccountModel>(),
                Address = jmodel["address"].ToObject<UserAddressModel>(),
                ContactInfo = jmodel["contactInfo"].ToObject<ContactInfoModel>(),
                Interest = jmodel["interests"].ToObject<List<InterestModel>>()
            };
            
            ConsolidatedUserInformationResponseModel newModel = new ConsolidatedUserInformationResponseModel
            {
                User = UserAccountService.CreateUserAccount(Model.User),
                Address = AddressService.CreateUserAddress(Model.Address)
            };

            Model.ContactInfo.UserAddressId = newModel.Address.Id;
            newModel.ContactInfo = ContactInfoService.CreateUserContactInfo(Model.ContactInfo);

            foreach (var Interest in Model.Interest)
            {
                InterestUserMapModel NewMapping = new InterestUserMapModel
                {
                    UserAccountId = Model.User.Id,
                    InterestId = Interest.Id
                };

                InterestService.CreateInterestUserMap(NewMapping);
            }

            newModel.Interest = InterestService.GetUserInterests(Model.User.Id);

            return newModel;
        }
    }
}
