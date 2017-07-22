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
                var newContactInfo = _context.Add(AutoMapperGenericsHelper<ContactInfoModel, ContactInfo>
                    .Convert(contactInfoModel));
                return AutoMapperGenericsHelper<ContactInfo, ContactInfoModel>.Convert(newContactInfo.Entity);
            }
        }

        public static ContactInfoModel GetUserContactInfo(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                return AutoMapperGenericsHelper<ContactInfo, ContactInfoModel>.Convert(_context.ContactInfo.FirstOrDefault(x => x.UserAccountId == userId));
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
                    return AutoMapperGenericsHelper<ContactInfo, ContactInfoModel>.Convert(existingContactInfo);
                }
            }
            return null;
        }
    }
}
