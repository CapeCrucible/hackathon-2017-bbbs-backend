using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class MatchedBigLittleParentModel
    {
        public int MatchId { get; set; }
        public ConsolidatedUserInformationResponseModel Big { get; set; }
        public ConsolidatedUserInformationResponseModel Little { get; set; }
        public ConsolidatedUserInformationResponseModel Parent { get; set; }
        

        public MatchedBigLittleParentModel()
        {
            this.Big = new ConsolidatedUserInformationResponseModel();
            this.Little = new ConsolidatedUserInformationResponseModel();
            this.Parent = new ConsolidatedUserInformationResponseModel();
        }
    }
}
