using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Comments_Extractor.DataModels
{
    public class CommentResponseModel
    {
        public int count { get; set; }
        public List<Value> value { get; set; }
    }
    public class _1
    {
        public UserLinks _links { get; set; }
        public string descriptor { get; set; }
        public string displayName { get; set; }
        public string id { get; set; }
        public string imageUrl { get; set; }
        public bool isContainer { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
    }
    public class CommentsLinks
    {
        public Repository repository { get; set; }
        public Self self { get; set; }
        public PullRequests pullRequests { get; set; }
        public Threads threads { get; set; }
        public Avatar avatar { get; set; }
    }

    public class Author
    {
        public CommentsLinks _links { get; set; }
        public string descriptor { get; set; }
        public string displayName { get; set; }
        public string id { get; set; }
        public string imageUrl { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
    }

    public class BypassPolicy
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewAutoCompleteNowSet
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewAutoCompleteUpdatedByIdentity
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewPolicyType
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewRefName
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewRefNewCommits
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewRefNewCommitsCount
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public int value { get; set; }
    }

    public class CodeReviewRefNewHeadCommit
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewRefUpdatedByIdentity
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewRequiredReviewerExamplePathThatTriggered
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewRequiredReviewerExampleReviewerIdentities
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewRequiredReviewerIsRequired
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewRequiredReviewerNumFilesThatTriggered
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public int value { get; set; }
    }

    public class CodeReviewRequiredReviewerNumReviewers
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public int value { get; set; }
    }

    public class CodeReviewReviewersUpdatedAddedIdentity
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewReviewersUpdatedByIdentity
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewReviewersUpdatedNumAdded
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public int value { get; set; }
    }

    public class CodeReviewReviewersUpdatedNumChanged
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public int value { get; set; }
    }

    public class CodeReviewReviewersUpdatedNumDeclined
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public int value { get; set; }
    }

    public class CodeReviewReviewersUpdatedNumRemoved
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public int value { get; set; }
    }

    public class CodeReviewStatus
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewStatusUpdateAssociatedCommit
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewStatusUpdatedByIdentity
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewThreadType
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewVotedByIdentity
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewVotedByInitiatorIdentity
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class CodeReviewVoteResult
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class Comment
    {
        public UserLinks _links { get; set; }
        public Author author { get; set; }
        public string commentType { get; set; }
        public string content { get; set; }
        public int id { get; set; }
        public DateTime lastContentUpdatedDate { get; set; }
        public DateTime lastUpdatedDate { get; set; }
        public int parentCommentId { get; set; }
        public DateTime publishedDate { get; set; }
        public List<object> usersLiked { get; set; }
    }

    public class Identities
    {
        [JsonProperty("1")]
        public _1 _1 { get; set; }
    }

    public class IterationContext
    {
        public int firstComparingIteration { get; set; }
        public int secondComparingIteration { get; set; }
    }

    public class LinkedWorkItems
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class MicrosoftTeamFoundationDiscussionSupportsMarkdown
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public int value { get; set; }
    }

    public class MicrosoftTeamFoundationDiscussionUniqueID
    {
        [JsonProperty("$type")]
        public string type { get; set; }

        [JsonProperty("$value")]
        public string value { get; set; }
    }

    public class Properties
    {
        public CodeReviewPolicyType CodeReviewPolicyType { get; set; }
        public CodeReviewRequiredReviewerExamplePathThatTriggered CodeReviewRequiredReviewerExamplePathThatTriggered { get; set; }
        public CodeReviewRequiredReviewerExampleReviewerIdentities CodeReviewRequiredReviewerExampleReviewerIdentities { get; set; }
        public CodeReviewRequiredReviewerIsRequired CodeReviewRequiredReviewerIsRequired { get; set; }
        public CodeReviewRequiredReviewerNumFilesThatTriggered CodeReviewRequiredReviewerNumFilesThatTriggered { get; set; }
        public CodeReviewRequiredReviewerNumReviewers CodeReviewRequiredReviewerNumReviewers { get; set; }
        public CodeReviewThreadType CodeReviewThreadType { get; set; }
        public CodeReviewVotedByIdentity CodeReviewVotedByIdentity { get; set; }
        public CodeReviewVotedByInitiatorIdentity CodeReviewVotedByInitiatorIdentity { get; set; }
        public CodeReviewVoteResult CodeReviewVoteResult { get; set; }
        public CodeReviewAutoCompleteNowSet CodeReviewAutoCompleteNowSet { get; set; }
        public CodeReviewAutoCompleteUpdatedByIdentity CodeReviewAutoCompleteUpdatedByIdentity { get; set; }

        [JsonProperty("Microsoft.TeamFoundation.Discussion.SupportsMarkdown")]
        public MicrosoftTeamFoundationDiscussionSupportsMarkdown MicrosoftTeamFoundationDiscussionSupportsMarkdown { get; set; }

        [JsonProperty("Microsoft.TeamFoundation.Discussion.UniqueID")]
        public MicrosoftTeamFoundationDiscussionUniqueID MicrosoftTeamFoundationDiscussionUniqueID { get; set; }
        public CodeReviewRefName CodeReviewRefName { get; set; }
        public CodeReviewRefNewCommits CodeReviewRefNewCommits { get; set; }
        public CodeReviewRefNewCommitsCount CodeReviewRefNewCommitsCount { get; set; }
        public CodeReviewRefNewHeadCommit CodeReviewRefNewHeadCommit { get; set; }
        public CodeReviewRefUpdatedByIdentity CodeReviewRefUpdatedByIdentity { get; set; }
        public CodeReviewReviewersUpdatedAddedIdentity CodeReviewReviewersUpdatedAddedIdentity { get; set; }
        public CodeReviewReviewersUpdatedByIdentity CodeReviewReviewersUpdatedByIdentity { get; set; }
        public CodeReviewReviewersUpdatedNumAdded CodeReviewReviewersUpdatedNumAdded { get; set; }
        public CodeReviewReviewersUpdatedNumChanged CodeReviewReviewersUpdatedNumChanged { get; set; }
        public CodeReviewReviewersUpdatedNumDeclined CodeReviewReviewersUpdatedNumDeclined { get; set; }
        public CodeReviewReviewersUpdatedNumRemoved CodeReviewReviewersUpdatedNumRemoved { get; set; }
        public LinkedWorkItems LinkedWorkItems { get; set; }
        public BypassPolicy BypassPolicy { get; set; }
        public CodeReviewStatus CodeReviewStatus { get; set; }
        public CodeReviewStatusUpdateAssociatedCommit CodeReviewStatusUpdateAssociatedCommit { get; set; }
        public CodeReviewStatusUpdatedByIdentity CodeReviewStatusUpdatedByIdentity { get; set; }
    }

    public class PullRequests
    {
        public string href { get; set; }
    }

    public class PullRequestThreadContext
    {
        public int changeTrackingId { get; set; }
        public IterationContext iterationContext { get; set; }
    }

    public class Repository
    {
        public string href { get; set; }
    }

    public class RightFileEnd
    {
        public int line { get; set; }
        public int offset { get; set; }
    }

    public class RightFileStart
    {
        public int line { get; set; }
        public int offset { get; set; }
    }
    public class ThreadContext
    {
        public string filePath { get; set; }
        public RightFileEnd rightFileEnd { get; set; }
        public RightFileStart rightFileStart { get; set; }
    }

    public class Threads
    {
        public string href { get; set; }
    }

    public class Value
    {
        public CommentsLinks _links { get; set; }
        public List<Comment> comments { get; set; }
        public int id { get; set; }
        public Identities identities { get; set; }
        public bool isDeleted { get; set; }
        public DateTime lastUpdatedDate { get; set; }
        public Properties properties { get; set; }
        public DateTime publishedDate { get; set; }
        public PullRequestThreadContext pullRequestThreadContext { get; set; }
        public ThreadContext threadContext { get; set; }
        public string status { get; set; }
    }
}
