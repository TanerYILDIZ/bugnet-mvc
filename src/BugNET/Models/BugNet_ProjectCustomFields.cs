using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectCustomFields
    {
        public BugNet_ProjectCustomFields()
        {
            BugNet_ProjectCustomFieldSelections = new HashSet<BugNet_ProjectCustomFieldSelections>();
            BugNet_ProjectCustomFieldValues = new HashSet<BugNet_ProjectCustomFieldValues>();
        }

        public int CustomFieldId { get; set; }
        public int CustomFieldDataType { get; set; }
        public string CustomFieldName { get; set; }
        public bool CustomFieldRequired { get; set; }
        public int CustomFieldTypeId { get; set; }
        public int ProjectId { get; set; }

        public virtual ICollection<BugNet_ProjectCustomFieldSelections> BugNet_ProjectCustomFieldSelections { get; set; }
        public virtual ICollection<BugNet_ProjectCustomFieldValues> BugNet_ProjectCustomFieldValues { get; set; }
        public virtual BugNet_ProjectCustomFieldTypes CustomFieldType { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
