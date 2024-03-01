using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Comments_Extractor.DataModels
{
    public class GridData
    {
        public string Pull_Request_No { get; set; }
        public string Pull_Request_Link { get; set; }
        public string Created_By { get; set; }
        public string Target_Branch { get; set; }
        public string PR_Status { get; set; }
        public string Created_On { get; set; }
        public string Completed_On { get; set; }
        public string Commented_By { get; set; }
        public string Comments { get; set; }
    }
}
