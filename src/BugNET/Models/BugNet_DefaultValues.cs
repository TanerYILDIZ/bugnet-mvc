using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_DefaultValues
    {
        public int ProjectId { get; set; }
        public bool? AssignedToNotify { get; set; }
        public int? DefaultType { get; set; }
        public int? IssueAffectedMilestoneId { get; set; }
        public Guid? IssueAssignedUserId { get; set; }
        public int? IssueCategoryId { get; set; }
        public int? IssueDueDate { get; set; }
        public decimal? IssueEstimation { get; set; }
        public int? IssueMilestoneId { get; set; }
        public Guid? IssueOwnerUserId { get; set; }
        public int? IssuePriorityId { get; set; }
        public int? IssueProgress { get; set; }
        public int? IssueResolutionId { get; set; }
        public int? IssueVisibility { get; set; }
        public bool? OwnedByNotify { get; set; }
        public int? StatusId { get; set; }

        public virtual ApplicationUser IssueAssignedUser { get; set; }
        public virtual ApplicationUser IssueOwnerUser { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
