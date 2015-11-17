namespace BugNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("BugNet_IssueWorkReports")]
    public partial class IssueWorkReport
    {
        [Key]
        public int IssueWorkReportId { get; set; }

        public int IssueId { get; set; }

        public DateTime WorkDate { get; set; }

        public decimal Duration { get; set; }

        public int IssueCommentId { get; set; }

        public Guid UserId { get; set; }

        public virtual Issue Issue { get; set; }
    }
}
