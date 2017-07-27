using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Helpers;
using AspNetCoreWebService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

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
        //IGNORE THIS
        [HttpPost]
        [Route("CreateUser")]
        public UserAccountViewModel CreateUser(UserAccountModel inputModel)
        {
            return TransformHelpers.ModelToUserAccountViewModel(UserAccountService.CreateUserAccount(inputModel));
        }
        //IGNORE THIS
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
            var Model = new ConsolidatedUserInformationInputModel()
            {
                UserAccount = jmodel["user"].ToObject<UserAccountModel>(),
                UserAddress = jmodel["address"].ToObject<UserAddressModel>(),
                ContactInfo = jmodel["contactInfo"].ToObject<ContactInfoModel>(),
                Interests = jmodel["interests"].ToObject<List<InterestModel>>()
            };
            Model.UserAccount = UserAccountService.CreateUserAccount(Model.UserAccount);
            Model.UserAddress = AddressService.CreateUserAddress(Model.UserAddress);
            Model.ContactInfo.UserAccountId = Model.UserAccount.Id;
            Model.ContactInfo.UserAddressId = Model.UserAddress.Id;
            Model.ContactInfo = ContactInfoService.CreateUserContactInfo(Model.ContactInfo);

            if (Model.Interests != null)
            {
                foreach (var Interest in Model.Interests)
                {
                    var NewMapping = new InterestUserMapModel
                    {
                        UserAccountId = Model.UserAccount.Id,
                        InterestId = Interest.Id
                    };

                    InterestService.CreateInterestUserMap(NewMapping);
                }
            }
            else
            {
                //Demonstration Data
                InterestService.CreateInterestUserMap(new InterestUserMapModel
                {
                    UserAccountId = Model.UserAccount.Id,
                    InterestId = 1
                });
                InterestService.CreateInterestUserMap(new InterestUserMapModel
                {
                    UserAccountId = Model.UserAccount.Id,
                    InterestId = 6
                });
            }
            Model.Interests = InterestService.GetUserInterests(Model.UserAccount.Id);

            return TransformHelpers.UserInputModelToUserResponseModel(Model);
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
