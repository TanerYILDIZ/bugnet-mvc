using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectCustomFieldTypes
    {
        public BugNet_ProjectCustomFieldTypes()
        {
            BugNet_ProjectCustomFields = new HashSet<BugNet_ProjectCustomFields>();
        }

        public int CustomFieldTypeId { get; set; }
        public string CustomFieldTypeName { get; set; }

        public virtual ICollection<BugNet_ProjectCustomFields> BugNet_ProjectCustomFields { get; set; }
    }
}
