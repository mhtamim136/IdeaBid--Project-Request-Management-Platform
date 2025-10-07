using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
using MetroFramework.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{

    public partial class FormLogin : Form

    {
        private Panel panelIndicator;
        private Timer invalidWaringLoginLabelTimer;
        public FormLogin()
        {

            InitializeComponent();
            textBoxPasswordLogin.UseSystemPasswordChar = true;
            textBoxPasswordSignUp.UseSystemPasswordChar = true;
            checkBoxVisibleLogin.CheckedChanged += checkBoxVisibleLogin_CheckedChanged;
            checkBoxVisibleSignUp.CheckedChanged += checkBoxVisibleSignUp_CheckedChanged;
            panelLogin.Visible = true;
            panelSignUp.Visible = false;

            CreateIndicator();

            invalidWaringLoginLabelTimer = new Timer();
            invalidWaringLoginLabelTimer.Interval = 4000; 
            invalidWaringLoginLabelTimer.Tick += (s, e) =>
            {
                invalidWaringLoginLabelTimer.Stop();
                labelInvalidWaringLogin.Visible = false;
            };

        }

        private void StartAutoHideInvalidLabelTimer()
        {
            invalidWaringLoginLabelTimer.Stop();
            invalidWaringLoginLabelTimer.Start();
        }


        private void CreateIndicator()
        {
            panelIndicator = new Panel();
            panelIndicator.BackColor = Color.Teal;
            panelIndicator.Height = 4;
            panelIndicator.Width = buttonLoginClickLogin.Width;

            panelIndicator.Left = buttonLoginClickLogin.Left;
            panelIndicator.Top = buttonLoginClickLogin.Bottom + 2;

            panelLogin.Controls.Add(panelIndicator);
            panelIndicator.BringToFront();
        }

        private void MoveIndicator(Button targetButton, Panel targetPanel)
        {
            if (panelIndicator.Parent != targetPanel)
            {
                panelIndicator.Parent?.Controls.Remove(panelIndicator);
                targetPanel.Controls.Add(panelIndicator);
            }

            panelIndicator.Width = targetButton.Width;
            panelIndicator.Left = targetButton.Left;
            panelIndicator.Top = targetButton.Bottom + 2;
            panelIndicator.BringToFront();
            panelIndicator.Visible = true;
        }




        private void checkBoxVisibleLogin_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPasswordLogin.UseSystemPasswordChar = !checkBoxVisibleLogin.Checked;
        }
        private void checkBoxVisibleSignUp_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPasswordSignUp.UseSystemPasswordChar = !checkBoxVisibleSignUp.Checked;
        }


        private void FormLogin_Load(object sender, EventArgs e)
        {
            panelSignUp.Visible = false;
            LoadRemembered();
            textBoxUserNameLogin.Focus();
        }

        private void buttonLoginClickLogin_Click(object sender, EventArgs e)
        {
            textBoxUserNameLogin.Focus();
        }

        private void buttonSignUpClickLogin_Click(object sender, EventArgs e)
        {
            ClearLoginFields();
            panelSignUp.Visible = true;
            panelLogin.Visible = false;
            textBoxUserNameSignUp.Focus();

            MoveIndicator(buttonSignUpClickSignUP, panelSignUp);
        }

        private void buttonLoginClickSignUP_Click(object sender, EventArgs e)
        {
            ClearSignUpField();
            panelLogin.Visible = true;
            panelSignUp.Visible = false;
            textBoxUserNameLogin.Focus();

            MoveIndicator(buttonLoginClickLogin, panelLogin);

        }

        private void buttonSignUpClickSignUP_Click(object sender, EventArgs e)
        {
            textBoxUserNameSignUp.Focus();
        }

        private void buttonClearSignUp_Click(object sender, EventArgs e)
        {
            ClearSignUpField();
            textBoxUserNameSignUp.Focus();
        }



        private void buttonSignUP_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserNameSignUp.Text;
            string fullName = textBoxFullNameSignUp.Text;
            string email = textBoxEmailSignUp.Text;
            string password = textBoxPasswordSignUp.Text;
            string userType = radioButtonStudentSignUp.Checked ? "Student" :
                              radioButtonCompanySignUp.Checked ? "Company" :
                              radioButtonOtherSignUp.Checked ? "Others" : "";

            

            var (error, field) = ValidationHelper.ValidateUserInput(userName, fullName, email, password, userType);

            if (error != null)
            {
                MessageBox.Show(error, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                switch (field)
                {
                    case "username": textBoxUserNameSignUp.Focus(); break;
                    case "fullname": textBoxFullNameSignUp.Focus(); break;
                    case "email": textBoxEmailSignUp.Focus(); break;
                    case "password": textBoxPasswordSignUp.Focus(); break;
                    case "usertype": radioButtonOtherSignUp.Checked = true; break;
                }

                return;
            }

            var (uExists, eExists) = DataBase.CheckUsernameOrEmailExists(userName, email);
            if (uExists || eExists)
            {
                MessageBox.Show("Username or email already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //string query = "INSERT INTO UserInfo (UserName, FullName, Email, UserType, Password) VALUES (@UserName, @FullName, @Email, @UserType, @Password)";

            //var parameters = DataBase.CreateParameters(
            //    ("@UserName", userName),
            //    ("@FullName", fullName),
            //    ("@Email", email),
            //    ("@UserType", userType),
            //    ("@Password", password)
            //);
            // int result = DataBase.ExecuteNonQuery(query, parameters);

            string query = $@"
    INSERT INTO UserInfo (UserName, FullName, Email, UserType, Password)
    VALUES ('{userName}', '{fullName}', '{email}', '{userType}', '{password}')";

            int result = DataBase.ExecuteNonQuery(query);

            if (result > 0)
            {
                MessageBox.Show("User registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearSignUpField();
                panelLogin.Visible = true;
                panelSignUp.Visible = false;
                textBoxUserNameLogin.Focus();
                MoveIndicator(buttonLoginClickLogin, panelLogin);
            }


        }


        //Login button
        private void buttonLogin_Click(object sender, EventArgs e)
        {

            labelInvalidWaringLogin.Visible = false;

            string username = textBoxUserNameLogin.Text.Trim();
            string password = textBoxPasswordLogin.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
               // MessageBox.Show("Please enter username and password.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                labelInvalidWaringLogin.Visible = true;
                StartAutoHideInvalidLabelTimer();
                textBoxUserNameLogin.Focus();
                return;
            }

            string role = DataBase.AuthenticateRole(username, password);

            if (role == null)
            {
                //MessageBox.Show("Invalid username or password.", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                labelInvalidWaringLogin.Visible = true;
                StartAutoHideInvalidLabelTimer();
                textBoxPasswordLogin.Focus();
                return;
            }

            if (checkBoxRememberMe.Checked)
                SaveCredentials(username, password, true);
            else
            {
                SaveCredentials("", "", false);
                ClearLoginFields();
            }


            Form child = role.Equals("User", StringComparison.OrdinalIgnoreCase)
                ? (Form)new FormUserDashboard(username)
                : new FormControlPortal(username, role);


            child.Owner = this;
            child.FormClosed += (s, args) =>
            {
                this.Show();
            };

            child.Show();
            this.Hide();

        }

        private void ClearLoginFields()
        {
            textBoxUserNameLogin.Text = "";
            textBoxPasswordLogin.Text = "";
        }

        private void ClearSignUpField()
        {
            textBoxUserNameSignUp.Text = "";
            textBoxFullNameSignUp.Text = "";
            textBoxEmailSignUp.Text = "";
            textBoxPasswordSignUp.Text = "";

            radioButtonStudentSignUp.Checked = false;
            radioButtonCompanySignUp.Checked = false;
            radioButtonOtherSignUp.Checked = false;
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            Control current = sender as Control;

            Panel activePanel = panelIndicator.Parent as Panel;

            if (activePanel == panelSignUp)
            {
                if (current == textBoxUserNameSignUp)
                    textBoxFullNameSignUp.Focus();
                else if (current == textBoxFullNameSignUp)
                    textBoxEmailSignUp.Focus();
                else if (current == textBoxEmailSignUp)
                    radioButtonStudentSignUp.Focus();
                else if (current == radioButtonStudentSignUp)
                        radioButtonCompanySignUp.Focus();
                 else if (current == radioButtonCompanySignUp)
                        radioButtonOtherSignUp.Focus();
                else if (current == radioButtonOtherSignUp)
                    textBoxPasswordSignUp.Focus();
                else if (current == textBoxPasswordSignUp)
                    buttonSignUP.PerformClick();
            }


            else if (activePanel == panelLogin)
            {
                if (current == textBoxUserNameLogin)
                    textBoxPasswordLogin.Focus();
                else if (current == textBoxPasswordLogin)
                    buttonLogin.PerformClick();
            }
        }


        private void LoadRemembered()
        {
            try
            {
                if (Properties.Settings.Default.RememberMe)
                {
                    textBoxUserNameLogin.Text = Properties.Settings.Default.RememberedUsername;
                    textBoxPasswordLogin.Text = Properties.Settings.Default.RememberedPassword;
                    checkBoxRememberMe.Checked = true;
                }
                else
                {
                    checkBoxRememberMe.Checked = false;
                }
            }
            catch
            {
                checkBoxRememberMe.Checked = false;
            }
        }

        private void SaveCredentials(string username, string password, bool remember)
        {
            Properties.Settings.Default.RememberMe = remember;
            Properties.Settings.Default.RememberedUsername = remember ? (username ?? "") : "";
            Properties.Settings.Default.RememberedPassword = remember ? (password ?? "") : "";
            Properties.Settings.Default.Save();
        }

        public TextBox TextBoxUserNameLogin
        {
            get { return textBoxUserNameLogin; }
        }


    }

}
