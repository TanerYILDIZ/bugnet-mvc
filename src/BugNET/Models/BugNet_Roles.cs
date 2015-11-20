using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_Roles
    {
        public BugNet_Roles()
        {
            BugNet_RolePermissions = new HashSet<BugNet_RolePermissions>();
        }

        public int RoleId { get; set; }
        public bool AutoAssign { get; set; }
        public int? ProjectId { get; set; }
        public string RoleDescription { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<BugNet_RolePermissions> BugNet_RolePermissions { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
