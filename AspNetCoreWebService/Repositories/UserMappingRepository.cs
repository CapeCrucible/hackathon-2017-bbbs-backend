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
    public class UserMappingRepository
    {
        public static LittleParentMapModel CreateLittleParentMap(LittleParentMapModel mapModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newMap = _context.Add(AutoMapperGenericsHelper<LittleParentMapModel, LittleParentMap>
                    .Convert(mapModel));
                return AutoMapperGenericsHelper<LittleParentMap, LittleParentMapModel>.Convert(newMap.Entity);
            }
        }

        public static BigLittleParentMapModel CreateBigLittleParentMapModel(BigLittleParentMapModel mapModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newMap = _context.Add(AutoMapperGenericsHelper<BigLittleParentMapModel, BigLittleParentMap>
                    .Convert(mapModel));
                return AutoMapperGenericsHelper<BigLittleParentMap, BigLittleParentMapModel>.Convert(newMap.Entity);
            }
        }

        public static List<UserAccountModel> FindUnmatchedBigs()
        {
            using (var _context = new bbbsDbContext())
            {
                //List<Interest> interests = (from Interest i in _context.Interests
                //                            join InterestUserMap ium in _context.InterestUserMaps on i.Id equals ium.InterestId
                //                            join UserAccount ua in _context.UserAccounts on ium.UserAccountId equals ua.Id
                //                            where ua.Id == userId
                //                            select i).Distinct().ToList();

                return null;
            }
        }
    }
}
