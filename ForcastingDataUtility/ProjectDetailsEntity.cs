using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcastingDataUtility
{
    public class ProjectDetailsEntity
    {
        public int ProjectID { get; set; }
        public string ProjectShortName { get; set; }
        public string ProjectLongName { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
    }
}
