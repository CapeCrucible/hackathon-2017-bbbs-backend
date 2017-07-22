using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebService.Context.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
