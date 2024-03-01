using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Comments_Extractor.DataModels
{
    public class PrResponseModel
    {
        public int count { get; set; }
        public List<PRModel> value { get; set; }
    }

    public class PRAvatar
    {
        public string href { get; set; }
    }

    public class CompletionOptions
    {
        public List<object> autoCompleteIgnoreConfigIds { get; set; }
        public string mergeCommitMessage { get; set; }
        public string mergeStrategy { get; set; }
        public bool transitionWorkItems { get; set; }
    }

    public class CreatedBy
    {
        public PRLinks _links { get; set; }
        public string descriptor { get; set; }
        public string displayName { get; set; }
        public string id { get; set; }
        public string imageUrl { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
    }

    public class LastMergeCommit
    {
        public string commitId { get; set; }
        public string url { get; set; }
    }

    public class LastMergeSourceCommit
    {
        public string commitId { get; set; }
        public string url { get; set; }
    }

    public class LastMergeTargetCommit
    {
        public string commitId { get; set; }
        public string url { get; set; }
    }

    public class PRLinks
    {
        public PRAvatar avatar { get; set; }
    }

    public class Project
    {
        public string id { get; set; }
        public DateTime lastUpdateTime { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string visibility { get; set; }
    }

    public class PRRepositoryDetails
    {
        public string id { get; set; }
        public string name { get; set; }
        public Project project { get; set; }
        public string url { get; set; }
    }

    public class Reviewer
    {
        public PRLinks _links { get; set; }
        public string displayName { get; set; }
        public bool hasDeclined { get; set; }
        public string id { get; set; }
        public string imageUrl { get; set; }
        public bool isFlagged { get; set; }
        public bool isRequired { get; set; }
        public string reviewerUrl { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public int vote { get; set; }
    }

    public class PRModel
    {
        public DateTime closedDate { get; set; }
        public int codeReviewId { get; set; }
        public CompletionOptions completionOptions { get; set; }
        public DateTime completionQueueTime { get; set; }
        public CreatedBy createdBy { get; set; }
        public DateTime creationDate { get; set; }
        public string description { get; set; }
        public bool isDraft { get; set; }
        public LastMergeCommit lastMergeCommit { get; set; }
        public LastMergeSourceCommit lastMergeSourceCommit { get; set; }
        public LastMergeTargetCommit lastMergeTargetCommit { get; set; }
        public string mergeId { get; set; }
        public string mergeStatus { get; set; }
        public int pullRequestId { get; set; }
        public PRRepositoryDetails repository { get; set; }
        public List<Reviewer> reviewers { get; set; }
        public string sourceRefName { get; set; }
        public string status { get; set; }
        public bool supportsIterations { get; set; }
        public string targetRefName { get; set; }
        public string title { get; set; }
        public string url { get; set; }
    }
}
