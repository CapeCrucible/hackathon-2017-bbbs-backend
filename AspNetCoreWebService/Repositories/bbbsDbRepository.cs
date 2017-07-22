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
            using (var _context = new bbbsDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<bbbsDbContext>()))
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
            using (var _context = new bbbsDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<bbbsDbContext>()))
            {
                //return _context.UserAccounts.Where(x => x.UserTypeId == typeId).ToList();
                return null;
            }
        }

        ContactInfoModel GetUserContactInfo(int userId)
        {
            using (var _context = new bbbsDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<bbbsDbContext>()))
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
            using (var _context = new bbbsDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<bbbsDbContext>()))
            {
                UserAddress userAddress = _context.UserAddresses.FirstOrDefault(x => x.Id == addressId);
                
                return null;
            }

        }

        List<Interest> GetUserInterests(int userId)
        {
            from interests i in dbEntities
            join interest_user_map ium on i.id equals ium.interest_id
            join user_account ua on ium.user_id equals ua.id
            where ua.id == userId
}

        User CreateUser(UserModel userModel)
        {
            dbEntities.Users.Add(MapUserModelToUserDto(userModel));
            dbEntities.SaveChanges();
            return dbEntities.Select(x->x.id == userModel.id).FirstOrDefault();
        }

        private UserModel MapUserDtoToUserModel(User userDto)
        {
            return new UserModel(
                userDto.UserName,
                userDto.TypeId,
                userDto.FirstName,
                userDto.LastName
            );
        }

        private User MapUserModelToUserDto(UserModel userModel)
        {
            return new User(
                userModel.UserName,
                userModel.TypeId,
                userModel.FirstName,
                userModel.LastName
            );
        }

    }
}
