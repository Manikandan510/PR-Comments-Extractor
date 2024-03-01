using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PR_Comments_Extractor.DataModels;
using System.Text;
using System.Text.RegularExpressions;

namespace PR_Comments_Extractor.Functionality
{
    public class TfsAccessRequests
    {
        private readonly AccessClient _accessClient;

        public TfsAccessRequests()
        {
            _accessClient = new AccessClient();
        }

        public async Task<List<ProjectModel>> GetProjectsList(string token)
        {
            try
            {
                HttpResponseMessage response = await _accessClient.SendRequestAsync(token, "_apis/projects?stateFilter=All");
                var projList = response.Content.ReadAsStringAsync().Result;
                var finalResponse = JsonConvert.DeserializeObject<ProjectResponseModel>(projList);
                return finalResponse.value;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Please check the Access Token \n (Error: {e.Message})",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return new List<ProjectModel>();
            }
        }
        public async Task<List<RepositoryModel>> GetRepositories(string projectID, string token)
        {
            HttpResponseMessage response = await _accessClient.SendRequestAsync(token, $"{projectID}/_apis/git/repositories");
            var RepoList = response.Content.ReadAsStringAsync().Result;
            var finalResponse = JsonConvert.DeserializeObject<RepostoryResponseModel>(RepoList);
            return finalResponse.value;
        }
        public async Task<List<PRModel>> GetPullRequests(string repositoryID, string userID, string dateFrom, string dateTo, string targetBranch, string token)
        {
            try
            {
                HttpResponseMessage PRresponse = new();
                if (targetBranch.Length > 0 && !(userID.Length > 0))
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"_apis/git/repositories/{repositoryID}/pullrequests?searchCriteria.status=all&searchCriteria.targetRefName=refs/heads/{targetBranch}&searchCriteria.minTime={dateFrom}&searchCriteria.maxTime={dateTo}");
                }
                else if (userID.Length > 0 && !(targetBranch.Length > 0))
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"_apis/git/repositories/{repositoryID}/pullrequests?searchCriteria.creatorId={userID}&searchCriteria.status=all&searchCriteria.minTime={dateFrom}&searchCriteria.maxTime={dateTo}");
                }
                else if (userID.Length > 0 && targetBranch.Length > 0)
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"_apis/git/repositories/{repositoryID}/pullrequests?searchCriteria.creatorId={userID}&searchCriteria.targetRefName=refs/heads/{targetBranch}&searchCriteria.status=all&searchCriteria.minTime={dateFrom}&searchCriteria.maxTime={dateTo}");
                }
                else
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"_apis/git/repositories/{repositoryID}/pullrequests?searchCriteria.status=all&searchCriteria.minTime={dateFrom}&searchCriteria.maxTime={dateTo}");
                }
                var PRList = PRresponse.Content.ReadAsStringAsync().Result;
                var finalResponse = JsonConvert.DeserializeObject<PrResponseModel>(PRList);
                return finalResponse.value;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return new List<PRModel>();
            }
        }
        public async Task<string> GetUserID(string legalID, string token)
        {
            try
            {
                if (legalID.Length > 0)
                {

                    HttpResponseMessage response = await _accessClient.SendUserRequestAsync(token, $"_apis/userentitlements?$filter=name+eq+'{legalID}'");
                    var User = response.Content.ReadAsStringAsync().Result;
                    var UserRes = JsonConvert.DeserializeObject<UserResponseModel>(User);
                    return UserRes.items[0].id;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Please check the ID Because \n (Error: {e.Message})","Error!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                return string.Empty;
            }

        }
        public async Task<string> GetComments(string repositoryID, string projectID, int pullRequestID, string token)
        {
            try
            {
                HttpResponseMessage response = await _accessClient.SendRequestAsync(token, $"{projectID}/_apis/git/repositories/{repositoryID}/pullRequests/{pullRequestID}/threads?api-version=7.0");
                var threads = response.Content.ReadAsStringAsync().Result;
                var commentThreads = JsonConvert.DeserializeObject<CommentResponseModel>(threads);

                StringBuilder threadComments = new StringBuilder();
                foreach (var commentThread in commentThreads.value)
                {
                    HttpResponseMessage PRdetails = await _accessClient.SendPRRequestAsync(token, $"{projectID}/_apis/git/pullrequests/{pullRequestID}?api-version=7.0");
                    var PRdata = PRdetails.Content.ReadAsStringAsync().Result;
                    var PRDetails = JsonConvert.DeserializeObject<PRDataModel>(PRdata);

                    foreach (var comment in commentThread.comments)
                    {

                        string commentString = "";
                        if (comment.content != null)
                        {
                            commentString = comment.content;
                        }
                        else
                        {
                            commentString = " ";
                        }

                        string pattern = @"@<\w{8}-\w{4}-\w{4}-\w{4}-\w{12}>";
                        StringBuilder stringBuilder = new StringBuilder();

                        string? modifiedString = null;

                        MatchCollection matches = Regex.Matches(commentString, pattern);
                        if (matches.Count > 0)
                        {
                            modifiedString = comment.content;

                            foreach (Match match in matches)
                            {
                                string extractedString = match.Value.Substring(2, match.Value.Length - 3);
                                HttpResponseMessage UserResponse = await _accessClient.SendUserInfoRequestAsync(token, $"_apis/Identities/{extractedString}");
                                var UserName = UserResponse.Content.ReadAsStringAsync().Result;
                                var UsersDetails = JsonConvert.DeserializeObject<UserDetailsModel>(UserName);
                                if (modifiedString != null)
                                {
                                    modifiedString = modifiedString.Replace(match.Value, "@" + UsersDetails.DisplayName);
                                }
                            }

                            if (modifiedString == null)
                            {
                                modifiedString = "";
                            }

                            stringBuilder.Append(PRDetails.pullRequestId).Append("\t")
                                .Append(PRDetails.createdBy.displayName).Append("\t")
                                .Append(PRDetails.targetRefName).Append("\t")
                                .Append(PRDetails.status).Append("\t")
                                .Append(PRDetails.creationDate).Append("\t")
                                .Append(PRDetails.closedDate).Append("\t")
                                .Append(PRDetails.url).Append("\t")
                                .Append(comment.author.displayName).Append("\t")
                                .Append(comment.author.uniqueName.ToUpper()).Append("\t")
                                .Append(modifiedString.Replace("\n", " ")).Append("\n");

                            threadComments.Append(stringBuilder.ToString());
                        }
                        else
                        {
                            if (comment.content == null)
                            {
                                comment.content = "";
                            }

                            stringBuilder.Append(PRDetails.pullRequestId).Append("\t")
                                .Append(PRDetails.createdBy.displayName).Append("\t")
                                .Append(PRDetails.targetRefName).Append("\t")
                                .Append(PRDetails.status).Append("\t")
                                .Append(PRDetails.creationDate).Append("\t")
                                .Append(PRDetails.closedDate).Append("\t")
                                .Append(PRDetails.url).Append("\t")
                                .Append(comment.author.displayName).Append("\t")
                                .Append(comment.author.uniqueName.ToUpper()).Append("\t")
                                .Append(comment.content.Replace("\n", " ")).Append("\n");
                            threadComments.Append(stringBuilder.ToString());
                        }
                    }
                }
                return threadComments.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<List<PRModel>> GetPullRequestsbyProject(string projectID, string userID, string dateFrom, string dateTo, string targetBranch, string token)
        {
            try
            {
                HttpResponseMessage PRresponse = new();
                if (userID.Length > 0 && targetBranch.Length == 0)
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"{projectID}/_apis/git/pullrequests?searchCriteria.creatorId={userID}&searchCriteria.maxTime={dateTo}&searchCriteria.minTime={dateFrom}&searchCriteria.status=all");
                }
                else if (targetBranch.Length > 0 && userID.Length == 0)
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"{projectID}/_apis/git/pullrequests?searchCriteria.targetRefName=refs/heads/{targetBranch}&searchCriteria.maxTime={dateTo}&searchCriteria.minTime={dateFrom}&searchCriteria.status=all");
                }
                else if (targetBranch.Length > 0 && userID.Length > 0)
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"{projectID}/_apis/git/pullrequests?searchCriteria.creatorId={userID}&searchCriteria.targetRefName=refs/heads/{targetBranch}&searchCriteria.maxTime={dateTo}&searchCriteria.minTime={dateFrom}&searchCriteria.status=all");
                }
                else
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"{projectID}/_apis/git/pullrequests?searchCriteria.maxTime={dateTo}&searchCriteria.minTime={dateFrom}&searchCriteria.status=all");
                }
                var PRList = PRresponse.Content.ReadAsStringAsync().Result;
                var finalResponse = JsonConvert.DeserializeObject<PrResponseModel>(PRList);
                return finalResponse.value;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<PRModel>();
            }
        }
        public async Task<List<TeamValues>> GetTeamList(string tokenText, string teamName)
        {
            try
            {
                HttpResponseMessage TeamResponse = new();

                TeamResponse = await _accessClient.SendRequestAsync(tokenText, $"_apis/projects/{teamName}/teams?$top=400");

                var TeamListContent = TeamResponse.Content.ReadAsStringAsync().Result;
                var TeamLists = JsonConvert.DeserializeObject<TeamModel>(TeamListContent);
                return TeamLists.value;
            }
            catch (Exception e)
            {
                MessageBox.Show("You don't have access to story board", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<TeamValues>();
            }
        }
        public async Task<List<MembersValue>> GetTeamMembers(string teamid, string tokenText)
        {
            try
            {
                HttpResponseMessage TeamMembers = new();
                TeamMembers = await _accessClient.SendRequestAsync(tokenText, $"_apis/projects/LexisNexis/teams/{teamid}/members?");
                var Members = TeamMembers.Content.ReadAsStringAsync().Result;
                var MembersIdentity = JsonConvert.DeserializeObject<TeamMembModel>(Members);
                return MembersIdentity.value;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<MembersValue>();
            }
        }
        public async Task<List<PRModel>> PRByMemberID(string tokenText, string memberid, string dateFrom, string dateTo, string branch)
        {
            try
            {
                HttpResponseMessage PRresponse = new HttpResponseMessage();
                if (branch.Length > 0)
                {
                    PRresponse = await _accessClient.SendRequestAsync(tokenText, $"_apis/git/pullrequests?searchCriteria.creatorId={memberid}&searchCriteria.targetRefName=refs/heads/{branch}&searchCriteria.status=all&searchCriteria.maxTime={dateTo}&searchCriteria.minTime={dateFrom}");
                }
                else
                {
                    PRresponse = await _accessClient.SendRequestAsync(tokenText, $"_apis/git/pullrequests?searchCriteria.creatorId={memberid}&searchCriteria.status=all&searchCriteria.maxTime={dateTo}&searchCriteria.minTime={dateFrom}");
                }
                var PRList = PRresponse.Content.ReadAsStringAsync().Result;
                var finalResponse = JsonConvert.DeserializeObject<PrResponseModel>(PRList);
                return finalResponse.value;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<PRModel>();
            }
        }
        public async Task<List<PRModel>> TeamPRsByRepo(string repositoryID, string userID, string dateFrom, string dateTo, string targetBranch, string token)
        {
            try
            {
                HttpResponseMessage PRresponse = new();
                if (targetBranch.Length > 0 && !(userID.Length > 0))
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"_apis/git/repositories/{repositoryID}/pullrequests?searchCriteria.status=all&searchCriteria.targetRefName=refs/heads/{targetBranch}&searchCriteria.minTime={dateFrom}&searchCriteria.maxTime={dateTo}");
                }
                else if (userID.Length > 0 && !(targetBranch.Length > 0))
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"_apis/git/repositories/{repositoryID}/pullrequests?searchCriteria.creatorId={userID}&searchCriteria.status=all&searchCriteria.minTime={dateFrom}&searchCriteria.maxTime={dateTo}");
                }
                else if (userID.Length > 0 && targetBranch.Length > 0)
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"_apis/git/repositories/{repositoryID}/pullrequests?searchCriteria.creatorId={userID}&searchCriteria.targetRefName=refs/heads/{targetBranch}&searchCriteria.status=all&searchCriteria.minTime={dateFrom}&searchCriteria.maxTime={dateTo}");
                }
                else
                {
                    PRresponse = await _accessClient.SendRequestAsync(token, $"_apis/git/repositories/{repositoryID}/pullrequests?searchCriteria.status=all&searchCriteria.minTime={dateFrom}&searchCriteria.maxTime={dateTo}");
                }
                var PRList = PRresponse.Content.ReadAsStringAsync().Result;
                var finalResponse = JsonConvert.DeserializeObject<PrResponseModel>(PRList);
                return finalResponse.value;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<PRModel>();
            }
        }
    }
}
