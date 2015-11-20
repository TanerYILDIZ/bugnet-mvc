using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_UserProjects
    {
        public Guid UserId { get; set; }
        public int ProjectId { get; set; }

        public virtual BugNet_Projects Project { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
