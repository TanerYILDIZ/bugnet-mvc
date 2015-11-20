using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_Projects
    {
        public BugNet_Projects()
        {
            BugNet_Issues = new HashSet<BugNet_Issues>();
            BugNet_ProjectCategories = new HashSet<BugNet_ProjectCategories>();
            BugNet_ProjectCustomFields = new HashSet<BugNet_ProjectCustomFields>();
            BugNet_ProjectIssueTypes = new HashSet<BugNet_ProjectIssueTypes>();
            BugNet_ProjectMailBoxes = new HashSet<BugNet_ProjectMailBoxes>();
            BugNet_ProjectMilestones = new HashSet<BugNet_ProjectMilestones>();
            BugNet_ProjectNotifications = new HashSet<BugNet_ProjectNotifications>();
            BugNet_ProjectPriorities = new HashSet<BugNet_ProjectPriorities>();
            BugNet_ProjectResolutions = new HashSet<BugNet_ProjectResolutions>();
            BugNet_ProjectStatus = new HashSet<BugNet_ProjectStatus>();
            BugNet_Queries = new HashSet<BugNet_Queries>();
            BugNet_Roles = new HashSet<BugNet_Roles>();
            BugNet_UserProjects = new HashSet<BugNet_UserProjects>();
        }

        public int ProjectId { get; set; }
        public bool AllowAttachments { get; set; }
        public bool AllowIssueVoting { get; set; }
        public string AttachmentUploadPath { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProjectAccessType { get; set; }
        public string ProjectCode { get; set; }
        public Guid ProjectCreatorUserId { get; set; }
        public string ProjectDescription { get; set; }
        public bool ProjectDisabled { get; set; }
        public string ProjectImageContentType { get; set; }
        public byte[] ProjectImageFileContent { get; set; }
        public string ProjectImageFileName { get; set; }
        public long? ProjectImageFileSize { get; set; }
        public Guid ProjectManagerUserId { get; set; }
        public string ProjectName { get; set; }
        public string SvnRepositoryUrl { get; set; }

        public virtual BugNet_DefaultValues BugNet_DefaultValues { get; set; }
        public virtual ICollection<BugNet_Issues> BugNet_Issues { get; set; }
        public virtual ICollection<BugNet_ProjectCategories> BugNet_ProjectCategories { get; set; }
        public virtual ICollection<BugNet_ProjectCustomFields> BugNet_ProjectCustomFields { get; set; }
        public virtual ICollection<BugNet_ProjectIssueTypes> BugNet_ProjectIssueTypes { get; set; }
        public virtual ICollection<BugNet_ProjectMailBoxes> BugNet_ProjectMailBoxes { get; set; }
        public virtual ICollection<BugNet_ProjectMilestones> BugNet_ProjectMilestones { get; set; }
        public virtual ICollection<BugNet_ProjectNotifications> BugNet_ProjectNotifications { get; set; }
        public virtual ICollection<BugNet_ProjectPriorities> BugNet_ProjectPriorities { get; set; }
        public virtual ICollection<BugNet_ProjectResolutions> BugNet_ProjectResolutions { get; set; }
        public virtual ICollection<BugNet_ProjectStatus> BugNet_ProjectStatus { get; set; }
        public virtual ICollection<BugNet_Queries> BugNet_Queries { get; set; }
        public virtual ICollection<BugNet_Roles> BugNet_Roles { get; set; }
        public virtual ICollection<BugNet_UserProjects> BugNet_UserProjects { get; set; }
        public virtual ApplicationUser ProjectCreatorUser { get; set; }
        public virtual ApplicationUser ProjectManagerUser { get; set; }
    }
}
