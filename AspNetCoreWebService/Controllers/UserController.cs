using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Helpers;
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
        public UserAccountViewModel GetUserAccount(int userId)
        {
            return TransformHelpers.ModelToUserAccountViewModel(UserAccountService.GetUserAccount(userId));
        }

        // GET: api/values
        [HttpGet]
        [Route("UsersByType/{typeId}")]
        public IEnumerable<UserAccountViewModel> GetUserAccountsByType(int typeId)
        {
            return TransformHelpers.ListUserAccountModelToViewModel(UserAccountService.GetUserAccountsByType(typeId).ToList());
        }

        // GET: api/values
        //IGNORE THIS SHIT
        [HttpPost]
        [Route("CreateUser")]
        public UserAccountViewModel CreateUser(UserAccountModel inputModel)
        {
            return TransformHelpers.ModelToUserAccountViewModel(UserAccountService.CreateUserAccount(inputModel));
        }
        //IGNORE THIS SHIT
        [HttpPost]
        [Route("UpdateUser")]
        public ConsolidatedUserInformationModel UpdateUserInformation([FromBody] JObject jmodel)
        {

            var model = new ConsolidatedUserInformationInputModel()
            {
                UserAccount = jmodel["user"].ToObject<UserAccountModel>(),
                UserAddress = jmodel["address"].ToObject<UserAddressModel>(),
                ContactInfo = jmodel["contactInfo"].ToObject<ContactInfoModel>(),
                Interests = jmodel["interests"].ToObject<List<InterestModel>>()
            };
            return new ConsolidatedUserInformationModel
            {
                ContactInfoModel = ContactInfoService.UpdateUserContactInfo(model.ContactInfo),
                UserAccountModel = UserAccountService.UpdateUserAccount(model.UserAccount),
                UserAddressModel = AddressService.UpdateUserAddress(model.UserAddress)
            };
        }

        [HttpPost]
        [Route("CreateConsolidatedUser")]
        public ConsolidatedUserInformationResponseModel CreateConsolidatedUser([FromBody] JObject jmodel )
        {
            var Model = new ConsolidatedUserInformationResponseModel()
            {
                user = jmodel["user"].ToObject<UserAccountViewModel>(),
                address = jmodel["address"].ToObject<UserAddressModel>(),
                contactInfo = jmodel["contactInfo"].ToObject<ContactInfoModel>(),
                interests = jmodel["interests"].ToObject<List<InterestModel>>()
            };
            Model.user = TransformHelpers.ModelToUserAccountViewModel(UserAccountService.CreateUserAccount(TransformHelpers.UserAccountViewModelToModel(Model.user)));
            Model.address = AddressService.CreateUserAddress(Model.address);
            Model.contactInfo.UserAccountId = Model.user.Id;
            Model.contactInfo.UserAddressId = Model.address.Id;
            Model.contactInfo = ContactInfoService.CreateUserContactInfo(Model.contactInfo);

            foreach (var Interest in Model.interests)
            {
                var NewMapping = new InterestUserMapModel
                {
                    UserAccountId = Model.user.Id,
                    InterestId = Interest.Id
                };

                InterestService.CreateInterestUserMap(NewMapping);
            }

            Model.interests = InterestService.GetUserInterests(Model.user.Id);

            return Model;
        }

        [HttpGet]
        [Route("GetConsolidatedUserInfo/{UserID}")]
        public ConsolidatedUserInformationResponseModel GetConsolidatedUserInfo(int UserId)

        {
            var newModel = new ConsolidatedUserInformationResponseModel();

            newModel.user = TransformHelpers.ModelToUserAccountViewModel(UserAccountService.GetUserAccount(UserId));
            newModel.address = AddressService.GetAddressForUser(UserId);

            newModel.contactInfo.UserAddressId = newModel.address.Id;
            newModel.contactInfo = ContactInfoService.GetUserContactInfo(UserId);

            newModel.interests = InterestService.GetUserInterests(UserId);

            return newModel;
        }


    }
}
