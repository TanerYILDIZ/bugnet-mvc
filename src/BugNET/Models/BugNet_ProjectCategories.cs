using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_ProjectCategories
    {
        public BugNet_ProjectCategories()
        {
            BugNet_Issues = new HashSet<BugNet_Issues>();
            BugNet_ProjectMailBoxes = new HashSet<BugNet_ProjectMailBoxes>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Disabled { get; set; }
        public int ParentCategoryId { get; set; }
        public int ProjectId { get; set; }

        public virtual ICollection<BugNet_Issues> BugNet_Issues { get; set; }
        public virtual ICollection<BugNet_ProjectMailBoxes> BugNet_ProjectMailBoxes { get; set; }
        public virtual BugNet_Projects Project { get; set; }
    }
}
