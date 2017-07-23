using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class LittleParentMatchModel
    {
        public UserAccountViewModel Little { get; set; }
        public UserAccountViewModel Parent { get; set; }
    }
}
