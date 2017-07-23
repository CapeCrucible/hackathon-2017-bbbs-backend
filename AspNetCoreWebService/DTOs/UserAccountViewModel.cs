using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.DTOs
{
    public class UserAccountViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserTypeModel UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
