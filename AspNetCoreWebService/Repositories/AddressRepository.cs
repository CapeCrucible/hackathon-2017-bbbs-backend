using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System.Linq;


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

        public static UserAddressModel CreateUserAddress(UserAddressModel addressModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newAddress = _context.Add(AutoMapperGenericsHelper<UserAddressModel, UserAddress>
                    .Convert(addressModel));
                return AutoMapperGenericsHelper<UserAddress, UserAddressModel>.Convert(newAddress.Entity);
            }
        }
    }
}
