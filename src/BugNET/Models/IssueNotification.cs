namespace BugNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("BugNet_IssueNotifications")]
    public partial class IssueNotification
    {
        [Key]
        public int IssueNotificationId { get; set; }

        public int IssueId { get; set; }

        public Guid UserId { get; set; }

        public virtual Issue Issue { get; set; }
    }
}
