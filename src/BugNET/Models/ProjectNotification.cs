namespace BugNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("BugNet_ProjectNotifications")]
    public partial class ProjectNotification
    {
        [Key]
        public int ProjectNotificationId { get; set; }

        public int ProjectId { get; set; }

        public Guid UserId { get; set; }

        public virtual Project Projects { get; set; }
    }
}
