using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class MatchedBigLittleParentModel
    {
        public int MatchId { get; set; }
        public UserAccountViewModel Big { get; set; }
        public LittleParentMatchModel LittleParentMatch { get; set; }

        public MatchedBigLittleParentModel()
        {
            this.Big = new UserAccountViewModel();
            this.LittleParentMatch = new LittleParentMatchModel();
        }
    }
}
