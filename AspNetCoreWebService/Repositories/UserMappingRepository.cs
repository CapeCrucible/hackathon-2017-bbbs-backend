using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreWebService.Helpers;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Repositories
{
    public class UserMappingRepository
    {
        public static LittleParentMapModel CreateLittleParentMap(LittleParentMapModel mapModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newMap = _context.Add(new LittleParentMap
                {
                    LittleId = mapModel.LittleId,
                    ParentId = mapModel.ParentId
                });
                _context.SaveChanges();
                mapModel.Id = newMap.Entity.Id;
                return mapModel;
            }
        }

        public static BigLittleParentMapModel CreateBigLittleParentMapModel(BigLittleParentMapModel mapModel)
        {
            using (var _context = new bbbsDbContext())
            {
                var newMap = _context.Add(new BigLittleParentMap
                {
                    BigId = mapModel.BigId,
                    LittleParentMapId = mapModel.LittleParentMapId,
                });
                _context.SaveChanges();
                mapModel.Id = newMap.Entity.Id;
                return mapModel;
            }
        }

        internal static MatchedBigLittleParentModel GetMatch(int matchId)
        {
            using (var _context = new bbbsDbContext())
            {
                MatchedBigLittleParentModel matchedBLPM = new MatchedBigLittleParentModel();
                var matchedUsers = (from ua in _context.UserAccounts
                                    join lpm in _context.LittleParentMaps on ua.Id equals lpm.LittleId
                                    join blpm in _context.BigLittleParentMaps on lpm.Id equals blpm.LittleParentMapId
                                    where blpm.Id == matchId
                                    select ua).Distinct().ToList();

                if (matchedUsers != null)
                {
                    matchedBLPM.MatchId = matchId;
                    foreach (var match in matchedUsers)
                    {
                        switch (match.UserTypeId)
                        {
                            case 1:
                                matchedBLPM.Big = TransformHelpers.UserAccountToModel(match);
                                break;
                            case 2:
                                matchedBLPM.LittleParentMatch.Little = TransformHelpers.UserAccountToModel(match);
                                break;
                            case 3:
                                matchedBLPM.LittleParentMatch.Parent = TransformHelpers.UserAccountToModel(match);
                                break;
                        }
                    }
                    return matchedBLPM;
                }
                else
                {
                    throw new Exception("No match found for Match Id: " + matchId.ToString());
                }

            }
        }



        internal static List<MatchedBigLittleParentModel> GetAllMatches()
        {
            using (var _context = new bbbsDbContext())
            {
                var query = (from blpm in _context.BigLittleParentMaps
                             join lpm in _context.LittleParentMaps on blpm.LittleParentMapId equals lpm.Id
                             from ua in _context.UserAccounts
                             where blpm.BigId == ua.Id || lpm.LittleId == ua.Id || lpm.ParentId == ua.Id
                             select new UserAccountWithMatchId
                             {
                                 MatchId = blpm.Id,
                                 FirstName = ua.FirstName,
                                 LastName = ua.LastName,
                                 Id = ua.Id,
                                 Password = ua.Password,
                                 UserName = ua.UserName,
                                 UserTypeId = ua.UserTypeId
                             })
                            .Distinct().ToList();

                var matchesQuery = query.GroupBy(key => new { key.MatchId }, model => new UserAccountModel
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    UserTypeId = model.UserTypeId,
                    Password = model.Password
                }).ToDictionary(y => y.Key, z => z.ToList());

                List<MatchedBigLittleParentModel> matches = new List<MatchedBigLittleParentModel>();
                foreach (var key in matchesQuery.Keys)
                {
                    MatchedBigLittleParentModel currentMatch = new MatchedBigLittleParentModel();
                    foreach (var match in matchesQuery[key])
                    {
                        
                        switch (match.UserTypeId)
                        {
                            case 1:
                                currentMatch.Big = match;
                                break;
                            case 2:
                                currentMatch.LittleParentMatch.Little = match;
                                break;
                            case 3:
                                currentMatch.LittleParentMatch.Parent = match;
                                break;
                        }
                    }
                    matches.Add(currentMatch);
                }
                return matches;
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

                var unmatchedBigUserAccountModels = TransformHelpers.ListUserAccountToModel(unmatchedBigUserAccounts);

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

                var unmatchedLittleUserAccounts = TransformHelpers.ListUserAccountToModel(unmatchedLittleAccounts);

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
                    return TransformHelpers.UserAccountToModel(parentAccount);
                else
                    throw new Exception("Parent not found for little with Id: " + littleId.ToString());
            }
        }
    }
}
