namespace BugNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("BugNet_IssueVotes")]
    public partial class IssueVote
    {
        [Key]
        public int IssueVoteId { get; set; }

        public int IssueId { get; set; }

        public Guid UserId { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Issue Issue { get; set; }
    }
}
