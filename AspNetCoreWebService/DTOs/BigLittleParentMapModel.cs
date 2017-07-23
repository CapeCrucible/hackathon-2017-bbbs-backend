using AspNetCoreWebService.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class BigLittleParentMapModel
    {
        public int Id { get; set; }
        public int LittleParentMapId { get; set; }
       // public virtual LittleParentMap LittleParentMap { get; set; }
        public int BigId { get; set; }
    }
}
