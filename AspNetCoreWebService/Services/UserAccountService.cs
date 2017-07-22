﻿using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Repositories;
using Catalog.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Services
{
    public class UserAccountService
    {
        internal static UserAccountModel GetUserAccount(int userId)
        {
            return UserAccountRepository.GetUserAccount(userId);
        }

        internal static IEnumerable<UserAccountModel> GetUserAccountsByType(int typeId)
        {
            return UserAccountRepository.GetUserAccountsByType(typeId);
        }

        internal static UserAccountModel CreateUser(UserAccountModel inputModel)
        {
            return UserAccountRepository.CreateUser(inputModel);
        }
    }
}