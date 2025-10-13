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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    public partial class UserControlDevProfile : UserControl
    {
        private int currentUserId;
        private string originalFullName = "";
        private string originalEmail = "";
        public UserControlDevProfile()
        {
            InitializeComponent();
            SetPasswordFieldProperties();
 
        }




        private void SetPasswordFieldProperties()
        {
            txtOldPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }


        public void LoadUserInfo()
        {
            if (currentUserId > 0)
            {
                LoadUserInfo(currentUserId);
            }
            else
            {
                MessageBox.Show("Developer ID is not set.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void LoadUserInfo(int devId)
        {
            try
            {
                string sql = $"SELECT DevID, DevUsername, DevFullName, DevEmail FROM DevInfo WHERE DevID = {devId}";


                DataTable dt = DataBase.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtDevUserName.Text = row["DevUsername"].ToString();
                    txtDevUserName.ReadOnly = true; 

                    txtDevFullName.Text = row["DevFullName"].ToString();
                    txtDevFullName.ReadOnly = false; 

                    txtDevEmail.Text = row["DevEmail"].ToString();
                    txtDevEmail.ReadOnly = true; 

                    originalFullName = row["DevFullName"].ToString();
                    originalEmail = row["DevEmail"].ToString();

                    currentUserId = devId;
                }
                else
                {
                    MessageBox.Show("No developer found with this ID.", "Developer Not Found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading developer information: {ex.Message}",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentUserId <= 0)
            {
                MessageBox.Show("No developer is selected.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isPasswordChange = !string.IsNullOrWhiteSpace(txtOldPassword.Text) ||
                                   !string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                                   !string.IsNullOrWhiteSpace(txtConfirmPassword.Text);

            bool isProfileChanged = HasProfileDataChanged();

            if (!isPasswordChange && !isProfileChanged)
            {
                MessageBox.Show("Please change anything to update.", "No Changes Detected",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (isPasswordChange)
            {
                if (ValidatePasswordInput())
                {
                    if (VerifyOldPassword(txtOldPassword.Text))
                    {
                        if (ValidateUpdateInput()) 
                        {
                            UpdateUserInfoWithPassword();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Current password is incorrect.", "Authentication Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtOldPassword.Focus();
                    }
                }
            }
            else
            {
                if (ValidateUpdateInput())
                {
                    UpdateUserInfo();
                }
            }
        }
        private bool HasProfileDataChanged()
        {
            bool fullNameChanged = !string.Equals(originalFullName.Trim(), txtDevFullName.Text.Trim(), StringComparison.OrdinalIgnoreCase);

            return fullNameChanged;
        }

        private bool ValidateUpdateInput()
        {
            if (string.IsNullOrWhiteSpace(txtDevFullName.Text))
            {
                MessageBox.Show("Full name cannot be empty.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDevFullName.Focus();
                return false;
            }

            if (txtDevFullName.Text.Trim().Length > 100)
            {
                MessageBox.Show("Full name cannot exceed 100 characters.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDevFullName.Focus();
                return false;
            }

            return true;
        }
        private bool ValidatePasswordInput()
        {
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text))
            {
                MessageBox.Show("Please enter your current password.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Please enter a new password.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please confirm your new password.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return false;
            }

            if (txtOldPassword.Text.Trim() == txtNewPassword.Text.Trim())
            {
                MessageBox.Show("New password must be different from your current password.\nPlease choose a different password.", "Same Password Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Clear();
                txtConfirmPassword.Clear(); 
                txtNewPassword.Focus();
                return false;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("New password and confirm password do not match.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            return true;
        }
        private bool VerifyOldPassword(string oldPassword)
        {
            try
            {
                string sql = $"SELECT DevPassword FROM DevInfo WHERE DevID = {currentUserId}";

                DataTable dt = DataBase.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    string dbPassword = dt.Rows[0]["DevPassword"].ToString().Trim();
                    return dbPassword == oldPassword.Trim();

                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error verifying password: {ex.Message}", "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UpdateUserInfo()
        {
            try
            {
                string sql = $@"UPDATE DevInfo 
              SET DevFullName = '{txtDevFullName.Text.Trim().Replace("'", "''")}'
              WHERE DevID = {currentUserId}";


                int rowsAffected = DataBase.ExecuteNonQuery(sql);

                if (rowsAffected > 0)
                {
                    ((FormControlPortal)this.ParentForm)?.RefreshWelcomeLabel();
                    MessageBox.Show("Developer information updated successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetOriginalData();

                    LoadUserInfo(currentUserId);
                }
                else
                {
                    MessageBox.Show("No information was updated. Please try again.", "Update Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex) when (ex.Number == 8152)
            {
                MessageBox.Show("Data is too large. Please make it shorter.", "Data Too Long",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUserInfoWithPassword()
        {
            try
            {
                string sql = $@"UPDATE DevInfo 
              SET DevFullName = '{txtDevFullName.Text.Trim().Replace("'", "''")}',
                  DevPassword = '{txtNewPassword.Text.Trim().Replace("'", "''")}'
              WHERE DevID = {currentUserId}";


                int rowsAffected = DataBase.ExecuteNonQuery(sql);

                if (rowsAffected > 0)
                {
                    ((FormControlPortal)this.ParentForm)?.RefreshWelcomeLabel();

                    MessageBox.Show("Developer information and password updated successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetOriginalData();

                    ClearPasswordFields();

                    LoadUserInfo(currentUserId);
                }
                else
                {
                    MessageBox.Show("No information was updated. Please try again.", "Update Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex) when (ex.Number == 8152)
            {
                MessageBox.Show("Data is too large. Please make it shorter.", "Data Too Long",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetOriginalData()
        {
            originalFullName = txtDevFullName.Text.Trim();
        }

        private void ClearPasswordFields()
        {
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void ClearFields()
        {
            txtDevUserName.Text = "";
            txtDevFullName.Text = "";
            txtDevEmail.Text = "";

            ClearPasswordFields();

            originalFullName = "";
            originalEmail = "";
            currentUserId = 0;
        }


        public void SetControlsEnabled(bool enabled)
        {
            txtDevFullName.Enabled = enabled; 
            btnUpdate.Enabled = enabled;

            txtOldPassword.Enabled = enabled;
            txtNewPassword.Enabled = enabled;
            txtConfirmPassword.Enabled = enabled;

            txtDevUserName.ReadOnly = true;
            txtDevEmail.ReadOnly = true;
        }



        private void txtDevUserName_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeIndicator();
        }

        private void UpdateChangeIndicator()
        {
            if (HasProfileDataChanged())
            {
                btnUpdate.Text = "Update *"; 
                btnUpdate.ForeColor = Color.Red;
            }
            else
            {
                btnUpdate.Text = "Update";
                btnUpdate.ForeColor = Color.Black;
            }
        }


        private void UserControlDevProfile_Load_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FormControlPortal.Role) ||
                    string.IsNullOrWhiteSpace(FormControlPortal.LoggedInUser))
                {
                    this.Visible = false;
                    return;
                }

                if (!FormControlPortal.Role.Equals("Dev", StringComparison.OrdinalIgnoreCase))
                {
                    this.Visible = false;
                    return;
                }

                string sql = $"SELECT DevID FROM DevInfo WHERE DevUsername = '{FormControlPortal.LoggedInUser}'";
                object result = DataBase.ExecuteScalar(sql);

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    currentUserId = id;
                    LoadUserInfo(currentUserId);
                    SetPasswordFieldProperties();
                }
                else
                {
                    MessageBox.Show("Developer ID not found for this user.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error while loading developer info:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
