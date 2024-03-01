using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Comments_Extractor.DataModels
{
    public class PRdataAuthor
    {
        public DateTime date { get; set; }
        public string email { get; set; }
        public string name { get; set; }
    }

    public class PRdataAvatar
    {
        public string href { get; set; }
    }

    public class ClosedBy
    {
        public PRdataLinks _links { get; set; }
        public string descriptor { get; set; }
        public string displayName { get; set; }
        public string id { get; set; }
        public string imageUrl { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
    }

    public class Committer
    {
        public DateTime date { get; set; }
        public string email { get; set; }
        public string name { get; set; }
    }

    public class PRdataCompletionOptions
    {
        public List<object> autoCompleteIgnoreConfigIds { get; set; }
        public string mergeCommitMessage { get; set; }
        public string mergeStrategy { get; set; }
        public bool squashMerge { get; set; }
        public bool triggeredByAutoComplete { get; set; }
    }

    public class PRdataCreatedBy
    {
        public PRdataLinks _links { get; set; }
        public string descriptor { get; set; }
        public string displayName { get; set; }
        public string id { get; set; }
        public string imageUrl { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
    }

    public class PRdataLastMergeCommit
    {
        public Author author { get; set; }
        public string comment { get; set; }
        public bool commentTruncated { get; set; }
        public string commitId { get; set; }
        public Committer committer { get; set; }
        public string url { get; set; }
    }

    public class PRdataLastMergeSourceCommit
    {
        public string commitId { get; set; }
        public string url { get; set; }
    }

    public class PRdataLastMergeTargetCommit
    {
        public string commitId { get; set; }
        public string url { get; set; }
    }

    public class PRdataLinks
    {
        public Avatar avatar { get; set; }
    }

    public class PRdataProject
    {
        public string id { get; set; }
        public DateTime lastUpdateTime { get; set; }
        public string name { get; set; }
        public int revision { get; set; }
        public string state { get; set; }
        public string url { get; set; }
        public string visibility { get; set; }
    }

    public class PRdataRepository
    {
        public string id { get; set; }
        public bool isDisabled { get; set; }
        public bool isInMaintenance { get; set; }
        public string name { get; set; }
        public Project project { get; set; }
        public string remoteUrl { get; set; }
        public long size { get; set; }
        public string sshUrl { get; set; }
        public string url { get; set; }
        public string webUrl { get; set; }
    }

    public class PRdataReviewer
    {
        public PRdataLinks _links { get; set; }
        public string displayName { get; set; }
        public bool hasDeclined { get; set; }
        public string id { get; set; }
        public string imageUrl { get; set; }
        public bool isContainer { get; set; }
        public bool isFlagged { get; set; }
        public bool isRequired { get; set; }
        public string reviewerUrl { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public int vote { get; set; }
        public List<PRdataVotedFor> votedFor { get; set; }
    }

    public class PRDataModel
    {
        public string artifactId { get; set; }
        public ClosedBy closedBy { get; set; }
        public DateTime closedDate { get; set; }
        public int codeReviewId { get; set; }
        public PRdataCompletionOptions completionOptions { get; set; }
        public DateTime completionQueueTime { get; set; }
        public PRdataCreatedBy createdBy { get; set; }
        public DateTime creationDate { get; set; }
        public string description { get; set; }
        public bool isDraft { get; set; }
        public PRdataLastMergeCommit lastMergeCommit { get; set; }
        public PRdataLastMergeSourceCommit lastMergeSourceCommit { get; set; }
        public PRdataLastMergeTargetCommit lastMergeTargetCommit { get; set; }
        public string mergeId { get; set; }
        public string mergeStatus { get; set; }
        public int pullRequestId { get; set; }
        public PRdataRepository repository { get; set; }
        public List<PRdataReviewer> reviewers { get; set; }
        public string sourceRefName { get; set; }
        public string status { get; set; }
        public bool supportsIterations { get; set; }
        public string targetRefName { get; set; }
        public string title { get; set; }
        public string url { get; set; }
    }

    public class PRdataVotedFor
    {
        public PRdataLinks _links { get; set; }
        public string displayName { get; set; }
        public string id { get; set; }
        public string imageUrl { get; set; }
        public bool isContainer { get; set; }
        public string reviewerUrl { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public int vote { get; set; }
    }
}
