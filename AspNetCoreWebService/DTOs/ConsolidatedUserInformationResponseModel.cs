using System.Collections.Generic;

namespace AspNetCoreWebService.DTOs
{
    public class ConsolidatedUserInformationResponseModel
    {
        public UserAccountModel UserAccountModel;
        public UserAddressModel UserAddressModel;
        public ContactInfoModel ContactInfoModel;
        public IEnumerable<InterestModel> InterestModels;
    }
}