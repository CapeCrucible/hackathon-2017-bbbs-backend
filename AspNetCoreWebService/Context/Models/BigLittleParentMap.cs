﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Context.Models
{
    public class BigLittleParentMap
    {
        public int Id { get; set; }
        public int LittleParentMapId { get; set; }

        [ForeignKey("LittleParentMapId") ]
        public virtual LittleParentMap LittleParentMap { get; set; }

        public int BigId { get; set; }
        [ForeignKey("BigId")]
        public virtual UserAccount UserAccount { get; set; }
    }
}
