using AspNetCoreWebService.DTOs;
using AspNetCoreWebService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Controllers
{
    [Route("api/[controller]")]
    public class UserMappingController
    {
        [HttpPost]
        [Route("CreateLittleParentMap")]
        public LittleParentMapModel CreateLittleParentMap(LittleParentMapModel inputModel)
        {
            return UserMappingService.CreateLittleParentMap(inputModel);
        }

        [HttpPost]
        [Route("CreateBigLittleParentMap")]
        public BigLittleParentMapModel CreateBigLittleParentMap(BigLittleParentMapModel inputModel)
        {
            return UserMappingService.CreateBigLittleParentMap(inputModel);
        }

        [HttpGet]
        [Route("FindUnmatchedBigs")]
        public List<UserAccountModel> FindUnmatchedBigs()
        {
            return UserMappingService.FindUnmatchedBigs();
        }

        [HttpGet]
        [Route("FindUnmatchedLittles")]
        public List<UserAccountModel> FindUnmatchedLittles()
        {
            return UserMappingService.FindUnmatchedLittles();
        }

        [HttpGet]
        [Route("FindParentForLittle/{littleId}")]
        public UserAccountModel FindParentForLittle(int littleId)
        {
            return UserMappingService.FindParentForLittle(littleId);
        }

        [HttpGet]
        [Route("GetMatch/{matchId}")]
        public MatchedBigLittleParentModel GetMatch(int matchId)
        {
            return UserMappingService.GetMatch(matchId);
        }

        [HttpGet]
        [Route("GetAllMatches")]
        public List<MatchedBigLittleParentModel> GetAllMatches()
        {
            return UserMappingService.GetAllMatches();
        }
    }
}
