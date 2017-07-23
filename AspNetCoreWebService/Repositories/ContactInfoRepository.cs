using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System.Linq;

namespace AspNetCoreWebService.Repositories
{
    public class ContactInfoRepository
    {
        public static ContactInfoModel CreateUserContactInfo(ContactInfoModel contactInfoModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newContactInfo = _context.Add(new ContactInfo
                {
                    Email = contactInfoModel.Email,
                    PhoneNumber = contactInfoModel.PhoneNumber,
                    UserAccountId = contactInfoModel.UserAccountId,
                    UserAddressId = contactInfoModel.UserAddressId
                });
                _context.SaveChanges();
                contactInfoModel.Id = newContactInfo.Entity.Id;
                return contactInfoModel;
            }
        }

        public static ContactInfoModel GetUserContactInfo(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                var query = _context.ContactInfo.FirstOrDefault(x => x.UserAccountId == userId);
                if (query == null)
                    return null;
                return new ContactInfoModel
                {
                    Id = query.Id,
                    UserAddressId = query.UserAddressId,
                    Email = query.Email,
                    PhoneNumber = query.PhoneNumber,
                    UserAccountId = query.UserAccountId
                };
            }
        }

        public static ContactInfoModel UpdateUserContactInfo(ContactInfoModel contactInfoModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var existingContactInfo = _context.ContactInfo.FirstOrDefault(x => x.Id == contactInfoModel.Id);

                if (existingContactInfo != null)
                {
                    existingContactInfo.Email = contactInfoModel.Email;
                    existingContactInfo.PhoneNumber = contactInfoModel.PhoneNumber;
                    existingContactInfo.UserAccountId = existingContactInfo.UserAccountId;
                    existingContactInfo.UserAddressId = existingContactInfo.UserAddressId;
                    _context.SaveChanges();
                    return contactInfoModel;
                }
            }
            return null;
        }
    }
}
