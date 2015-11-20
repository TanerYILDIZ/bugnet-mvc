using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_RequiredFieldList
    {
        public int RequiredFieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }
}
