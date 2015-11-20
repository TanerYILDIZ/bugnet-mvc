using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_Permissions
    {
        public BugNet_Permissions()
        {
            BugNet_RolePermissions = new HashSet<BugNet_RolePermissions>();
        }

        public int PermissionId { get; set; }
        public string PermissionKey { get; set; }
        public string PermissionName { get; set; }

        public virtual ICollection<BugNet_RolePermissions> BugNet_RolePermissions { get; set; }
    }
}
