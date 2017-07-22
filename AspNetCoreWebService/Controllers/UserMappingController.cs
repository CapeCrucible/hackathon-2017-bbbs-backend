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
    }
}
