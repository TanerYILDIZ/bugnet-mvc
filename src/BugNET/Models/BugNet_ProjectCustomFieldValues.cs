using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectCustomFieldValues
    {
        public int CustomFieldValueId { get; set; }
        public int CustomFieldId { get; set; }
        public string CustomFieldValue { get; set; }
        public int IssueId { get; set; }

        public virtual BugNet_ProjectCustomFields CustomField { get; set; }
        public virtual BugNet_Issues Issue { get; set; }
    }
}
