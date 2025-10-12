using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    public partial class UserControlDevlopers : UserControl
    {
        private int? selectedDevId = null;
        private string oldDevUsername = null;
        private string oldDevEmail = null;

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
            string sql = "SELECT DevId, DevUsername, DevFullName, DevEmail, DevPassword, AdminUsername FROM DevInfo";

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Replace("'", "''");

                sql += $@" WHERE 
        DevId LIKE '%{search}%' OR
        DevUsername LIKE '%{search}%' OR
        DevFullName LIKE '%{search}%' OR
        DevEmail LIKE '%{search}%'";
            }

            sql += " ORDER BY DevId ASC";

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

            var idCell = row.Cells["dgvDevID"];
            if (idCell == null || idCell.Value == null || !int.TryParse(idCell.Value.ToString(), out int id))
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

        private void buttonRefresh_Click(object sender, EventArgs e)
        {

        }

 

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            string devUsername = textBoxDevUsername.Text.Trim();
            string devFullName = textBoxFullName.Text.Trim();
            string devEmail = textBoxEmail.Text.Trim();
            string devPassword = textBoxDevPassword.Text.Trim();

            string adminUsername = FormControlPortal.LoggedInUser ?? "";

            if (string.IsNullOrWhiteSpace(devUsername) || string.IsNullOrWhiteSpace(devFullName) ||
                string.IsNullOrWhiteSpace(devEmail) || string.IsNullOrWhiteSpace(devPassword))
            {
                MessageBox.Show("All fields are required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            devUsername = devUsername.Replace("'", "''");
            devEmail = devEmail.Replace("'", "''");
            devFullName = devFullName.Replace("'", "''");
            devPassword = devPassword.Replace("'", "''");
            adminUsername = adminUsername.Replace("'", "''");

            if ( selectedDevId == null)
            {

                var (uExists, eExists) = DataBase.CheckUsernameOrEmailExists(devUsername, devEmail);
                if (uExists || eExists)
                {
                    MessageBox.Show("Username or email already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertSql = $@"
        INSERT INTO DevInfo (DevUsername, DevFullName, DevEmail, DevPassword, AdminUsername) 
        VALUES ('{devUsername}', '{devFullName}', '{devEmail}', '{devPassword}', '{adminUsername}')";

                if (DataBase.ExecuteNonQuery(insertSql) > 0)
                {
                    MessageBox.Show("Developer added successfully!");
                    LoadDevelopers();
                }
            }
            else
            {
                if (devUsername == oldDevUsername && devEmail == oldDevEmail)
                {
                    MessageBox.Show("Please update something before saving!",
                                    "No Changes Detected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string updateSql = $@"
        UPDATE DevInfo 
        SET DevUsername = '{devUsername}', 
            DevFullName = '{devFullName}', 
            DevEmail = '{devEmail}', 
            DevPassword = '{devPassword}',
            AdminUsername = '{adminUsername}'
        WHERE DevId = {selectedDevId}";

                if (DataBase.ExecuteNonQuery(updateSql) > 0)
                {
                    MessageBox.Show("Developer updated successfully!");
                    LoadDevelopers();
                }
            }
        }


        private void buttonNewUser_Click_1(object sender, EventArgs e)
        {
            ClearFields();
            textBoxDevUsername.Focus();

        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedDevId == null)
            {
                MessageBox.Show("Please select a developer to delete.", "No selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this developer? This action cannot be undone.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            string sql = $"DELETE FROM DevInfo WHERE DevId = {selectedDevId}";

            int rows = DataBase.ExecuteNonQuery(sql);

            if (rows > 0)
            {
                LoadDevelopers();
            }
            else
            {
                MessageBox.Show("Delete failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadDevelopers();
            }
            else
            {
                LoadDevelopers(searchText);
            }

        }

        private void buttonRefresh_Click_1(object sender, EventArgs e)
        {
            LoadDevelopers();
            textBoxSearch.Text = "";

        }
    }
}
