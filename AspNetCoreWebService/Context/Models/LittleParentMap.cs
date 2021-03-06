﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Context.Models
{
    public class LittleParentMap
    {
        public int Id { get; set; }

        public int LittleId { get; set; }
        [ForeignKey("LittleId")]
        public virtual UserAccount Little { get; set; }

        public int ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual UserAccount Parent { get; set; }
    }
}
