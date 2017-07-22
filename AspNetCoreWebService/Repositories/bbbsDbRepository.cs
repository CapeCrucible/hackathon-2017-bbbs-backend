using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Repositories
{
    public class bbbsDbRepository
    {
        public static UserAccountModel GetUser(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                return AutoMapperGenericsHelper<UserAccount, UserAccountModel>.Convert(
                    _context.UserAccounts.FirstOrDefault(x => x.Id == userId));
            }
        }
        
        public static List<UserAccountModel> GetUsersByType(int typeId)
        {
            using (var _context = new bbbsDbContext())
            {
                List<UserAccountModel> userAccountModels = new List<UserAccountModel>(); 
                foreach(var userAccount in _context.UserAccounts.Where(x => x.UserTypeId == typeId).ToList())
                {
                    userAccountModels.Add(AutoMapperGenericsHelper<UserAccount, UserAccountModel>.Convert(userAccount));
                }
                return userAccountModels;
            }
        }

        public static ContactInfoModel GetUserContactInfo(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                return AutoMapperGenericsHelper<ContactInfo, ContactInfoModel>.Convert(_context.ContactInfo.FirstOrDefault(x => x.UserAccountId == userId));
            }
        }

        public static UserAddressModel GetAddress(int addressId)
        {
            using (var _context = new bbbsDbContext())
            {
                return AutoMapperGenericsHelper<UserAddress, UserAddressModel>.Convert(_context.UserAddresses.FirstOrDefault(x => x.Id == addressId));
            }

        }

        public static List<InterestModel> GetUserInterests(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                List<Interest> interests = (from Interest i in _context.Interests
                 join InterestUserMap ium in _context.InterestUserMaps on i.Id equals ium.InterestId
                 join UserAccount ua in _context.UserAccounts on ium.UserAccountId equals ua.Id
                 where ua.Id == userId
                 select i).Distinct().ToList();

                List<InterestModel> interestModels = new List<InterestModel>();
                foreach(var interest in interests)
                {
                    interestModels.Add(AutoMapperGenericsHelper<Interest, InterestModel>.Convert(interest));
                }
                return interestModels;
            }
        }

        public static UserAccountModel CreateUser(UserAccountModel userModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var user = _context.UserAccounts.Add(new UserAccount{
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.UserName,
                    UserTypeId = userModel.UserTypeId
                });
                _context.SaveChanges();
                return AutoMapperGenericsHelper<UserAccount, UserAccountModel>.Convert(user.Entity);
            }
        }

        public static List<UserTypeModel> GetAllUserTypes()
        {
            using (var context = new bbbsDbContext())
            {
                var modelList = new List<UserTypeModel>();
                foreach (var type in context.UserTypes)
                {
                    modelList.Add(AutoMapperGenericsHelper<UserType, UserTypeModel>.Convert(type));
                }
                return modelList;
            }
        }
    }
}
