using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DojoManager.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public DateTime RecordDT { get; set; }
        public int EmailConfirmed { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public int Status { get; set; }
    }

    public class PermissionFunction
    {
        public int FunctionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
    }

    public class PermissionRole
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
    }

    public class RoleFunctions
    {
        public int RoleId { get; set; }
        public List<PermissionFunction> AllowedFunctions { get; set; }
    }

    public class UserRoles
    {
        public int UserId { get; set; }
        public List<RoleFunctions> AllowedRoles { get; set; }
    }
}
