using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_IssueNotifications
    {
        public int IssueNotificationId { get; set; }
        public int IssueId { get; set; }
        public Guid UserId { get; set; }

        public virtual BugNet_Issues Issue { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
