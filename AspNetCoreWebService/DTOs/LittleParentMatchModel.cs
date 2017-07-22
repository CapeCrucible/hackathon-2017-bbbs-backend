using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class LittleParentMatchModel
    {
        public UserAccountModel Little { get; set; }
        public UserAccountModel Parent { get; set; }
    }
}
