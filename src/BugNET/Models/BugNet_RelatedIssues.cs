using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_RelatedIssues
    {
        public int PrimaryIssueId { get; set; }
        public int SecondaryIssueId { get; set; }
        public int RelationType { get; set; }

        public virtual BugNet_Issues PrimaryIssue { get; set; }
        public virtual BugNet_Issues SecondaryIssue { get; set; }
    }
}
