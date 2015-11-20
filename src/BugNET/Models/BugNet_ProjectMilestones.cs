using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectMilestones
    {
        public BugNet_ProjectMilestones()
        {
            BugNet_Issues = new HashSet<BugNet_Issues>();
            BugNet_IssuesNavigation = new HashSet<BugNet_Issues>();
        }

        public int MilestoneId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool MilestoneCompleted { get; set; }
        public DateTime? MilestoneDueDate { get; set; }
        public string MilestoneImageUrl { get; set; }
        public string MilestoneName { get; set; }
        public string MilestoneNotes { get; set; }
        public DateTime? MilestoneReleaseDate { get; set; }
        public int ProjectId { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<BugNet_Issues> BugNet_Issues { get; set; }
        public virtual ICollection<BugNet_Issues> BugNet_IssuesNavigation { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
