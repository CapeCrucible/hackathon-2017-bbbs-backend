using System.Collections.Generic;

namespace AspNetCoreWebService.DTOs
{
    public class ConsolidatedUserInformationResponseModel
    {
        public ConsolidatedUserInformationResponseModel()
        {
            user = new UserAccountViewModel();
            address = new UserAddressModel();
            contactInfo = new ContactInfoModel();
        }

        public UserAccountViewModel user;
        public UserAddressModel address;
        public ContactInfoModel contactInfo;
        public IEnumerable<InterestModel> interests;
    }
}