using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class ConsolidatedUserInformationModel
    {
        public UserAccountModel UserAccountModel { get; set; }
        public ContactInfoModel ContactInfoModel { get; set; }
        public UserAddressModel UserAddressModel { get; set; }
    }
}
