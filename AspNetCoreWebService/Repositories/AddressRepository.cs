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

        public static UserAddressModel UpdateUserAddress(UserAddressModel userAddressModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var existingUserAddress = _context.UserAddresses.FirstOrDefault(x => x.Id == userAddressModel.Id);

                if (existingUserAddress != null)
                {
                    existingUserAddress.StreetLine1 = userAddressModel.StreetLine1;
                    existingUserAddress.StreetLine2 = userAddressModel.StreetLine2;
                    existingUserAddress.City = userAddressModel.City;
                    existingUserAddress.State = userAddressModel.State;
                    existingUserAddress.Zip = userAddressModel.Zip;
                    _context.SaveChanges();
                    return AutoMapperGenericsHelper<UserAddress, UserAddressModel>.Convert(existingUserAddress);
                }
            }
            return null;
        }
    }
}
