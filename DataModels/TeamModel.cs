using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Comments_Extractor.DataModels
{
    public class TeamModel
    {
        public int count { get; set; }
        public List<TeamValues> value { get; set; }
    }
    public class TeamValues
    {
        public string description { get; set; }
        public string id { get; set; }
        public string identityUrl { get; set; }
        public string name { get; set; }
        public string projectId { get; set; }
        public string projectName { get; set; }
        public string url { get; set; }
    }
}
