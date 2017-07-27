using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class ParentLittleModel
    {
        public ConsolidatedUserInformationResponseModel Little;
        public ConsolidatedUserInformationResponseModel Parent;
        public ParentLittleModel()
        {
            Little = new ConsolidatedUserInformationResponseModel();
            Parent = new ConsolidatedUserInformationResponseModel();

            Little.interests = new List<InterestModel>();
            Parent.interests = new List<InterestModel>();

        }

    }
}
