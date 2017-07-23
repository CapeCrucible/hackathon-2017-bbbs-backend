using AspNetCoreWebService.Context;
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
                var newInterest = _context.Add(new Interest
                {
                    InterestName = interestModel.InterestName
                });
                _context.SaveChanges();
                interestModel.Id = newInterest.Entity.Id;
                return interestModel;
            }
        }

        public static InterestUserMapModel CreateInterestUserMap(InterestUserMapModel mapModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newMap = _context.Add(new InterestUserMap
                {
                    InterestId = mapModel.InterestId,
                    UserAccountId = mapModel.UserAccountId
                });
                _context.SaveChanges();
                mapModel.Id = newMap.Entity.Id;
                return mapModel;
            }
        }
        public static List<InterestModel> GetUserInterests(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                var interests = (from Interest i in _context.Interests
                                            join ium in _context.InterestUserMaps on i.Id equals ium.InterestId
                                            join ua in _context.UserAccounts on ium.UserAccountId equals ua.Id
                                            where ua.Id == userId
                                            select i).Distinct().ToList();

                List<InterestModel> interestModels = new List<InterestModel>();
                foreach (var interest in interests)
                {
                    interestModels.Add(new InterestModel
                    {
                        Id = interest.Id,
                        InterestName = interest.InterestName
                    });
                }
                return interestModels;
            }
        }
    }
}
