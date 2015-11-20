using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectResolutions
    {
        public BugNet_ProjectResolutions()
        {
            BugNet_Issues = new HashSet<BugNet_Issues>();
        }

        public int ResolutionId { get; set; }
        public int ProjectId { get; set; }
        public string ResolutionImageUrl { get; set; }
        public string ResolutionName { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<BugNet_Issues> BugNet_Issues { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
