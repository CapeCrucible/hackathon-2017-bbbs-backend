using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class InterestUserMapModel
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public int InterestId { get; set; }
    }
}
