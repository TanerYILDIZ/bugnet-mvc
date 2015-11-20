using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_IssueAttachments
    {
        public int IssueAttachmentId { get; set; }
        public byte[] Attachment { get; set; }
        public string ContentType { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public int IssueId { get; set; }
        public Guid UserId { get; set; }

        public virtual BugNet_Issues Issue { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
