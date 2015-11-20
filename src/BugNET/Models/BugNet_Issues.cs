using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_Issues
    {
        public BugNet_Issues()
        {
            BugNet_IssueAttachments = new HashSet<BugNet_IssueAttachments>();
            BugNet_IssueComments = new HashSet<BugNet_IssueComments>();
            BugNet_IssueHistory = new HashSet<BugNet_IssueHistory>();
            BugNet_IssueNotifications = new HashSet<BugNet_IssueNotifications>();
            BugNet_IssueRevisions = new HashSet<BugNet_IssueRevisions>();
            BugNet_IssueVotes = new HashSet<BugNet_IssueVotes>();
            BugNet_IssueWorkReports = new HashSet<BugNet_IssueWorkReports>();
            BugNet_ProjectCustomFieldValues = new HashSet<BugNet_ProjectCustomFieldValues>();
            BugNet_RelatedIssues = new HashSet<BugNet_RelatedIssues>();
            BugNet_RelatedIssuesNavigation = new HashSet<BugNet_RelatedIssues>();
        }

        public int IssueId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Disabled { get; set; }
        public int? IssueAffectedMilestoneId { get; set; }
        public Guid? IssueAssignedUserId { get; set; }
        public int? IssueCategoryId { get; set; }
        public Guid IssueCreatorUserId { get; set; }
        public string IssueDescription { get; set; }
        public DateTime? IssueDueDate { get; set; }
        public decimal IssueEstimation { get; set; }
        public int? IssueMilestoneId { get; set; }
        public Guid? IssueOwnerUserId { get; set; }
        public int? IssuePriorityId { get; set; }
        public int IssueProgress { get; set; }
        public int? IssueResolutionId { get; set; }
        public int? IssueStatusId { get; set; }
        public string IssueTitle { get; set; }
        public int? IssueTypeId { get; set; }
        public int IssueVisibility { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid LastUpdateUserId { get; set; }
        public int ProjectId { get; set; }

        public virtual ICollection<BugNet_IssueAttachments> BugNet_IssueAttachments { get; set; }
        public virtual ICollection<BugNet_IssueComments> BugNet_IssueComments { get; set; }
        public virtual ICollection<BugNet_IssueHistory> BugNet_IssueHistory { get; set; }
        public virtual ICollection<BugNet_IssueNotifications> BugNet_IssueNotifications { get; set; }
        public virtual ICollection<BugNet_IssueRevisions> BugNet_IssueRevisions { get; set; }
        public virtual ICollection<BugNet_IssueVotes> BugNet_IssueVotes { get; set; }
        public virtual ICollection<BugNet_IssueWorkReports> BugNet_IssueWorkReports { get; set; }
        public virtual ICollection<BugNet_ProjectCustomFieldValues> BugNet_ProjectCustomFieldValues { get; set; }
        public virtual ICollection<BugNet_RelatedIssues> BugNet_RelatedIssues { get; set; }
        public virtual ICollection<BugNet_RelatedIssues> BugNet_RelatedIssuesNavigation { get; set; }
        public virtual BugNet_ProjectMilestones IssueAffectedMilestone { get; set; }
        public virtual ApplicationUser IssueAssignedUser { get; set; }
        public virtual BugNet_ProjectCategories IssueCategory { get; set; }
        public virtual ApplicationUser IssueCreatorUser { get; set; }
        public virtual BugNet_ProjectMilestones IssueMilestone { get; set; }
        public virtual ApplicationUser IssueOwnerUser { get; set; }
        public virtual BugNet_ProjectPriorities IssuePriority { get; set; }
        public virtual BugNet_ProjectResolutions IssueResolution { get; set; }
        public virtual BugNet_ProjectStatus IssueStatus { get; set; }
        public virtual BugNet_ProjectIssueTypes IssueType { get; set; }
        public virtual ApplicationUser LastUpdateUser { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
