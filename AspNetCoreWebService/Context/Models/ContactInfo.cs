using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Context.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }

        public int UserAddressId { get; set; }
        public virtual UserAddress UserAddress { get; set; }


        public int UserAccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }

        public string Email { get; set; }
    }
}
