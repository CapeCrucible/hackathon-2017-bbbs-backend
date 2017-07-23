using System.Collections.Generic;

namespace AspNetCoreWebService.DTOs
{
    public class ConsolidatedUserInformationResponseModel
    {
        public UserAccountModel User;
        public UserAddressModel Address;
        public ContactInfoModel ContactInfo;
        public IEnumerable<InterestModel> Interest;
    }
}