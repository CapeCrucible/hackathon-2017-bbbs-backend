﻿using System.Collections.Generic;

namespace AspNetCoreWebService.DTOs
{
    public class ConsolidatedUserInformationResponseModel
    {
        public UserAccountViewModel UserAccountViewModel;
        public UserAddressModel UserAddressModel;
        public ContactInfoModel ContactInfoModel;
        public IEnumerable<InterestModel> InterestModels;
    }
}