using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Comments_Extractor.DataModels
{
    public class RepostoryResponseModel
    {
        public List<RepositoryModel> value { get; set; }
        public int count { get; set; }
    }
    public class RepositoryModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public ProjectModel project { get; set; }
        public string defaultBranch { get; set; }
        public long size { get; set; }
        public string remoteUrl { get; set; }
        public string sshUrl { get; set; }
        public string webUrl { get; set; }
        public bool isDisabled { get; set; }
        public bool isInMaintenance { get; set; }
        public bool? isFork { get; set; }
    }
}
