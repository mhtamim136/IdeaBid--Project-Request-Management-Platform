using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    public partial class UserControlProjectBoard : UserControl
    {
        public UserControlProjectBoard()
        {
            InitializeComponent();
        }



        public void LoadRequests(string search = null)
        {
            string sql = @"
                        SELECT
                            pr.RequestID,
                            pr.UserID,
                            c.CategoryName   AS Category,
                            pr.Languages     AS Languages,
                            pr.Title,
                            pr.Description,
                            pr.BudgetOffered AS Budget,
                            pr.Deadline      AS Deadline,
                            s.StatusName     AS Status,
                            pr.PostedDate    AS PostedDate
                        FROM ProjectRequest pr
                        JOIN Category c ON pr.CategoryID = c.CategoryID
                        JOIN ProjectStatus s ON pr.StatusID = s.StatusID
                        WHERE 1=1
                    ";

            if (!string.IsNullOrWhiteSpace(search))
            {
                // if user typed number, search by ID too
                if (int.TryParse(search, out int idSearch))
                {
                    sql += $@"
                AND (
                    pr.RequestID = {idSearch}
                    OR pr.UserID = {idSearch}
                    OR pr.Title LIKE '%{search}%'
                    OR c.CategoryName LIKE '%{search}%'
                    OR pr.Languages LIKE '%{search}%'
                )";
                }
                else
                {
                    sql += $@"
                AND (
                    pr.Title LIKE '%{search}%'
                    OR c.CategoryName LIKE '%{search}%'
                    OR pr.Languages LIKE '%{search}%'
                )";
                }
            }

            sql += " ORDER BY pr.StatusID ASC";

            DataTable dt = DataBase.GetDataTable(sql);

            dataGridViewProjectBoard.AutoGenerateColumns = false;
            dataGridViewProjectBoard.DataSource = dt;
            dataGridViewProjectBoard.ClearSelection();
        }


        private void UserControlProjectBoard_Load(object sender, EventArgs e)
        {
            this.LoadRequests();
        }

        private void buttonResponse_Click(object sender, EventArgs e)
        {
            if (dataGridViewProjectBoard.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int requestId = Convert.ToInt32(dataGridViewProjectBoard.SelectedRows[0].Cells["dgvRequestID"].Value);

            using (var form = new FormNewResponed(FormControlPortal.LoggedInUser, FormControlPortal.Role, requestId))
            {
                if (form.ShowDialog() == DialogResult.OK)  
                {
                    LoadRequests(); 
                }
            }

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.LoadRequests();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.LoadRequests(textBoxSearch.Text.Trim());
        }

        private void dataGridViewProjectBoard_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewProjectBoard.ClearSelection();
            dataGridViewProjectBoard.CurrentCell = null;
        }
    }
}
