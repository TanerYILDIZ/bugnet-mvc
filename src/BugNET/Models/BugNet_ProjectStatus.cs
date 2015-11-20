using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectStatus
    {
        public BugNet_ProjectStatus()
        {
            BugNet_Issues = new HashSet<BugNet_Issues>();
        }

        public int StatusId { get; set; }
        public bool IsClosedState { get; set; }
        public int ProjectId { get; set; }
        public int SortOrder { get; set; }
        public string StatusImageUrl { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<BugNet_Issues> BugNet_Issues { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
