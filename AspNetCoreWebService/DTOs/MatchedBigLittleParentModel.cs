using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class MatchedBigLittleParentModel
    {
        public int MatchId { get; set; }
        public UserAccountModel Big { get; set; }
        public LittleParentMatchModel LittleParentMatch { get; set; }
    }
}
