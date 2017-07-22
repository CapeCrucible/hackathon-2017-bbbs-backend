using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Repositories
{
    public class bbbsRepository
    {
        UserAccountModel GetUser(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                UserAccount userAccount = _context.UserAccounts.FirstOrDefault(x => x.Id == userId);
                return new UserAccountModel
                {
                    Id = userAccount.Id,
                    FirstName = userAccount.FirstName,
                    LastName = userAccount.LastName,
                    UserName = userAccount.UserName,
                    UserTypeId = userAccount.UserTypeId
                };
            }
        }

        //TODO: Use helper mapper for this method
        List<UserAccountModel> GetUsersByType(int typeId)
        {
            using (var _context = new bbbsDbContext())
            {
                List<UserAccountModel> userAccountModels = new List<UserAccountModel>(); 
                foreach(var userAccount in _context.UserAccounts.Where(x => x.UserTypeId == typeId).ToList())
                {
                    userAccountModels.Add(new UserAccountModel
                    {
                        Id = userAccount.Id,
                        FirstName = userAccount.FirstName,
                        LastName = userAccount.LastName,
                        UserName = userAccount.UserName,
                        UserTypeId = userAccount.UserTypeId
                    });
                }
                return userAccountModels;
            }
        }

        ContactInfoModel GetUserContactInfo(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                ContactInfo contactInfo = _context.ContactInfo.FirstOrDefault(x =>x.UserAccountId == userId);
                return new ContactInfoModel
                {
                    Id = contactInfo.Id,
                    UserId = contactInfo.UserAccountId,
                    AddressId = contactInfo.UserAddressId,
                    Email = contactInfo.Email,
                    PhoneNumber = contactInfo.PhoneNumber
                };
            }
        }

        UserAddressModel GetAddress(int addressId)
        {
            using (var _context = new bbbsDbContext())
            {
                UserAddress userAddress = _context.UserAddresses.FirstOrDefault(x => x.Id == addressId);
                
                return null;
            }

        }

        List<InterestModel> GetUserInterests(int userId)
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
                    interestModels.Add(new InterestModel
                    {
                        Id = interest.Id,
                        InterestName = interest.InterestName
                    });
                }
                return interestModels;
            }
        }

        UserAccountModel CreateUser(UserAccountModel userModel)
        {
            using (var _context = new bbbsDbContext())
            {
                _context.UserAccounts.Add(new UserAccount{
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.UserName,
                    UserTypeId = userModel.UserTypeId
                });
                _context.SaveChanges();
                return null;
            }
        }
    }
}
