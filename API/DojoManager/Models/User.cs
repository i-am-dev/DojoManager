using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingJWT.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
