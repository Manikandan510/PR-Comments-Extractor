using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Comments_Extractor.DataModels
{
    public class Descriptor
    {
        public string Identifier { get; set; }
        public string IdentityType { get; set; }
    }

    public class UserProperties
    {
        public string Account { get; set; }
        public DateTime ComplianceValidated { get; set; }
        public string Description { get; set; }
        public string DirectoryAlias { get; set; }
        public string DN { get; set; }
        public string Domain { get; set; }

        [JsonProperty("http://schemas.microsoft.com/identity/claims/objectidentifier")]
        public string httpschemasmicrosoftcomidentityclaimsobjectidentifier { get; set; }
        public string Mail { get; set; }
        public DateTime MetadataUpdateDate { get; set; }
        public string SchemaClassName { get; set; }
        public string SpecialType { get; set; }
    }

    public class UserDetailsModel
    {
        public object CustomDisplayName { get; set; }
        public Descriptor Descriptor { get; set; }
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsContainer { get; set; }
        public List<object> MemberOf { get; set; }
        public List<object> Members { get; set; }
        public UserProperties Properties { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UniqueUserId { get; set; }
    }
}
