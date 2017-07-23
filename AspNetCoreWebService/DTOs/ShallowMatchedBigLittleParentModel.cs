using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class ShallowMatchedBigLittleParentModel
    {
        public int MatchId { get; set; }
        public UserAccountViewModel Big { get; set; }
        public UserAccountViewModel Little { get; set; }
        public UserAccountViewModel Parent { get; set; }

        public ShallowMatchedBigLittleParentModel()
        {
            this.Big = new UserAccountViewModel();
            this.Little = new UserAccountViewModel();
            this.Parent = new UserAccountViewModel();
        }
    }
}
