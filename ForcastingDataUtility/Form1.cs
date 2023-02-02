using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForcastingDataUtility
{
    public partial class Form1 : Form
    {
        RequestItem request = new RequestItem();
        string Key = "972e73f2-4b21-46f5-ac69-880ca58076c2";
        public Form1()
        {
            InitializeComponent();
            /// default diseble
            ProjectIdsLabel.Visible = false;
            ProjectIdsText.Visible = false;
            AccountIdLabel.Visible = false;
            AccountIdText.Visible = false;

            /// Select Environments
            SelectEnvironment.Items.Add("http://localhost/coreapi");
            SelectEnvironment.Items.Add("http://20.204.28.204/QaApi");
            SelectEnvironment.Items.Add("https://staging.prescinto.ai/api");
            SelectEnvironment.Items.Add("https://preprodpatch.prescinto.ai/api");
            SelectEnvironment.Items.Add("https://api.prescinto.ai");

            /// Select Category  
            SelectCategory.Items.Add("All Projects");
            SelectCategory.Items.Add("One or More Projects");
            SelectCategory.Items.Add("All Projects By Account Wise");

            /// default selection
            SelectEnvironment.SelectedItem = "http://localhost/coreapi";
            SelectCategory.SelectedItem = "All Projects";
            AllProjectsButtonPosition();
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //dataGridView1.Rows.Add($"Forcasting data Save Successfully {5101}");
        }

        private void SelectEnvironment_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SelectEnvironment.Text)
            {
                case "http://localhost/coreapi":
                    request.ApiURL = "http://localhost/coreapi";
                    break;

                case "http://20.204.28.204/QaApi":
                    request.ApiURL = "http://20.204.28.204/QaApi";
                    break;

                case "https://staging.prescinto.ai/api":
                    request.ApiURL = "https://staging.prescinto.ai/api";
                    break;

                case "https://preprodpatch.prescinto.ai/api":
                    request.ApiURL = "https://preprodpatch.prescinto.ai/api";
                    break;

                case "https://api.prescinto.ai":
                    request.ApiURL = "https://api.prescinto.ai";
                    break;
            }
        }

        private void SelectCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SelectCategory.Text)
            {
                case "One or More Projects":
                    ProjectIdsLabel.Visible = true;
                    ProjectIdsText.Visible = true;
                    AccountIdLabel.Visible = false;
                    AccountIdText.Visible = false;
                    AccountAndProjectsButtonPosition();
                    break;

                case "All Projects By Account Wise":
                    AccountIdLabel.Visible = true;
                    AccountIdText.Visible = true;
                    ProjectIdsLabel.Visible = false;
                    ProjectIdsText.Visible = false;
                    AccountAndProjectsButtonPosition();
                    break;

                case "All Projects":
                    AccountIdLabel.Visible = false;
                    AccountIdText.Visible = false;
                    ProjectIdsLabel.Visible = false;
                    ProjectIdsText.Visible = false;
                    AllProjectsButtonPosition();
                    break;
            }
            //   TestText.Text = SelectCategory.Text;
        }
        public void AllProjectsButtonPosition()
        {
            SubmitButton.Location = new System.Drawing.Point(510, 13);
            SubmitButton.Margin = new System.Windows.Forms.Padding(3);
            SubmitButton.Size = new System.Drawing.Size(75, 24);
        }
        public void AccountAndProjectsButtonPosition()
        {
            SubmitButton.Location = new System.Drawing.Point(681, 13);
            SubmitButton.Margin = new System.Windows.Forms.Padding(10);
            SubmitButton.Size = new System.Drawing.Size(75, 24);
        }
        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            SubmitButton.Enabled = false;
            switch (SelectCategory.Text)
            {
                case "All Projects":
                    await GetAllProjects();
                    break;

                case "One or More Projects":
                    await OneOrMoreProject();
                    break;

                case "All Projects By Account Wise":
                    await AllProjectsByAccountWise();
                    break;
            }
        }
        public async Task<List<ProjectDetailsEntity>> GetAllProjects()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Key", Key);
                    using (HttpResponseMessage responce = await client.GetAsync(request.ApiURL + "/Api/Management/GetProjectList"))
                    {
                        using (HttpContent content = responce.Content)
                        {
                            List<ProjectDetailsEntity> aavailableProjects = content.ReadAsAsync<List<ProjectDetailsEntity>>().Result;
                            if (aavailableProjects != null)
                            {
                                if (SelectCategory.Text == "All Projects By Account Wise") return aavailableProjects;
                                foreach (ProjectDetailsEntity item in aavailableProjects)
                                {
                                    await FetchForecastDataUtility(item.ProjectID);
                                }
                                SubmitButton.Enabled = true;
                                return aavailableProjects;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception)
            {
                MessageBox.Show($"Please Add Ip Address in Portal selective Environment");
                return null;
            }
        }
        public async Task<string> OneOrMoreProject()
        {
            string Number = ProjectIdsText.Text;
            var project = Number?.Split(',')?.Select(Int32.Parse)?.ToList();
            SubmitButton.Enabled = false;
            for (int i = 0; i < project.Count; i++)
            {
                await FetchForecastDataUtility(project[i]);
            }
            SubmitButton.Enabled = true;
            return null;
        }
        public async Task<List<ProjectDetailsEntity>> AllProjectsByAccountWise()
        {
            int Accountid = Convert.ToInt32(AccountIdText.Text);
            List<ProjectDetailsEntity> aavailableProjects = await GetAllProjects();
            var ProjectIdds = aavailableProjects.Where(x => x.AccountId == Accountid).ToList();
            foreach (var item in aavailableProjects)
            {
                await FetchForecastDataUtility(item.ProjectID);
            }
            SubmitButton.Enabled = true;
            return aavailableProjects;
        }
        public async Task<string> FetchForecastDataUtility(int projectId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(request.ApiURL + "/Api/HistoryData/FetchForecastDataUtility?projectId=" + projectId);
                    client.DefaultRequestHeaders.Add("Key", Key);
                    var content = new FormUrlEncodedContent(new[]
                    {
                     new KeyValuePair<string, string>("", "")
                    });
                    var result = await client.PostAsync("", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    if (result != null && result.IsSuccessStatusCode && resultContent.Length > 0)
                    {
                        dataGridView1.Rows.Add($"Forcasting Data Save Successfully {projectId}");
                        return resultContent;
                    }
                    else
                    {
                        dataGridView1.Rows.Add($"Forcasting Data Saving Failed {projectId}");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public class DataT
        {
            public string Data { get; set; }
            public string Message { get; set; }
        }

        private void TestText_TextChanged(object sender, EventArgs e)
        {

        }

        public static void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public async Task<string> FetchForecastData(int projectId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(request.ApiURL + "/Api/HistoryData/FetchForecastData?projectId=" + projectId);
                    client.DefaultRequestHeaders.Add("Key", Key);
                    var content = new FormUrlEncodedContent(new[]
                    {
                     new KeyValuePair<string, string>("", "")
                    });
                    var result = await client.PostAsync("", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    if (result != null && result.IsSuccessStatusCode && resultContent != "[]")
                    {
                        string HierarchicalStructureFile = AppDomain.CurrentDomain.BaseDirectory + @"\Data.txt";
                        File.WriteAllText(HierarchicalStructureFile, $"Forcasting Data Available {projectId}");
                        return resultContent;
                    }
                    else
                    {                        
                        return null;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
