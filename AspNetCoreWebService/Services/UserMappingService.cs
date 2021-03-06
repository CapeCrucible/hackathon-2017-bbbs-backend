﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Repositories;

namespace AspNetCoreWebService.Services
{
    public class UserMappingService
    {
        internal static LittleParentMapModel CreateLittleParentMap(LittleParentMapModel inputModel)
        {
            return UserMappingRepository.CreateLittleParentMap(inputModel);
        }

        internal static BigLittleParentMapModel CreateBigLittleParentMap(BigLittleParentMapModel inputModel)
        {
            return UserMappingRepository.CreateBigLittleParentMapModel(inputModel);
        }

        internal static List<UserAccountModel> FindUnmatchedBigs()
        {
            return UserMappingRepository.FindUnmatchedBigs();
        }

        internal static List<UserAccountModel> FindUnmatchedLittles()
        {
            return UserMappingRepository.FindUnmatchedLittles();
        }

        internal static ConsolidatedUserInformationResponseModel FindParentForLittle(int littleId)
        {
            return UserMappingRepository.FindParentForLittle(littleId);
        }

        internal static MatchedBigLittleParentModel GetMatch(int matchId)
        {
            return UserMappingRepository.GetMatch(matchId);
        }

        internal static List<MatchedBigLittleParentModel> GetAllMatches()
        {
            return UserMappingRepository.GetAllMatches();
        }

        internal static MatchedBigLittleParentModel GetMatchByUserAccountId(int userId)
        {
            return UserMappingRepository.GetMatchByUserAccountId(userId);
        }

        internal static void DeleteMatchById(int matchId)
        {
            UserMappingRepository.DeleteMatchById(matchId);
        }

        internal static List<ShallowMatchedBigLittleParentModel> GetAllMatchesShallow()
        {
            return UserMappingRepository.GetallMatchesShallow();
        }
    }
}
