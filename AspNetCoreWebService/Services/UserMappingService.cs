using System;
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
    }
}
