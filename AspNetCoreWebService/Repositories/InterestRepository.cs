using System.Collections.Generic;
using System.Linq;
using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;

namespace AspNetCoreWebService.Repositories
{
    public class InterestRepository
    {
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
