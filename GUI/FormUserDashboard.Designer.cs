namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    partial class FormUserDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserDashboard));
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.tableLayoutPanelControlPortal = new System.Windows.Forms.TableLayoutPanel();
            this.panelTopLabel = new System.Windows.Forms.Panel();
            this.labelUserDashboard = new System.Windows.Forms.Label();
            this.panelSlidebar = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.ButtonProfile = new System.Windows.Forms.Button();
            this.buttonPayment = new System.Windows.Forms.Button();
            this.buttonPublicProjeect = new System.Windows.Forms.Button();
            this.buttonProjectRequest = new System.Windows.Forms.Button();
            this.buttonDashboard = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTitleControlPortal = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.userControlUserDashBoard = new IdeaBid__Project_Request___Management_Platform.GUI.UserControlUserDashBoard();
            this.userControlPayment = new IdeaBid__Project_Request___Management_Platform.GUI.UserControlPayment();
            this.userControlUserProfile = new IdeaBid__Project_Request___Management_Platform.GUI.UserControlUserProfile();
            this.userControlPublicProjects = new IdeaBid__Project_Request___Management_Platform.GUI.UserControlPublicProjects();
            this.userControlProjectRequestFormUser = new IdeaBid__Project_Request___Management_Platform.GUI.UserControlProjectRequestFromUser();
            this.userControlProjectRequestFromUser1 = new IdeaBid__Project_Request___Management_Platform.GUI.UserControlProjectRequestFromUser();
            this.panelDisplay.SuspendLayout();
            this.tableLayoutPanelControlPortal.SuspendLayout();
            this.panelTopLabel.SuspendLayout();
            this.panelSlidebar.SuspendLayout();
            this.panelTitleControlPortal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDisplay
            // 
            this.panelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDisplay.Controls.Add(this.userControlUserDashBoard);
            this.panelDisplay.Controls.Add(this.userControlPayment);
            this.panelDisplay.Controls.Add(this.userControlUserProfile);
            this.panelDisplay.Controls.Add(this.userControlPublicProjects);
            this.panelDisplay.Controls.Add(this.userControlProjectRequestFormUser);
            this.panelDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisplay.Location = new System.Drawing.Point(281, 105);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(1404, 665);
            this.panelDisplay.TabIndex = 3;
            // 
            // tableLayoutPanelControlPortal
            // 
            this.tableLayoutPanelControlPortal.ColumnCount = 2;
            this.tableLayoutPanelControlPortal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 278F));
            this.tableLayoutPanelControlPortal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelControlPortal.Controls.Add(this.panelTopLabel, 1, 0);
            this.tableLayoutPanelControlPortal.Controls.Add(this.panelDisplay, 1, 1);
            this.tableLayoutPanelControlPortal.Controls.Add(this.panelSlidebar, 0, 1);
            this.tableLayoutPanelControlPortal.Controls.Add(this.panelTitleControlPortal, 0, 0);
            this.tableLayoutPanelControlPortal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelControlPortal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelControlPortal.Name = "tableLayoutPanelControlPortal";
            this.tableLayoutPanelControlPortal.RowCount = 2;
            this.tableLayoutPanelControlPortal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanelControlPortal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelControlPortal.Size = new System.Drawing.Size(1688, 773);
            this.tableLayoutPanelControlPortal.TabIndex = 1;
            // 
            // panelTopLabel
            // 
            this.panelTopLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelTopLabel.Controls.Add(this.labelUserDashboard);
            this.panelTopLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopLabel.Location = new System.Drawing.Point(281, 3);
            this.panelTopLabel.Name = "panelTopLabel";
            this.panelTopLabel.Size = new System.Drawing.Size(1404, 96);
            this.panelTopLabel.TabIndex = 3;
            // 
            // labelUserDashboard
            // 
            this.labelUserDashboard.AutoSize = true;
            this.labelUserDashboard.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserDashboard.Location = new System.Drawing.Point(30, 26);
            this.labelUserDashboard.Name = "labelUserDashboard";
            this.labelUserDashboard.Size = new System.Drawing.Size(267, 45);
            this.labelUserDashboard.TabIndex = 1;
            this.labelUserDashboard.Text = "User Dashboard";
            // 
            // panelSlidebar
            // 
            this.panelSlidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(99)))), ((int)(((byte)(137)))));
            this.panelSlidebar.Controls.Add(this.buttonLogout);
            this.panelSlidebar.Controls.Add(this.ButtonProfile);
            this.panelSlidebar.Controls.Add(this.buttonPayment);
            this.panelSlidebar.Controls.Add(this.buttonPublicProjeect);
            this.panelSlidebar.Controls.Add(this.buttonProjectRequest);
            this.panelSlidebar.Controls.Add(this.buttonDashboard);
            this.panelSlidebar.Controls.Add(this.panel1);
            this.panelSlidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSlidebar.Location = new System.Drawing.Point(3, 105);
            this.panelSlidebar.Name = "panelSlidebar";
            this.panelSlidebar.Size = new System.Drawing.Size(272, 665);
            this.panelSlidebar.TabIndex = 2;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.ForeColor = System.Drawing.Color.White;
            this.buttonLogout.Location = new System.Drawing.Point(-3, 576);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(277, 65);
            this.buttonLogout.TabIndex = 2;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // ButtonProfile
            // 
            this.ButtonProfile.BackColor = System.Drawing.Color.Transparent;
            this.ButtonProfile.FlatAppearance.BorderSize = 0;
            this.ButtonProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.ButtonProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.ButtonProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonProfile.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonProfile.ForeColor = System.Drawing.Color.LightGray;
            this.ButtonProfile.Image = ((System.Drawing.Image)(resources.GetObject("ButtonProfile.Image")));
            this.ButtonProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonProfile.Location = new System.Drawing.Point(-1, 351);
            this.ButtonProfile.Name = "ButtonProfile";
            this.ButtonProfile.Size = new System.Drawing.Size(275, 59);
            this.ButtonProfile.TabIndex = 13;
            this.ButtonProfile.Text = "  Profile";
            this.ButtonProfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ButtonProfile.UseVisualStyleBackColor = false;
            this.ButtonProfile.Click += new System.EventHandler(this.ButtonProfile_Click);
            // 
            // buttonPayment
            // 
            this.buttonPayment.BackColor = System.Drawing.Color.Transparent;
            this.buttonPayment.FlatAppearance.BorderSize = 0;
            this.buttonPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.buttonPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.buttonPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPayment.ForeColor = System.Drawing.Color.LightGray;
            this.buttonPayment.Image = ((System.Drawing.Image)(resources.GetObject("buttonPayment.Image")));
            this.buttonPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPayment.Location = new System.Drawing.Point(2, 272);
            this.buttonPayment.Name = "buttonPayment";
            this.buttonPayment.Size = new System.Drawing.Size(268, 59);
            this.buttonPayment.TabIndex = 12;
            this.buttonPayment.Text = "  Payment";
            this.buttonPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPayment.UseVisualStyleBackColor = false;
            this.buttonPayment.Click += new System.EventHandler(this.buttonPayment_Click);
            // 
            // buttonPublicProjeect
            // 
            this.buttonPublicProjeect.BackColor = System.Drawing.Color.Transparent;
            this.buttonPublicProjeect.FlatAppearance.BorderSize = 0;
            this.buttonPublicProjeect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.buttonPublicProjeect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.buttonPublicProjeect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPublicProjeect.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPublicProjeect.ForeColor = System.Drawing.Color.LightGray;
            this.buttonPublicProjeect.Image = ((System.Drawing.Image)(resources.GetObject("buttonPublicProjeect.Image")));
            this.buttonPublicProjeect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPublicProjeect.Location = new System.Drawing.Point(1, 185);
            this.buttonPublicProjeect.Name = "buttonPublicProjeect";
            this.buttonPublicProjeect.Size = new System.Drawing.Size(273, 62);
            this.buttonPublicProjeect.TabIndex = 11;
            this.buttonPublicProjeect.Text = " Public Projects";
            this.buttonPublicProjeect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPublicProjeect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPublicProjeect.UseVisualStyleBackColor = false;
            this.buttonPublicProjeect.Click += new System.EventHandler(this.buttonPublicProjeect_Click);
            // 
            // buttonProjectRequest
            // 
            this.buttonProjectRequest.BackColor = System.Drawing.Color.Transparent;
            this.buttonProjectRequest.FlatAppearance.BorderSize = 0;
            this.buttonProjectRequest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.buttonProjectRequest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.buttonProjectRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProjectRequest.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProjectRequest.ForeColor = System.Drawing.Color.LightGray;
            this.buttonProjectRequest.Image = ((System.Drawing.Image)(resources.GetObject("buttonProjectRequest.Image")));
            this.buttonProjectRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonProjectRequest.Location = new System.Drawing.Point(-8, 111);
            this.buttonProjectRequest.Name = "buttonProjectRequest";
            this.buttonProjectRequest.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonProjectRequest.Size = new System.Drawing.Size(277, 59);
            this.buttonProjectRequest.TabIndex = 4;
            this.buttonProjectRequest.Text = "  Request Project";
            this.buttonProjectRequest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonProjectRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonProjectRequest.UseVisualStyleBackColor = false;
            this.buttonProjectRequest.Click += new System.EventHandler(this.buttonProjectRequest_Click);
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.BackColor = System.Drawing.Color.Transparent;
            this.buttonDashboard.FlatAppearance.BorderSize = 0;
            this.buttonDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.buttonDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.buttonDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDashboard.ForeColor = System.Drawing.Color.LightGray;
            this.buttonDashboard.Image = ((System.Drawing.Image)(resources.GetObject("buttonDashboard.Image")));
            this.buttonDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDashboard.Location = new System.Drawing.Point(-11, 32);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Size = new System.Drawing.Size(285, 59);
            this.buttonDashboard.TabIndex = 3;
            this.buttonDashboard.Text = "Dashboard";
            this.buttonDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDashboard.UseVisualStyleBackColor = false;
            this.buttonDashboard.Click += new System.EventHandler(this.buttonDashboard_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(305, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 103);
            this.panel1.TabIndex = 1;
            // 
            // panelTitleControlPortal
            // 
            this.panelTitleControlPortal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(99)))), ((int)(((byte)(137)))));
            this.panelTitleControlPortal.Controls.Add(this.labelTitle);
            this.panelTitleControlPortal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitleControlPortal.Location = new System.Drawing.Point(3, 3);
            this.panelTitleControlPortal.Name = "panelTitleControlPortal";
            this.panelTitleControlPortal.Size = new System.Drawing.Size(272, 96);
            this.panelTitleControlPortal.TabIndex = 4;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Black", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(40, 14);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(184, 57);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "IdeaBid";
            // 
            // userControlUserDashBoard
            // 
            this.userControlUserDashBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlUserDashBoard.Location = new System.Drawing.Point(0, 0);
            this.userControlUserDashBoard.Name = "userControlUserDashBoard";
            this.userControlUserDashBoard.Size = new System.Drawing.Size(1400, 661);
            this.userControlUserDashBoard.TabIndex = 4;
            // 
            // userControlPayment
            // 
            this.userControlPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlPayment.Location = new System.Drawing.Point(0, 0);
            this.userControlPayment.Name = "userControlPayment";
            this.userControlPayment.Size = new System.Drawing.Size(1400, 661);
            this.userControlPayment.TabIndex = 3;
            // 
            // userControlUserProfile
            // 
            this.userControlUserProfile.CurrentUserId = 0;
            this.userControlUserProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlUserProfile.Location = new System.Drawing.Point(0, 0);
            this.userControlUserProfile.Name = "userControlUserProfile";
            this.userControlUserProfile.Size = new System.Drawing.Size(1400, 661);
            this.userControlUserProfile.TabIndex = 2;
            // 
            // userControlPublicProjects
            // 
            this.userControlPublicProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlPublicProjects.Location = new System.Drawing.Point(0, 0);
            this.userControlPublicProjects.Name = "userControlPublicProjects";
            this.userControlPublicProjects.Size = new System.Drawing.Size(1400, 661);
            this.userControlPublicProjects.TabIndex = 1;
            // 
            // userControlProjectRequestFormUser
            // 
            this.userControlProjectRequestFormUser.BackColor = System.Drawing.Color.Red;
            this.userControlProjectRequestFormUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlProjectRequestFormUser.Location = new System.Drawing.Point(0, 0);
            this.userControlProjectRequestFormUser.Name = "userControlProjectRequestFormUser";
            this.userControlProjectRequestFormUser.Size = new System.Drawing.Size(1400, 661);
            this.userControlProjectRequestFormUser.TabIndex = 0;
            // 
            // userControlProjectRequestFromUser1
            // 
            this.userControlProjectRequestFromUser1.BackColor = System.Drawing.Color.Red;
            this.userControlProjectRequestFromUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlProjectRequestFromUser1.Location = new System.Drawing.Point(0, 0);
            this.userControlProjectRequestFromUser1.Name = "userControlProjectRequestFromUser1";
            this.userControlProjectRequestFromUser1.Size = new System.Drawing.Size(1486, 661);
            this.userControlProjectRequestFromUser1.TabIndex = 0;
            // 
            // FormUserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1688, 773);
            this.Controls.Add(this.tableLayoutPanelControlPortal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.FormUserDashboard_Load);
            this.panelDisplay.ResumeLayout(false);
            this.tableLayoutPanelControlPortal.ResumeLayout(false);
            this.panelTopLabel.ResumeLayout(false);
            this.panelTopLabel.PerformLayout();
            this.panelSlidebar.ResumeLayout(false);
            this.panelTitleControlPortal.ResumeLayout(false);
            this.panelTitleControlPortal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelControlPortal;
        private System.Windows.Forms.Panel panelTopLabel;
        private System.Windows.Forms.Label labelUserDashboard;
        private System.Windows.Forms.Panel panelSlidebar;
        private System.Windows.Forms.Button buttonProjectRequest;
        private System.Windows.Forms.Button buttonDashboard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelTitleControlPortal;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonPublicProjeect;
        private System.Windows.Forms.Button buttonPayment;
        private System.Windows.Forms.Button ButtonProfile;
        private System.Windows.Forms.Button buttonLogout;
        private UserControlProjectRequestFromUser userControlProjectRequestFromUser1;
        private UserControlProjectRequestFromUser userControlProjectRequestFormUser;
        private UserControlPublicProjects userControlPublicProjects;
        private UserControlUserProfile userControlUserProfile;
        private UserControlPayment userControlPayment;
        private UserControlUserDashBoard userControlUserDashBoard;
    }
}