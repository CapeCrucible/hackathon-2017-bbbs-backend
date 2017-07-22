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
    public class AddressRepository
    {
        public UserAddressModel CreateUserAddress(UserAddressModel addressModel)
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
