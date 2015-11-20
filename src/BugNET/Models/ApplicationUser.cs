using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugNET.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            BugNet_DefaultValues = new HashSet<BugNet_DefaultValues>();
            BugNet_DefaultValuesNavigation = new HashSet<BugNet_DefaultValues>();
            BugNet_IssueAttachments = new HashSet<BugNet_IssueAttachments>();
            BugNet_IssueComments = new HashSet<BugNet_IssueComments>();
            BugNet_IssueHistory = new HashSet<BugNet_IssueHistory>();
            BugNet_IssueNotifications = new HashSet<BugNet_IssueNotifications>();
            BugNet_Issues = new HashSet<BugNet_Issues>();
            BugNet_IssuesNavigation = new HashSet<BugNet_Issues>();
            BugNet_Issues1 = new HashSet<BugNet_Issues>();
            BugNet_Issues2 = new HashSet<BugNet_Issues>();
            BugNet_IssueVotes = new HashSet<BugNet_IssueVotes>();
            BugNet_IssueWorkReports = new HashSet<BugNet_IssueWorkReports>();
            BugNet_ProjectMailBoxes = new HashSet<BugNet_ProjectMailBoxes>();
            BugNet_ProjectNotifications = new HashSet<BugNet_ProjectNotifications>();
            BugNet_Projects = new HashSet<BugNet_Projects>();
            BugNet_ProjectsNavigation = new HashSet<BugNet_Projects>();
            BugNet_Queries = new HashSet<BugNet_Queries>();
            BugNet_UserProjects = new HashSet<BugNet_UserProjects>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_DefaultValues> BugNet_DefaultValues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_DefaultValues> BugNet_DefaultValuesNavigation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_IssueAttachments> BugNet_IssueAttachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_IssueComments> BugNet_IssueComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_IssueHistory> BugNet_IssueHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_IssueNotifications> BugNet_IssueNotifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_Issues> BugNet_Issues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_Issues> BugNet_IssuesNavigation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_Issues> BugNet_Issues1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_Issues> BugNet_Issues2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_IssueVotes> BugNet_IssueVotes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_IssueWorkReports> BugNet_IssueWorkReports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_ProjectMailBoxes> BugNet_ProjectMailBoxes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_ProjectNotifications> BugNet_ProjectNotifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_Projects> BugNet_Projects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_Projects> BugNet_ProjectsNavigation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_Queries> BugNet_Queries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BugNet_UserProjects> BugNet_UserProjects { get; set; }
    }
}
