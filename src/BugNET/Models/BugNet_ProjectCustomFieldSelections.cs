using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectCustomFieldSelections
    {
        public int CustomFieldSelectionId { get; set; }
        public int CustomFieldId { get; set; }
        public string CustomFieldSelectionName { get; set; }
        public int CustomFieldSelectionSortOrder { get; set; }
        public string CustomFieldSelectionValue { get; set; }

        public virtual BugNet_ProjectCustomFields CustomField { get; set; }
    }
}
