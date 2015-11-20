using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_Queries
    {
        public BugNet_Queries()
        {
            BugNet_QueryClauses = new HashSet<BugNet_QueryClauses>();
        }

        public int QueryId { get; set; }
        public bool IsPublic { get; set; }
        public int ProjectId { get; set; }
        public string QueryName { get; set; }
        public Guid UserId { get; set; }

        public virtual ICollection<BugNet_QueryClauses> BugNet_QueryClauses { get; set; }
        public virtual BugNet_Projects Project { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
