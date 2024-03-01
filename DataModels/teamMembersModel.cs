using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Comments_Extractor.DataModels
{
    public class TeamMembModel
    {
        public int count { get; set; }
        public List<MembersValue> value { get; set; }
    }
    public class Identity
    {
        public Links _links { get; set; }
        public string descriptor { get; set; }
        public string displayName { get; set; }
        public string id { get; set; }
        public string imageUrl { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
    }

    public class Links
    {
        public Avatar avatar { get; set; }
    }



    public class MembersValue
    {
        public Identity identity { get; set; }
        public bool? isTeamAdmin { get; set; }
    }


}
