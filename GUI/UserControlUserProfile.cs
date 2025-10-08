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
    public partial class UserControlUserProfile : UserControl
    {

        private int currentUserId;
        private  FormUserDashboard _dashboard;

        private string originalFullName = "";
        private string originalUserType = "";

        public UserControlUserProfile()
        {
            InitializeComponent();
            SetPasswordFieldProperties();
        }


        public int CurrentUserId
        {
            get { return currentUserId; }
            set { currentUserId = value; LoadUserInfo(_dashboard,value); }
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
                LoadUserInfo(_dashboard,currentUserId);
            }
            else
            {
                MessageBox.Show("User ID is not set.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void LoadUserInfo(FormUserDashboard dashboard, int userId)
        {
            _dashboard = dashboard;

            try
            {
                string sql = $"SELECT UserName, FullName, Email, UserType, CreatedDate FROM UserInfo WHERE ID = '{userId}'";
                DataTable dt = DataBase.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];


                    txtUserName.Text = row["UserName"].ToString();
                    txtUserName.ReadOnly = true; 

                    txtFullName.Text = row["FullName"].ToString();
                    txtFullName.ReadOnly = false; 

                    txtEmail.Text = row["Email"].ToString();
                    txtEmail.ReadOnly = true; 

                    string userType = row["UserType"].ToString();
                    SetUserTypeRadioButton(userType);

                    originalFullName = row["FullName"].ToString();
                    originalUserType = row["UserType"].ToString();

                    if (row["CreatedDate"] != DBNull.Value)
                    {
                        DateTime createdDate = Convert.ToDateTime(row["CreatedDate"]);
                        label1.Text = createdDate.ToString("dddd, MMM dd yyyy");
                    }
                    else
                    {
                        label1.Text = "Date not found";
                    }

                    currentUserId = userId;
                    _dashboard = dashboard;
                }
                else
                {
                    //MessageBox.Show("No user found with this ID.", "User Not Found",
                    //                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user information: {ex.Message}",
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (currentUserId <= 0)
            {
                MessageBox.Show("No user is selected.", "Error",
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
            
            string currentUserType = GetSelectedUserType();

           
            bool fullNameChanged = !string.Equals(originalFullName.Trim(), txtFullName.Text.Trim(), StringComparison.OrdinalIgnoreCase);

            
            bool userTypeChanged = !string.Equals(originalUserType, currentUserType, StringComparison.OrdinalIgnoreCase);

            return fullNameChanged || userTypeChanged;
        }


        private bool ValidateUpdateInput()
        {
            
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full name cannot be empty.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

         
            if (txtFullName.Text.Trim().Length > 100)
            {
                MessageBox.Show("Full name cannot exceed 100 characters.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
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
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error",
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
                string sql = $"SELECT Password FROM UserInfo WHERE ID = '{currentUserId}'";
                DataTable dt = DataBase.GetDataTable(sql);

                if (dt.Rows.Count > 0)
                {
                    string dbPassword = dt.Rows[0]["Password"].ToString();
                    return dbPassword == oldPassword; 
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
                string userType = GetSelectedUserType();

                string sql = $@"UPDATE UserInfo 
                              SET FullName = '{txtFullName.Text.Trim()}', 
                                  UserType = '{userType}'
                              WHERE ID = '{currentUserId}'";

                int rowsAffected = DataBase.ExecuteNonQuery(sql);

                if (rowsAffected > 0)
                {
                    FormUserDashboard.WelComeLabelChnaged(_dashboard, currentUserId);
                    MessageBox.Show("User information updated successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetOriginalData();

                    LoadUserInfo(_dashboard, currentUserId);
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
                string userType = GetSelectedUserType();

                string sql = $@"UPDATE UserInfo 
                              SET FullName = '{txtFullName.Text.Trim()}',
                                  UserType = '{userType}',
                                  Password = '{txtNewPassword.Text}' 
                              WHERE ID = '{currentUserId}'";


                int rowsAffected = DataBase.ExecuteNonQuery(sql);

                if (rowsAffected > 0)
                {
                    FormUserDashboard.WelComeLabelChnaged(_dashboard, currentUserId);
                    MessageBox.Show("User information and password updated successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ResetOriginalData();

                    ClearPasswordFields();

                    LoadUserInfo(_dashboard, currentUserId);
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
            originalFullName = txtFullName.Text.Trim();
            originalUserType = GetSelectedUserType();
        }

        private string GetSelectedUserType()
        {
            if (radioButtonStudent.Checked)
                return "Student";
            else if (radioButtonCompany.Checked)
                return "Company";
            else if (radioButtonOther.Checked)
                return "Other";
            else
                return "Other"; 
        }


        private void SetUserTypeRadioButton(string userType)
        {
            radioButtonStudent.Checked = false;
            radioButtonCompany.Checked = false;
            radioButtonOther.Checked = false;

            switch (userType.ToLower())
            {
                case "student":
                    radioButtonStudent.Checked = true;
                    break;
                case "company":
                    radioButtonCompany.Checked = true;
                    break;
                case "other":
                    radioButtonOther.Checked = true;
                    break;
                default:
                    radioButtonOther.Checked = true;
                    break;
            }
        }



        private void ClearPasswordFields()
        {
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void ClearFields()
        {
            txtUserName.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
            label1.Text = "";

            ClearPasswordFields();

            radioButtonStudent.Checked = false;
            radioButtonCompany.Checked = false;
            radioButtonOther.Checked = false;

 
            originalFullName = "";
            originalUserType = "";

            currentUserId = 0;
        }

        public void SetControlsEnabled(bool enabled)
        {
            txtFullName.Enabled = enabled; 
            radioButtonStudent.Enabled = enabled;
            radioButtonCompany.Enabled = enabled;
            radioButtonOther.Enabled = enabled;
            btnUpdate.Enabled = enabled;

            // Password fields
            txtOldPassword.Enabled = enabled;
            txtNewPassword.Enabled = enabled;
            txtConfirmPassword.Enabled = enabled;

            // Keep these readonly
            txtUserName.ReadOnly = true;
            txtEmail.ReadOnly = true;
        }

        private void UserControlUserProfile_Load(object sender, EventArgs e)
        {
            SetPasswordFieldProperties();
        }


        private void UpdateChangeIndicator()
        {
            if (HasProfileDataChanged())
            {
                btnUpdate.Text = "Update";
                btnUpdate.ForeColor = Color.Red;
            }
            else
            {
                btnUpdate.Text = "Update";
                btnUpdate.ForeColor = Color.Black;
            }
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            UpdateChangeIndicator();
        }

        private void radioButtonStudent_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChangeIndicator();
        }

        private void radioButtonCompany_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChangeIndicator();
        }

        private void radioButtonOther_CheckedChanged(object sender, EventArgs e)
        {
            UpdateChangeIndicator();
        }

 





    }
}

