using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_QueryClauses
    {
        public int QueryClauseId { get; set; }
        public string BooleanOperator { get; set; }
        public string ComparisonOperator { get; set; }
        public int? CustomFieldId { get; set; }
        public int DataType { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public int QueryId { get; set; }

        public virtual BugNet_Queries Query { get; set; }
    }
}
