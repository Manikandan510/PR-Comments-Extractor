using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Comments_Extractor.DataModels
{
    public class ProjectResponseModel
    {
        public int count { get; set; }
        public List<ProjectModel> value { get; set; }
    }

    public class ProjectModel
    {
        public string id { get; set; }
        public DateTime lastUpdateTime { get; set; }
        public string name { get; set; }
        public int revision { get; set; }
        public string state { get; set; }
        public string url { get; set; }
        public string visibility { get; set; }
        public string? descriptionz { get; set; }
    }
}
