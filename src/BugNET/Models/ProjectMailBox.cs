namespace BugNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("BugNet_ProjectMailBoxes")]
    public partial class ProjectMailbox
    {
        [Key]
        public int ProjectMailboxId { get; set; }

        [Required]
        [StringLength(100)]
        public string MailBox { get; set; }

        public int ProjectId { get; set; }

        public Guid? AssignToUserId { get; set; }

        public int? IssueTypeId { get; set; }

        public virtual IssueType ProjectIssueTypes { get; set; }

        public virtual Project Projects { get; set; }
    }
}
