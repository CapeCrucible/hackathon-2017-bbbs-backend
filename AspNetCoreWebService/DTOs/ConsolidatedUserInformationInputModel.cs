using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class ConsolidatedUserInformationInputModel
    {
        public UserAccountModel UserAccountModel;
        public UserAddressModel UserAddressModel;
        public ContactInfoModel ContactInfoModel;
        public IEnumerable<InterestModel> InterestModels;
    }
}
