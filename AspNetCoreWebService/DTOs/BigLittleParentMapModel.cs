using AspNetCoreWebService.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class BigLittleParentMapModel
    {
        public int MatchId { get; set; }
        public int LittleId { get; set; }
        public int BigId { get; set; }
        public int ParentId { get; set; }
    }
}
