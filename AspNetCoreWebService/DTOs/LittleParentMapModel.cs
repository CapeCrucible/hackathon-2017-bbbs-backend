using AspNetCoreWebService.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class LittleParentMapModel
    {
        public int Id { get; set; }

        public int LittleId { get; set; }
        public virtual UserAccount Little { get; set; }

        public int ParentId { get; set; }
        public virtual UserAccount Parent { get; set; }
    }
}
