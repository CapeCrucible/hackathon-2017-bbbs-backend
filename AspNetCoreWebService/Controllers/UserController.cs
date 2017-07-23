using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Helpers;
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
        [HttpPost]
        [Route("CreateUser")]
        public UserAccountViewModel CreateUser(UserAccountModel inputModel)
        {
            return TransformHelpers.ModelToUserAccountViewModel(UserAccountService.CreateUserAccount(inputModel));
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
        public ConsolidatedUserInformationResponseModel CreateConsolidatedUser(ConsolidatedUserInformationInputModel Model)
        
        {
            var newModel = new ConsolidatedUserInformationResponseModel
            {
                UserAccountViewModel = TransformHelpers.ModelToUserAccountViewModel(UserAccountService.CreateUserAccount(Model.UserAccountModel)),
                UserAddressModel = AddressService.CreateUserAddress(Model.UserAddressModel)
            };

            Model.ContactInfoModel.UserAddressId = newModel.UserAddressModel.Id;
            newModel.ContactInfoModel = ContactInfoService.CreateUserContactInfo(Model.ContactInfoModel);

            foreach (var Interest in Model.InterestModels)
            {
                var NewMapping = new InterestUserMapModel
                {
                    UserAccountId = Model.UserAccountModel.Id,
                    InterestId = Interest.Id
                };

                InterestService.CreateInterestUserMap(NewMapping);
            }
            
            newModel.InterestModels = InterestService.GetUserInterests(Model.UserAccountModel.Id);
            
            return newModel;
        }
        
        [HttpGet]
        [Route("GetConsolidatedUserInfo/{UserID}")]
        public ConsolidatedUserInformationResponseModel GetConsolidatedUserInfo(int UserId)
        
        {
            var newModel = new ConsolidatedUserInformationResponseModel
            {
                UserAccountViewModel = TransformHelpers.ModelToUserAccountViewModel(UserAccountService.GetUserAccount(UserId)),
                UserAddressModel = AddressService.GetAddressForUser(UserId)
            };

            newModel.ContactInfoModel.UserAddressId = newModel.UserAddressModel.Id;
            newModel.ContactInfoModel = ContactInfoService.GetUserContactInfo(UserId);

            newModel.InterestModels = InterestService.GetUserInterests(UserId);
            
            return newModel;
        }
        
        
    }
}
