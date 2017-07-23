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

        public static IEnumerable<InterestModel> GetSharedInterest(int bigId, int littleId)
        {
            var littleInterests = GetUserInterests(littleId);
            var bigInterests = GetUserInterests(bigId);
            return (from littleInterest in littleInterests from bigInterest in bigInterests where littleInterest.Id == bigInterest.Id select littleInterest).ToList();

        }
    }
}
