using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementApplication.Models
{
    public class Users
    {
        public int UserIdx { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public bool PublicYn { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime RegistDate { get; set; }
    }
}
