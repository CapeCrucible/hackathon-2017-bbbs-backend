using System.Collections.Generic;

namespace AspNetCoreWebService.DTOs
{
    public class ConsolidatedUserInformationResponseModel
    {
        public ConsolidatedUserInformationResponseModel()
        {
            UserAccountViewModel = new UserAccountViewModel();
            UserAddressModel = new UserAddressModel();
            ContactInfoModel = new ContactInfoModel();
        }

        public UserAccountViewModel UserAccountViewModel;
        public UserAddressModel UserAddressModel;
        public ContactInfoModel ContactInfoModel;
        public IEnumerable<InterestModel> InterestModels;
    }
}