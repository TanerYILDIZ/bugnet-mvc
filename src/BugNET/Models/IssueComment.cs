namespace BugNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("BugNet_IssueComments")]
    public partial class IssueComment
    {
        [Key]
        public int IssueCommentId { get; set; }

        public int IssueId { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public string Comment { get; set; }

        public Guid UserId { get; set; }

        public virtual Issue Issue { get; set; }
    }
}
