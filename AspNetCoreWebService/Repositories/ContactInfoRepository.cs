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
    }
}
