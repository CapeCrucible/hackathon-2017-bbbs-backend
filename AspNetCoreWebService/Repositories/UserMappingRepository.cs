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
                var unmatchedBigUserAccounts = (from ua in _context.UserAccounts
                                                join blpm in _context.BigLittleParentMaps on ua.Id equals blpm.BigId into temp
                                                from blpm in temp.DefaultIfEmpty()
                                                select ua).Distinct().ToList();

                var unmatchedBigUserAccountModels = MapToModel(unmatchedBigUserAccounts);

                return unmatchedBigUserAccountModels;
            }
        }

        public static List<UserAccountModel> FindUnmatchedLittles()
        {
            using (var _context = new bbbsDbContext())
            {
                var unmatchedLittleAccounts = (from ua in _context.UserAccounts
                                               join lpm in _context.LittleParentMaps on ua.Id equals lpm.LittleId
                                               join blpm in _context.BigLittleParentMaps on lpm.Id equals blpm.LittleParentMapId into temp
                                               from blpm in temp.DefaultIfEmpty()
                                               select ua).Distinct().ToList();

                var unmatchedLittleUserAccounts = MapToModel(unmatchedLittleAccounts);

                return unmatchedLittleUserAccounts;
            }
        }

        public static UserAccountModel FindParentForLittle(int littleId)
        {
            using (var _context = new bbbsDbContext())
            {
                var parentAccount = (from ua in _context.UserAccounts
                                     join lpm in _context.LittleParentMaps on ua.Id equals lpm.LittleId
                                     where ua.UserTypeId == 3
                                     select ua).FirstOrDefault();
                if (parentAccount != null)
                    return AutoMapperGenericsHelper<UserAccount, UserAccountModel>.Convert(parentAccount);
                else
                    throw new Exception("Parent not found for little with Id: " + littleId.ToString());
            }
        }

        private static List<UserAccountModel> MapToModel(List<UserAccount> UserAccounts)
        {
            List<UserAccountModel> userAccountModels = new List<UserAccountModel>();
            foreach (var userAccount in UserAccounts)
            {
                userAccountModels.Add(AutoMapperGenericsHelper<UserAccount, UserAccountModel>.Convert(userAccount));
            }
            return userAccountModels;
        }
    }
}
