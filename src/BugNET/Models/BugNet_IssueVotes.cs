using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_IssueVotes
    {
        public int IssueVoteId { get; set; }
        public DateTime DateCreated { get; set; }
        public int IssueId { get; set; }
        public Guid UserId { get; set; }

        public virtual BugNet_Issues Issue { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
