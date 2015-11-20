using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_IssueHistory
    {
        public int IssueHistoryId { get; set; }
        public DateTime DateCreated { get; set; }
        public string FieldChanged { get; set; }
        public int IssueId { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }
        public Guid UserId { get; set; }

        public virtual BugNet_Issues Issue { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
