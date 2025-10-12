using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    public partial class UserControlDevlopers : UserControl
    {
        private int? selectedDevId = null;
        private string oldDevUsername = null;
        private string oldDevEmail = null;
        private int adminId;

        public UserControlDevlopers()
        {
            InitializeComponent();

            textBoxSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    buttonSearch.PerformClick();
                    e.SuppressKeyPress = true;
                }
            };

            dgvTable.MultiSelect = false;
            dgvTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTable.SelectionChanged += dgvDev_SelectionChanged;

            buttonDelete.Enabled = false;
        }


        public void LoadDevelopers(string search = null)
        {
            string sql = @"
                SELECT d.DevId, d.DevUsername, d.DevFullName, d.DevEmail, d.DevPassword,
                       a.AdminUsername
                FROM DevInfo d
                LEFT JOIN AdminInfo a ON d.AdminID = a.AdminID";

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Replace("'", "''");

                sql += $@" WHERE 
                    d.DevId LIKE '%{search}%' OR
                    d.DevUsername LIKE '%{search}%' OR
                    d.DevFullName LIKE '%{search}%' OR
                    d.DevEmail LIKE '%{search}%' OR
                    a.AdminUsername LIKE '%{search}%'";
            }

            sql += " ORDER BY d.DevId ASC";

            DataTable dt = DataBase.GetDataTable(sql);
            dgvTable.AutoGenerateColumns = false;
            dgvTable.DataSource = dt;

            ClearFields();
        }

        private void dgvDev_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count == 0)
            {
                selectedDevId = null;
                oldDevUsername = null;
                oldDevEmail = null;
                buttonDelete.Enabled = false;
                return;
            }

            DataGridViewRow row = dgvTable.SelectedRows[0];

            if (row.Cells["dgvDevID"].Value == null || !int.TryParse(row.Cells["dgvDevID"].Value.ToString(), out int id))
            {
                selectedDevId = null;
                buttonDelete.Enabled = false;
                return;
            }

            selectedDevId = id;
            oldDevUsername = row.Cells["dgvDevUserName"].Value?.ToString();
            oldDevEmail = row.Cells["dgvDevEmail"].Value?.ToString();

            textBoxDevId.Text = id.ToString();
            textBoxDevUsername.Text = oldDevUsername;
            textBoxFullName.Text = row.Cells["dgvDevFullName"].Value?.ToString();
            textBoxEmail.Text = oldDevEmail;
            textBoxDevPassword.Text = row.Cells["dgvDevPassword"].Value?.ToString();

            buttonDelete.Enabled = true;
        }

        private void ClearFields()
        {
            textBoxDevId.Text = "Auto Generated";
            textBoxDevUsername.Text = "";
            textBoxFullName.Text = "";
            textBoxEmail.Text = "";
            textBoxDevPassword.Text = "";

            dgvTable.ClearSelection();
            if (dgvTable.CurrentCell != null)
                dgvTable.CurrentCell = null;

            selectedDevId = null;
            oldDevUsername = null;
            oldDevEmail = null;

            buttonDelete.Enabled = false;
        }

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            string devUsername = textBoxDevUsername.Text.Trim();
            string devFullName = textBoxFullName.Text.Trim();
            string devEmail = textBoxEmail.Text.Trim();
            string devPassword = textBoxDevPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(devUsername) ||
                string.IsNullOrWhiteSpace(devFullName) ||
                string.IsNullOrWhiteSpace(devEmail) ||
                string.IsNullOrWhiteSpace(devPassword))
            {
                MessageBox.Show("All fields are required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            devUsername = devUsername.Replace("'", "''");
            devFullName = devFullName.Replace("'", "''");
            devEmail = devEmail.Replace("'", "''");
            devPassword = devPassword.Replace("'", "''");

            try
            {
                if (selectedDevId == null)
                {
                    var (uExists, eExists) = DataBase.CheckUsernameOrEmailExists(devUsername, devEmail);
                    if (uExists || eExists)
                    {
                        MessageBox.Show("Username or email already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string insertSql = $@"
                        INSERT INTO DevInfo (DevUsername, DevFullName, DevEmail, DevPassword, AdminID)
                        VALUES ('{devUsername}', '{devFullName}', '{devEmail}', '{devPassword}', {adminId})";

                    if (DataBase.ExecuteNonQuery(insertSql) > 0)
                    {
                        MessageBox.Show("Developer added successfully!");
                        LoadDevelopers();
                    }
                }
                else
                {
                    string updateSql = $@"
                        UPDATE DevInfo
                        SET DevUsername='{devUsername}',
                            DevFullName='{devFullName}',
                            DevEmail='{devEmail}',
                            DevPassword='{devPassword}',
                            AdminID={adminId}
                        WHERE DevId={selectedDevId}";

                    if (DataBase.ExecuteNonQuery(updateSql) > 0)
                    {
                        MessageBox.Show("Developer updated successfully!");
                        LoadDevelopers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving developer:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            LoadDevelopers(textBoxSearch.Text.Trim());
        }

        private void buttonRefresh_Click_1(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            LoadDevelopers();
        }

        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {

            if (selectedDevId == null)
            {
                MessageBox.Show("Please select a developer to delete.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this developer?",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            string sql = $"DELETE FROM DevInfo WHERE DevId = {selectedDevId}";

            int rows = DataBase.ExecuteNonQuery(sql);

            if (rows > 0)
                LoadDevelopers();
            else
                MessageBox.Show("Delete failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UserControlDevlopers_Load_1(object sender, EventArgs e)
        {
            try
            {
                string sql = $"SELECT AdminID FROM AdminInfo WHERE AdminUsername = '{FormControlPortal.LoggedInUser}'";
                object result = DataBase.ExecuteScalar(sql);

                adminId = int.TryParse(result?.ToString(), out int id) ? id : 0;

                LoadDevelopers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admin info: " + ex.Message);
            }

        }
    }
}
