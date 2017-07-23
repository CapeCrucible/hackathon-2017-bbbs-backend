using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class ContactInfoModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }

        public int UserAddressId { get; set; }
        public virtual UserAddressModel UserAddress { get; set; }

        public string Email { get; set; }

        public int UserAccountId { get; set; }
        public virtual UserAccountModel UserAccount { get; set; }
    }
}
