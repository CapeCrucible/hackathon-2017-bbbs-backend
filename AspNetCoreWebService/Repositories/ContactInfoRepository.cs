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
    public class ContactInfoRepository
    {
        public static ContactInfoModel GetUserContactInfo(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                return AutoMapperGenericsHelper<ContactInfo, ContactInfoModel>.Convert(_context.ContactInfo.FirstOrDefault(x => x.UserAccountId == userId));
            }
        }
    }
}
