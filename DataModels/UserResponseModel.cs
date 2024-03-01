using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Comments_Extractor.DataModels
{
    public class AccessLevel
    {
        public string licensingSource { get; set; }
        public string accountLicenseType { get; set; }
        public string msdnLicenseType { get; set; }
        public string licenseDisplayName { get; set; }
        public string status { get; set; }
        public string statusMessage { get; set; }
        public string assignmentSource { get; set; }
    }

    public class Avatar
    {
        public string href { get; set; }
    }

    public class Item
    {
        public User user { get; set; }
        public List<object> extensions { get; set; }
        public string id { get; set; }
        public AccessLevel accessLevel { get; set; }
        public DateTime lastAccessedDate { get; set; }
        public DateTime dateCreated { get; set; }
        public List<object> projectEntitlements { get; set; }
        public List<object> groupAssignments { get; set; }
    }

    public class UserLinks
    {
        public Self self { get; set; }
        public Memberships memberships { get; set; }
        public MembershipState membershipState { get; set; }
        public StorageKey storageKey { get; set; }
        public Avatar avatar { get; set; }
    }

    public class Memberships
    {
        public string href { get; set; }
    }

    public class MembershipState
    {
        public string href { get; set; }
    }

    public class UserResponseModel
    {
        public List<Item> items { get; set; }
        public object continuationToken { get; set; }
        public int totalCount { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class StorageKey
    {
        public string href { get; set; }
    }

    public class User
    {
        public string subjectKind { get; set; }
        public string metaType { get; set; }
        public string directoryAlias { get; set; }
        public string domain { get; set; }
        public string principalName { get; set; }
        public string mailAddress { get; set; }
        public string origin { get; set; }
        public string originId { get; set; }
        public string displayName { get; set; }
        public UserLinks _links { get; set; }
        public string url { get; set; }
        public string descriptor { get; set; }
    }
}
