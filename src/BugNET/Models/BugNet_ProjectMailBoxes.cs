using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectMailBoxes
    {
        public int ProjectMailboxId { get; set; }
        public Guid? AssignToUserId { get; set; }
        public int? CategoryId { get; set; }
        public int? IssueTypeId { get; set; }
        public string MailBox { get; set; }
        public int ProjectId { get; set; }

        public virtual ApplicationUser AssignToUser { get; set; }
        public virtual BugNet_ProjectCategories Category { get; set; }
        public virtual BugNet_ProjectIssueTypes IssueType { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
