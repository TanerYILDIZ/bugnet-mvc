using System;
using System.Collections.Generic;

namespace BugNET.Models
{
    public partial class BugNet_Languages
    {
        public int LanguageId { get; set; }
        public string CultureCode { get; set; }
        public string CultureName { get; set; }
        public string FallbackCulture { get; set; }
    }
}
