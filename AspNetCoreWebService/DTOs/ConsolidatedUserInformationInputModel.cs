using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class ConsolidatedUserInformationInputModel
    {
        public UserAccountModel UserAccount;
        public UserAddressModel UserAddress;
        public ContactInfoModel ContactInfo;
        public IEnumerable<InterestModel> Interests;
    }
}
