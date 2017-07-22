using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Repositories;
using Catalog.Common.Utilities;

namespace AspNetCoreWebService.Services
{
    public class AddressService
    {
        public static UserAddressModel GetAddress(int addressId)
        {
           return AddressRepository.GetAddress(addressId);
        }

        public static UserAddressModel CreateUserAddress(UserAddressModel addressModel)
        {
            return AddressRepository.CreateUserAddress(addressModel);
        }

        public static UserAddressModel UpdateUserAddress(UserAddressModel userAddressModel)
        {
            return AddressRepository.UpdateUserAddress(userAddressModel);
        }

    }
}
