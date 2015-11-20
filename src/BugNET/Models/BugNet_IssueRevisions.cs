using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_IssueRevisions
    {
        public int IssueRevisionId { get; set; }
        public string Branch { get; set; }
        public string Changeset { get; set; }
        public DateTime DateCreated { get; set; }
        public int IssueId { get; set; }
        public string Repository { get; set; }
        public int Revision { get; set; }
        public string RevisionAuthor { get; set; }
        public string RevisionDate { get; set; }
        public string RevisionMessage { get; set; }

        public virtual BugNet_Issues Issue { get; set; }
    }
}
