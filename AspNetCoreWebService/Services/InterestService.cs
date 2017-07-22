using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Repositories;

namespace AspNetCoreWebService.Services
{
    public class InterestService
    {
        internal static IEnumerable<InterestModel> GetUserInterests(int userId)
        {
            return InterestRepository.GetUserInterests(userId);
        }

        internal static InterestUserMapModel CreateInterestUserMap(InterestUserMapModel mapModel)
        {
            return InterestRepository.CreateInterestUserMap(mapModel);
        }
    }
}
