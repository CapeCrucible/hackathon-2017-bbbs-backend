﻿using AspNetCoreWebService.Context;
using AspNetCoreWebService.Context.Models;
using AspNetCoreWebService.DTOs;
using Catalog.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreWebService.Helpers;
using System.Threading.Tasks;
using AspNetCoreWebService.Controllers;
using AspNetCoreWebService.Services;

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
                int parentId = FindParentForLittle(mapModel.LittleId).Id;

                var parentLittleMatch = (from lpm in _context.LittleParentMaps
                                         where lpm.LittleId == mapModel.LittleId
                                         && lpm.ParentId == parentId
                                         select lpm).FirstOrDefault();

                var newMap = _context.Add(new BigLittleParentMap
                {
                    BigId = mapModel.BigId,
                    LittleParentMapId = parentLittleMatch.Id,
                });
                _context.SaveChanges();
                mapModel.Id = newMap.Entity.Id;
                return mapModel;
                //FINISH THIS METHOD BY MAKING IT POSTABLE
            }
        }

        internal static MatchedBigLittleParentModel GetMatchByUserAccountId(int userId)
        {
            using (var _context = new bbbsDbContext())
            {
                MatchedBigLittleParentModel matchedBLPM = new MatchedBigLittleParentModel();
                var match = (from blpm in _context.BigLittleParentMaps
                             join lpm in _context.LittleParentMaps on blpm.LittleParentMapId equals lpm.Id
                             where blpm.BigId == userId || lpm.LittleId == userId
                             select blpm
                            ).FirstOrDefault();

                if (match == null)
                    return null;

                return GetMatch(match.Id);
            }
        }

        internal static MatchedBigLittleParentModel GetMatch(int matchId)
        {
            using (var _context = new bbbsDbContext())
            {
                MatchedBigLittleParentModel matchedBLPM = new MatchedBigLittleParentModel();
                var matchedUsers = (from ua in _context.UserAccounts
                                    from lpm in _context.LittleParentMaps
                                    from blpm in _context.BigLittleParentMaps
                                    where lpm.Id == blpm.LittleParentMapId
                                    && ((blpm.Id == matchId) && (ua.Id == lpm.LittleId || ua.Id == lpm.ParentId || ua.Id == blpm.BigId))
                                    select ua).Distinct().ToList();

                if (matchedUsers != null)
                {
                    matchedBLPM.MatchId = matchId;
                    foreach (var match in matchedUsers)
                    {
                        var newModel = new ConsolidatedUserInformationResponseModel();

                        newModel.user = TransformHelpers.ModelToUserAccountViewModel(UserAccountService.GetUserAccount(match.Id));
                        newModel.address = AddressService.GetAddressForUser(match.Id);
                        newModel.contactInfo.UserAddressId = newModel.address.Id;
                        newModel.contactInfo = ContactInfoService.GetUserContactInfo(match.Id);
                        newModel.interests = InterestService.GetUserInterests(match.Id);

                        switch (match.UserTypeId)
                        {
                            case 1:
                                matchedBLPM.Big = newModel;
                                break;
                            case 2:
                                matchedBLPM.Little = newModel;
                                break;
                            case 3:
                                matchedBLPM.Parent = newModel;
                                break;
                        }
                    }
                    return matchedBLPM;
                }
                else
                {
                    return null;
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
                        var newModel = new ConsolidatedUserInformationResponseModel();

                        newModel.user = TransformHelpers.ModelToUserAccountViewModel(UserAccountService.GetUserAccount(match.Id));
                        newModel.address = AddressService.GetAddressForUser(match.Id);
                        newModel.contactInfo.UserAddressId = newModel.address.Id;
                        newModel.contactInfo = ContactInfoService.GetUserContactInfo(match.Id);
                        newModel.interests = InterestService.GetUserInterests(match.Id);

                        switch (match.UserTypeId)
                        {
                            case 1:
                                currentMatch.Big = newModel;
                                break;
                            case 2:
                                currentMatch.Little = newModel;
                                break;
                            case 3:
                                currentMatch.Parent = newModel;
                                break;
                        }
                    }
                    currentMatch.MatchId = key.MatchId;
                    matches.Add(currentMatch);
                }
                return matches;
            }
        }

        public static List<UserAccountModel> FindUnmatchedBigs()
        {
            using (var _context = new bbbsDbContext())
            {
                var matchedBigUserAccounts = (from ua in _context.UserAccounts
                                              join blpm in _context.BigLittleParentMaps on ua.Id equals blpm.BigId
                                              select ua).Distinct().ToList();

                var unmatchedBigUserAccounts = (from ua in _context.UserAccounts
                                                where !matchedBigUserAccounts.Contains(ua) && ua.UserTypeId == 1
                                                select ua).Distinct().ToList();

                var unmatchedBigUserAccountModels = TransformHelpers.ListUserAccountToModel(unmatchedBigUserAccounts);

                return unmatchedBigUserAccountModels;
            }
        }

        public static List<UserAccountModel> FindUnmatchedLittles()
        {
            using (var _context = new bbbsDbContext())
            {
                var matchedLittleAccounts = (from ua in _context.UserAccounts
                                             join lpm in _context.LittleParentMaps on ua.Id equals lpm.LittleId
                                             join blpm in _context.BigLittleParentMaps on lpm.Id equals blpm.LittleParentMapId
                                             select ua).Distinct().ToList();

                var unmatchedLittleAccounts = (from ua in _context.UserAccounts
                                               where !matchedLittleAccounts.Contains(ua) && ua.UserTypeId == 2
                                               select ua).Distinct().ToList();

                var unmatchedLittleUserAccounts = TransformHelpers.ListUserAccountToModel(unmatchedLittleAccounts);

                return unmatchedLittleUserAccounts;
            }
        }

        public static UserAccountModel FindParentForLittle(int littleId)
        {
            using (var _context = new bbbsDbContext())
            {
                var mapping = (from lpm in _context.LittleParentMaps
                               where lpm.LittleId == littleId
                               select lpm).FirstOrDefault();

                var parentAccount = _context.UserAccounts.FirstOrDefault(x => x.Id == mapping.ParentId);

                if (parentAccount != null)
                    return TransformHelpers.UserAccountToModel(parentAccount);
                else
                    return null;
            }
        }
    }
}
