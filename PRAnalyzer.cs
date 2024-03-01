using Microsoft.Extensions.Configuration;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json.Linq;
using PR_Comments_Extractor.DataModels;
using PR_Comments_Extractor.Functionality;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace PR_Comments_Extractor
{
    public partial class PRAnalyzer : Form
    {
        private TfsAccessRequests tfsAccess = new TfsAccessRequests();
        List<ProjectModel> projectResponses = new List<ProjectModel>();
        List<TeamValues> teamResponses = new List<TeamValues>();
        List<RepositoryModel> RepositoryResponse = new List<RepositoryModel>();
        DataGridView dgv = new DataGridView();
        BindingSource bs = new BindingSource();
        List<GridData> commentsList = new List<GridData>();
        IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        string tokenText, teamName, OrgName;
        public PRAnalyzer()
        {
            InitializeComponent();
            tokenText = config["PersonalAccessToken"];
            OrgName = config["Organization"];
            teamName = config["StoryBoardProject"];
            dateTimePicker1.MaxDate = DateTime.Now;

        }
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = "Status: Idle";
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            progressBar1.Value = 0;
            label4.Visible = false;

            string selectedProject = comboBox1.SelectedItem.ToString();
            RepositoryResponse = await tfsAccess.GetRepositories(projectResponses.First(x => x.name == selectedProject).id, tokenText);
            comboBox2.DataSource = RepositoryResponse.OrderBy(item => item.name).Select(x => x.name).ToList();
            dgv = new DataGridView();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            List<PRModel> PRresponse = new();
            dgv = new DataGridView();
            List<string> memberIDs = new();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            label6.Text = "Status: Processing";
            string selectedRepository = comboBox2.SelectedItem.ToString();
            if (textBox2.Text.Length > 0)
            {
                if (radioButton2.Checked)
                {
                    var selectedTeam = comboBox3.SelectedItem.ToString();
                    var teamid = teamResponses.First(x => x.name == selectedTeam).id;
                    var teammembers = await tfsAccess.GetTeamMembers(teamid, tokenText);
                    if (textBox2.Text.Contains(","))
                    {
                        string[] userIDs = textBox2.Text.Split(",");
                        foreach (var user in userIDs)
                        {
                            var Id = await tfsAccess.GetUserID(user.Trim(), tokenText);
                            var teammemb = teammembers.Find(x => x.identity.id == Id);
                            if (teammemb != null)
                                memberIDs.Add(teammemb.identity.id);
                        }
                        if (memberIDs.Count != userIDs.Count())
                            MessageBox.Show("Some IDs are not part of the selected team. Please use \"Associate Report\".", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        foreach (var member in teammembers)
                        {
                            memberIDs.Add(member.identity.id);
                        }
                    }
                    foreach (var member in memberIDs)
                    {
                        label6.Text = "Status: Processing";
                        var tempPRresponse = await tfsAccess.GetPullRequests(RepositoryResponse.First(x => x.name == selectedRepository).id, member, dateTimePicker1.Text, dateTimePicker2.Text, textBox3.Text, tokenText);
                        PRresponse = PRresponse.Concat(tempPRresponse).ToList();
                    }
                }
                else
                {
                    if (textBox2.Text.Contains(","))
                    {
                        string[] userIDs = textBox2.Text.Split(",");
                        foreach (var user in userIDs)
                        {
                            var Id = await tfsAccess.GetUserID(user.Trim(), tokenText);
                            memberIDs.Add(Id);
                        }
                    }
                    else
                    {
                        var userid = await tfsAccess.GetUserID(textBox2.Text.Trim(), tokenText);
                        memberIDs.Add(userid);
                    }
                    foreach (var member in memberIDs)
                    {
                        var tempRes = await tfsAccess.GetPullRequests(RepositoryResponse.First(x => x.name == selectedRepository).id, member, dateTimePicker1.Text, dateTimePicker2.Text, textBox3.Text, tokenText);
                        PRresponse = PRresponse.Concat(tempRes).ToList();
                    }
                }

                PRresponse = PRresponse.OrderByDescending(obj => obj.creationDate).ToList();
                label4.Visible = true;
                commentsList = new List<GridData>();
                getCommentsdata(PRresponse, tokenText);
                if (PRresponse.Count > 0)
                {
                    label4.Text = "Total PR Count: " + PRresponse.Count.ToString();
                }
                else
                {
                    label4.Text = "No Pull Requests";
                }
            }
            else
            {
                if (radioButton2.Checked)
                {
                    var selectedTeam = comboBox3.SelectedItem.ToString();
                    var teamid = teamResponses.First(x => x.name == selectedTeam).id;
                    var teammembers = await tfsAccess.GetTeamMembers(teamid, tokenText);
                    foreach (var member in teammembers)
                    {
                        label6.Text = "Status: Processing";
                        var tempPRresponse = await tfsAccess.GetPullRequests(RepositoryResponse.First(x => x.name == selectedRepository).id, member.identity.id, dateTimePicker1.Text, dateTimePicker2.Text, textBox3.Text, tokenText);
                        PRresponse = PRresponse.Concat(tempPRresponse).ToList();
                        PRresponse = PRresponse.OrderByDescending(obj => obj.creationDate).ToList();
                    }
                }
                else
                {
                    PRresponse = await tfsAccess.GetPullRequests(RepositoryResponse.First(x => x.name == selectedRepository).id, "", dateTimePicker1.Text, dateTimePicker2.Text, textBox3.Text, tokenText);
                }
                PRresponse = PRresponse.OrderByDescending(obj => obj.creationDate).ToList();
                label4.Visible = true;
                commentsList = new List<GridData>();
                getCommentsdata(PRresponse, tokenText);
                if (PRresponse.Count > 0)
                {
                    label4.Text = "Total PR Count: " + PRresponse.Count.ToString();
                }
                else
                {
                    label4.Text = "No Pull Requests";
                }
            }
        }
        public async void getCommentsdata(List<PRModel> PRresponse, string tokenText)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = PRresponse.Count;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            foreach (var PR in PRresponse)
            {
                var comments = await tfsAccess.GetComments(PR.repository.id, PR.repository.project.id, PR.pullRequestId, tokenText);

                string[] lines = comments.Split('\n', StringSplitOptions.RemoveEmptyEntries);


                for (int i = 1; i < lines.Length; i++)
                {
                    var data = new GridData();

                    string[] values = lines[i].Split('\t');
                    if (values.Length >= 3)
                    {


                        string[] skipComments = { "Microsoft.VisualStudio.Services.TFS", "Policy", "voted" };
                        if (skipComments.Any(values[7].Contains) || skipComments.Any(values[9].Contains))
                        {
                            continue;
                        }
                        data = new GridData()
                        {
                            Pull_Request_No = values[0],
                            Created_By = values[1],
                            Target_Branch = values[2].Substring("refs/heads/".Length),
                            PR_Status = values[3],
                            Created_On = values[4],
                            Completed_On = values[5],
                            Pull_Request_Link = $"https://{OrgName}.visualstudio.com/{PR.repository.project.id}/_git/{PR.repository.id}/pullrequest/{values[0]}",
                            Commented_By = values[7],
                            Comments = values[9]
                        };
                    }
                    commentsList.Add(data);
                }
                progressBar1.PerformStep();
            }
            if (commentsList.Count > 0)
            {
                dataGridView1.Visible = true;
                textBox5.Visible = true;
                button5.Visible = true;
                button4.Visible = true;
                dataGridView1.DataSource = commentsList;
            }
            label6.Text = "Status: Report Generated";
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Text = "Status: Exporting report to excel";
            // Create a new Excel application
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            // Add a new workbook
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];

            // Assuming dgv is your DataGridView
            dgv = dataGridView1;

            string[] headers = { "Pull Request #", "PR URL", "Created by", "Target Branch", "PR Status", "Created on", "Closed on", "Commented By", "Comments" };
            // Adding headers to column
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = headers[i];
            }

            // Export data from the DataGridView to Excel
            for (int i = 1; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    worksheet.Cells[i + 1, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                }
            }
            string filepath = "";
            // Save the Excel file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepath = saveFileDialog.FileName;
                workbook.SaveAs(filepath);
            }
            else
            {
                label6.Text = "Status: Idle";
                return;
            }
            // Clean up resources
            workbook.Close();
            excelApp.Quit();

            label6.Text = $"Status: Exported to \"{filepath}\"";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            var tempdata = commentsList.FindAll(x => x.Commented_By.Contains(textBox5.Text, StringComparison.OrdinalIgnoreCase));
            dataGridView1.DataSource = tempdata;
            dataGridView1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = commentsList;
            dataGridView1.Refresh();
            textBox5.Text = null;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddMonths(-3);
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker2.MaxDate = DateTime.Now;
            dateTimePicker2.Value = dateTimePicker1.MaxDate;

            dgv = new DataGridView();
            if (tokenText.Length > 0)
            {
                label6.Text = "Status: Fetching Repositories";
                projectResponses = await tfsAccess.GetProjectsList(tokenText);
                comboBox1.DataSource = projectResponses.OrderBy(item => item.name).Select(x => x.name).ToList();
                teamResponses = await tfsAccess.GetTeamList(tokenText, teamName);
                if (teamResponses != null)
                {
                    comboBox3.DataSource = teamResponses.OrderBy(item => item.name).Select(x => x.name).ToList();
                }
                else {
                    MessageBox.Show("Story board project not found. Please check the story board project name in appsettings.json.",
                        "Warning!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please provide a Personal Access token", "Error!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            label6.Text = "Status: Idle";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = "Status: Idle";
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            progressBar1.Value = 0;
            label4.Visible = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            List<PRModel> PRresponse = new();
            List<string> memberIDs = new();
            dgv = new DataGridView();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            label6.Text = "Status: Processing";
            string selectedProject = comboBox1.SelectedItem.ToString();
            if (radioButton2.Checked)
            {
                var selectedTeam = comboBox3.SelectedItem.ToString();
                var teamid = teamResponses.First(x => x.name == selectedTeam).id;
                var teammembers = await tfsAccess.GetTeamMembers(teamid, tokenText);

                if (textBox2.Text.Contains(","))
                {
                    string[] userIDs = textBox2.Text.Split(",");
                    foreach (var user in userIDs)
                    {
                        var Id = await tfsAccess.GetUserID(user.Trim(), tokenText);
                        var teammemb = teammembers.Find(x => x.identity.id == Id);
                        if (teammemb != null)
                            memberIDs.Add(teammemb.identity.id);
                    }
                    if (memberIDs.Count != userIDs.Count())
                        MessageBox.Show("Some IDs is/are not part of the selected team. Please use \"Associate Report\".", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                foreach (var member in memberIDs)
                {
                    label6.Text = "Status: Processing";
                    var tempPRresponse = await tfsAccess.GetPullRequestsbyProject(projectResponses.First(x => x.name == selectedProject).id, member, dateTimePicker1.Text, dateTimePicker2.Text, textBox3.Text, tokenText);
                    PRresponse = PRresponse.Concat(tempPRresponse).ToList();
                }
            }
            else
            {
                List<string> userIDs = new();
                if (textBox2.Text.Contains(","))
                {
                    string[] IDs = textBox2.Text.Split(",");
                    foreach (var user in IDs)
                    {
                        var Id = await tfsAccess.GetUserID(user.Trim(), tokenText);
                        userIDs.Add(Id);
                    }
                }
                else
                {
                    var Id = await tfsAccess.GetUserID(textBox2.Text.Trim(), tokenText);
                    userIDs.Add(Id);
                }
                foreach (var ID in userIDs)
                {
                    var tempPRresponse = await tfsAccess.GetPullRequestsbyProject(projectResponses.First(x => x.name == selectedProject).id, ID, dateTimePicker1.Text, dateTimePicker2.Text, textBox3.Text, tokenText);
                    PRresponse = PRresponse.Concat(tempPRresponse).ToList();
                }
            }

            PRresponse = PRresponse.OrderByDescending(obj => obj.creationDate).ToList();
            label4.Visible = true;
            commentsList = new List<GridData>();
            getCommentsdata(PRresponse, tokenText);
            if (PRresponse.Count > 0)
            {
                label4.Text = "Total PR Count: " + PRresponse.Count.ToString();
            }
            else
            {
                label4.Text = "No Pull Requests";
            }

        }

        private async void button6_Click(object sender, EventArgs e)
        {
            List<PRModel> PRresponse = new();
            List<PRModel> tempPRresponse = new();
            dgv = new DataGridView();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            var selectedTeam = comboBox3.SelectedItem.ToString();
            var teamid = teamResponses.First(x => x.name == selectedTeam).id;
            var teammembers = await tfsAccess.GetTeamMembers(teamid, tokenText);
            foreach (var member in teammembers)
            {
                label6.Text = "Status: Processing";
                if (textBox3.Text.Length > 0)
                {
                    tempPRresponse = await tfsAccess.PRByMemberID(tokenText, member.identity.id, dateTimePicker1.Text, dateTimePicker2.Text, textBox3.Text);
                }
                else
                {
                    tempPRresponse = await tfsAccess.PRByMemberID(tokenText, member.identity.id, dateTimePicker1.Text, dateTimePicker2.Text, "");
                }
                PRresponse = PRresponse.Concat(tempPRresponse).ToList();
                PRresponse = PRresponse.OrderByDescending(obj => obj.creationDate).ToList();
                label4.Visible = true;
                commentsList = new List<GridData>();
            }
            label4.Visible = true;
            if (PRresponse.Count > 0)
            {
                getCommentsdata(PRresponse, tokenText);
                label4.Text = "Total PR Count: " + PRresponse.Count.ToString();
            }
            else
            {
                label4.Text = "No Pull Requests";
            }
            dataGridView1.Refresh();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Text = "Status: Idle";
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            progressBar1.Value = 0;
            label4.Visible = false;
            label3.Visible = true;
            label1.Visible = true;
            comboBox3.Visible = true;
            button6.Visible = true;
            //
            comboBox2.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RepositoryResponse.Count > 0)
            {
                label6.Text = "Status: Idle";
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                progressBar1.Value = 0;
                label4.Visible = false;
                label3.Visible = true;
                comboBox2.Visible = true;
                textBox2.Visible = true;
                label5.Visible = true;



                //
                label1.Visible = false;
                comboBox3.Visible = false;
                button6.Visible = false;

            }
        }
        private void DataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            label4.Text += " Comments: " + dataGridView1.RowCount;
        }
    }
}