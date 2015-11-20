using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectPriorities
    {
        public BugNet_ProjectPriorities()
        {
            BugNet_Issues = new HashSet<BugNet_Issues>();
        }

        public int PriorityId { get; set; }
        public string PriorityImageUrl { get; set; }
        public string PriorityName { get; set; }
        public int ProjectId { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<BugNet_Issues> BugNet_Issues { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
