using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    public partial class FormControlPortal : Form
    {
        //Global Variables
        public static string LoggedInUser { get; private set; }
        public static string Role { get; private set; }
        private bool isLogoutClicked = false;
        private bool isCloseConfirmed = false;

        //Reference to Login Form
        public FormControlPortal(string username, string role) : this()
        {
            LoggedInUser = username;
            Role = role;
            string tableName, columnName, userNameColumn; ;

            if (Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                tableName = "AdminInfo";
                columnName = "AdminFullName";
                userNameColumn = "AdminUserName";
            }
            else
            {
                tableName = "DevInfo";
                columnName = "DevFullName";
                userNameColumn = "DevUserName";
            }

            string fullName = DataBase.ExecuteScalar(
    $@"SELECT {columnName} FROM {tableName} WHERE {userNameColumn} = '{username}'"
)?.ToString();

            labelAdminDevDashboardControlPortal.Text =
                $"👤 Welcome, {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fullName.ToLower())}  |  Role: {Role}";


            // Role-Based UI Adjustments
            if (Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                this.ButtonProfile.Visible= false;

            }
            else
            {
                buttonDevlopers.Visible = false;
                ButtonUsersInfo.Visible = false;
                buttonTransactions.Visible = false;


            }
        }


        public FormControlPortal()
        {
            InitializeComponent();
            ResetAllButtons();

        }


        private void ResetAllButtons()
        {
            foreach (Control ctrl in panelSlidebar.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.LightGray;
                    btn.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Regular);
                    btn.FlatAppearance.BorderSize = 0;

                    //btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 100, 110);
                    //btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 150, 160);
                    btn.FlatAppearance.MouseOverBackColor = Color.Brown;
                    btn.FlatAppearance.MouseDownBackColor = Color.Brown;
                }
            }
            buttonLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 0, 0);
            buttonLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 0, 0);
            buttonLogout.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
            buttonLogout.BackColor = Color.Transparent;
            buttonLogout.ForeColor = Color.White;
        }

        private void ActivateButton(Button clickedButton)
        {
            ResetAllButtons();
            //clickedButton.BackColor = Color.FromArgb(0, 120, 215);
            clickedButton.BackColor = Color.FromArgb(0, 180, 190);

            clickedButton.ForeColor = Color.White;
            clickedButton.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);

            //clickedButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 120, 215);
            //clickedButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 215);
            clickedButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 180, 190);
            clickedButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 180, 190);
        }



        private void ButtonUsersInfoControlPortal_Click(object sender, EventArgs e)
        {
            ActivateButton(ButtonUsersInfo);
            UserManageControlPanel1.LoadUsers();
            UserManageControlPanel1.BringToFront();
            
        }

        private void FormControlPanel_Load(object sender, EventArgs e)
        {
            ActivateButton(buttonDashboardControlPortal);
        }

        private void buttonDashboardControlPortal_Click(object sender, EventArgs e)
        {
            ActivateButton(buttonDashboardControlPortal);
        }


        //Logout Button Method
        private void buttonLogout_Click(object sender, EventArgs e)
        {


            isLogoutClicked = true;

            if (this.Owner != null && this.Owner is FormLogin loginForm)
            {
                loginForm.Show();
                loginForm.TextBoxUserNameLogin.Focus();
            }
            else
            {
                loginForm = new FormLogin();
                loginForm.Show();
                loginForm.TextBoxUserNameLogin.Focus();
            }

            this.Close();
        }

        //FormClosing Method
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isLogoutClicked || isCloseConfirmed)
            {
                base.OnFormClosing(e);
                return;
            }

            DialogResult result = MessageBox.Show(
             "Are you sure you want to exit?",
             "Exit Application",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question,
             MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            isCloseConfirmed = true;
            Application.Exit();

            return;
        }

        private void buttonOurProjectsControlPortal_Click(object sender, EventArgs e)
        {
            ActivateButton(buttonOurProjectsControlPortal);
            userControlOurProjects.LoadOurProjects();
            userControlOurProjects.BringToFront();
        }

        private void buttonProjectBoardControlPortal_Click(object sender, EventArgs e)
        {
            ActivateButton(buttonProjectBoardControlPortal);
            userControlProjectBoard.LoadRequests();
            userControlProjectBoard.BringToFront();
        }

        private void buttonOurResponsesControlPortal_Click(object sender, EventArgs e)
        {
            ActivateButton(buttonOurResponsesControlPortal);
            userControlOurResponses.LoadOurResponses();
            userControlOurResponses.BringToFront();
        }

    }
}
