using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Context.Models
{
    public class InterestUserMap
    {
        public int Id { get; set; }

        public int UserAccountId { get; set; }
        [ForeignKey("UserAccountId")]
        public virtual UserAccount UserAccount { get; set; }

        public int InterestId { get; set; }
        [ForeignKey("InterestId")]
        public virtual Interest Interest { get; set; }
    }
}
