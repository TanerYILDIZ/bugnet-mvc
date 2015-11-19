namespace BugNET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("BugNet_RelatedIssues")]
    public partial class RelatedIssue
    {
        public int PrimaryIssueId { get; set; }

        public int SecondaryIssueId { get; set; }

        public int RelationType { get; set; }

        public virtual Issue PrimaryIssue { get; set; }

        public virtual Issue SecondaryIssue { get; set; }
    }
}
