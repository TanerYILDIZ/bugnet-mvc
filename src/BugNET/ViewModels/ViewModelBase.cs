using BugNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugNET.ViewModels
{
    public class ViewModelBase
    {
        public string Message { get; set; }
        public List<BugNet_Projects> UsersProjects { get; set; }
        public int? ActiveProjectID { get; set; }
    }
}
