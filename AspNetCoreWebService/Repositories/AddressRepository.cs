using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Helpers;
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
                var query = _context.UserAddresses.FirstOrDefault(x => x.Id == addressId);
                return new UserAddressModel
                {
                    City = query.City,
                    Id = query.Id,
                    State = query.State,
                    StreetLine1 = query.StreetLine1,
                    StreetLine2 = query.StreetLine2,
                    Zip = query.Zip
                };
            }

        }

        public static UserAddressModel CreateUserAddress(UserAddressModel addressModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newAddress = _context.Add(new UserAddress
                {
                    City = addressModel.City,
                    Zip = addressModel.Zip,
                    StreetLine1 = addressModel.StreetLine1,
                    StreetLine2 = addressModel.StreetLine2,
                    State = addressModel.State
                });
                _context.SaveChanges();
                addressModel.Id = newAddress.Entity.Id;
                return addressModel;
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
                    return userAddressModel;
                }
            }
            return null;
        }

        public static UserAddressModel GetAddressForUser(int userAccountId)
        {
            using (var _context = new bbbsDbContext())
            {
                var userAddress = (from address in _context.UserAddresses
                         join contactinfo in _context.ContactInfo on address.Id equals contactinfo.UserAddressId
                         join useraccount in _context.UserAccounts on userAccountId equals useraccount.Id
                         select address
                    ).FirstOrDefault();

                return TransformHelpers.ModelToAddress(userAddress);
            }
        }
    }
}
