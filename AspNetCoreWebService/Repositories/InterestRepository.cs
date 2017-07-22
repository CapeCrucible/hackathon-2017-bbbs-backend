﻿using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System.Collections.Generic;
using System.Linq;


namespace AspNetCoreWebService.Repositories
{
    public class InterestRepository
    {
        public static InterestModel CreateInterest(InterestModel interestModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newInterest = _context.Add(AutoMapperGenericsHelper<InterestModel, Interest>
                    .Convert(interestModel));
                return AutoMapperGenericsHelper<Interest, InterestModel>.Convert(newInterest.Entity);
            }
        }

        public static InterestUserMapModel CreateInterestUserMap(InterestUserMapModel mapModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newMap = _context.Add(AutoMapperGenericsHelper<InterestUserMapModel, InterestUserMap>
                    .Convert(mapModel));
                return AutoMapperGenericsHelper<InterestUserMap, InterestUserMapModel>.Convert(newMap.Entity);
            }
        }
        public static List<InterestModel> GetUserInterests(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                List<Interest> interests = (from Interest i in _context.Interests
                    join InterestUserMap ium in _context.InterestUserMaps on i.Id equals ium.InterestId
                    join UserAccount ua in _context.UserAccounts on ium.UserAccountId equals ua.Id
                    where ua.Id == userId
                    select i).Distinct().ToList();

                List<InterestModel> interestModels = new List<InterestModel>();
                foreach(var interest in interests)
                {
                    interestModels.Add(AutoMapperGenericsHelper<Interest, InterestModel>.Convert(interest));
                }
                return interestModels;
            }
        }
    }
}