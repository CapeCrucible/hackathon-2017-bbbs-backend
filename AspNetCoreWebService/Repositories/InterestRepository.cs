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
    public class InterestRepository
    {
        public InterestModel CreateInterest(InterestModel interestModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newInterest = _context.Add(AutoMapperGenericsHelper<InterestModel, Interest>
                    .Convert(interestModel));
                return AutoMapperGenericsHelper<Interest, InterestModel>.Convert(newInterest.Entity);
            }
        }

        public InterestUserMapModel CreateInterestUserMap(InterestUserMapModel mapModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newMap = _context.Add(AutoMapperGenericsHelper<InterestUserMapModel, InterestUserMap>
                    .Convert(mapModel));
                return AutoMapperGenericsHelper<InterestUserMap, InterestUserMapModel>.Convert(newMap.Entity);
            }
        }
    }
}
