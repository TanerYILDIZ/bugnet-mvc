using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_RolePermissions
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public virtual BugNet_Permissions Permission { get; set; }
        public virtual BugNet_Roles Role { get; set; }
    }
}
