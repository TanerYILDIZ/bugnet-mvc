using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_IssueWorkReports
    {
        public int IssueWorkReportId { get; set; }
        public decimal Duration { get; set; }
        public int IssueCommentId { get; set; }
        public int IssueId { get; set; }
        public Guid UserId { get; set; }
        public DateTime WorkDate { get; set; }

        public virtual BugNet_Issues Issue { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
