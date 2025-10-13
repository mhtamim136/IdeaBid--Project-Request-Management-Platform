using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    public partial class UserControlAdmin_DevDashboard : UserControl
    {
        public UserControlAdmin_DevDashboard()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUserTypeChart();
            LoadProjectStatusChart();
        }





        private void LoadUserTypeChart()
        {
            try
            {
                string query = @"SELECT UserType, COUNT(*) AS TotalUsers 
                                 FROM UserInfo
                                 GROUP BY UserType";

                DataTable dt = DataBase.GetDataTable(query);

                chart1.Series.Clear();
                chart1.Titles.Clear();

                Series series = new Series("User Type Count");
                series.ChartType = SeriesChartType.Bar; 
                series.IsValueShownAsLabel = true;
                series.Color = System.Drawing.Color.CornflowerBlue;

                foreach (DataRow row in dt.Rows)
                {
                    string userType = row["UserType"].ToString();
                    int count = Convert.ToInt32(row["TotalUsers"]);
                    series.Points.AddXY(userType, count);
                }

                chart1.Series.Add(series);
                chart1.Titles.Add("Users by Type");
                chart1.ChartAreas[0].AxisX.Title = "User Type";
                chart1.ChartAreas[0].AxisY.Title = "Number of Users";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart: " + ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void LoadProjectStatusChart()
        {
            try
            {
                string query = @"
                    SELECT ps.StatusName, COUNT(pr.RequestID) AS TotalProjects
                    FROM ProjectStatus ps
                    LEFT JOIN ProjectRequest pr ON ps.StatusID = pr.StatusID
                    GROUP BY ps.StatusName
                    ORDER BY ps.StatusName
                ";


                DataTable dt = DataBase.GetDataTable(query);

                chart2.Series.Clear();
                chart2.Titles.Clear();

                Series series = new Series("Project Status");
                series.ChartType = SeriesChartType.Pie;  // Pie chart
                series.IsValueShownAsLabel = true;

                foreach (DataRow row in dt.Rows)
                {
                    string status = row["StatusName"].ToString();
                    int count = Convert.ToInt32(row["TotalProjects"]);
                    series.Points.AddXY(status, count);
                }

                chart2.Series.Add(series);
                chart2.Titles.Add("Projects by Status");

                chart2.Legends[0].Docking = Docking.Right;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ProjectStatus chart: " + ex.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserControlAdmin_DevDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
