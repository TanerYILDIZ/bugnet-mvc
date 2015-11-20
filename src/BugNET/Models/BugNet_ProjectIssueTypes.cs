using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectIssueTypes
    {
        public BugNet_ProjectIssueTypes()
        {
            BugNet_Issues = new HashSet<BugNet_Issues>();
            BugNet_ProjectMailBoxes = new HashSet<BugNet_ProjectMailBoxes>();
        }

        public int IssueTypeId { get; set; }
        public string IssueTypeImageUrl { get; set; }
        public string IssueTypeName { get; set; }
        public int ProjectId { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<BugNet_Issues> BugNet_Issues { get; set; }
        public virtual ICollection<BugNet_ProjectMailBoxes> BugNet_ProjectMailBoxes { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
