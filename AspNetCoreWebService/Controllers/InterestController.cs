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
    public class InterestController
    {
        [HttpGet]
        [Route("GetUserInterests/{userId}")]
        public IEnumerable<InterestModel> GetUserInterests(int userId)
        {
            return InterestService.GetUserInterests(userId);
        }
        
        [HttpGet]
        [Route("GetSharedInterests/{bigId}/{littleId")]
        public IEnumerable<InterestModel> GetSharedInterests(int bigId,int littleId)
        {
            return InterestService.GetSharedInterest(bigId,littleId);
        }

        [HttpPost]
        [Route("CreateUserInterestMap")]
        public InterestUserMapModel CreateInterestUserMap(InterestUserMapModel mapModel)
        {
            return InterestService.CreateInterestUserMap(mapModel);
        }
    }
}
