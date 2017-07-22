using System.Linq;
using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;

namespace AspNetCoreWebService.Repositories
{
    public class AddressRepository
    {
        public static UserAddressModel GetAddress(int addressId)
        {
            using (var _context = new bbbsDbContext())
            {
                return AutoMapperGenericsHelper<UserAddress, UserAddressModel>.Convert(_context.UserAddresses.FirstOrDefault(x => x.Id == addressId));
            }

        }

    }
}
