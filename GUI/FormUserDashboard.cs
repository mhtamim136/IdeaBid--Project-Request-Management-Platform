﻿using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
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
    public partial class FormUserDashboard : Form
    {
        public string LoggedInUser { get; private set; }
        public static int CurrentUserId { get; private set; }

        private bool isLogoutClicked = false;
        private bool isCloseConfirmed = false;


        public FormUserDashboard()
        {
            //InitializeComponent();
        }

        public FormUserDashboard(string username) : this()
        {
            InitializeComponent();
            LoggedInUser = username;
            object userIdResult = DataBase.ExecuteScalar(
                "SELECT TOP 1 ID FROM UserInfo WHERE UserName = @u",
                DataBase.CreateParameters(("@u", username))
            );

            if (userIdResult == null || userIdResult == DBNull.Value)
            {
                MessageBox.Show("User not found in database. Please contact administrator.", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            CurrentUserId = Convert.ToInt32(userIdResult);

            //Welcome Message
            string fullName = DataBase.ExecuteScalar(
                "SELECT FullName FROM UserInfo WHERE ID = @id",
                DataBase.CreateParameters(("@id", CurrentUserId))
            )?.ToString();

            //labelUserDashboard.Text = $"Welcome, {fullName}!";
            labelUserDashboard.Text =
                  $"👤 Welcome, {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(fullName.ToLower())}!";

            ResetAllButtons();
        }


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

        private void FormUserDashboard_Load(object sender, EventArgs e)
        {

            userControlProjectRequestFormUser.LoadRequests(CurrentUserId);

            userControlProjectRequestFormUser.BringToFront();


        }

        private void ButtonProfile_Click(object sender, EventArgs e)
        {
            ActivateButton(ButtonProfile);
            userControlUserProfile.LoadUserInfo(CurrentUserId);
            userControlUserProfile.BringToFront();
            

        }

        private void buttonProjectRequest_Click(object sender, EventArgs e)
        {
            ActivateButton(buttonProjectRequest);
            userControlProjectRequestFormUser.LoadRequests(CurrentUserId);

            userControlProjectRequestFormUser.BringToFront();

        }

        private void userControlProjectRequestFormUser_Load(object sender, EventArgs e)
        {

        }

        private void buttonPublicProjeect_Click(object sender, EventArgs e)
        {
            ActivateButton(buttonPublicProjeect);
            userControlPublicProjects.LoadOurProjects();
            userControlPublicProjects.BringToFront();
        }
    }
}
