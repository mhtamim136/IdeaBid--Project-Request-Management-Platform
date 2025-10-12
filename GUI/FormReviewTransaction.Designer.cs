namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    partial class FormReviewTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReviewTransaction));
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxAction = new System.Windows.Forms.ComboBox();
            this.labelPaymentMethod = new System.Windows.Forms.Label();
            this.labelAmountShow = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelTransactionIDShow = new System.Windows.Forms.Label();
            this.labelTransactionID = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxPaymentMethod = new System.Windows.Forms.TextBox();
            this.labelAction = new System.Windows.Forms.Label();
            this.labelRemarks = new System.Windows.Forms.Label();
            this.metroTextBoxRemarks = new MetroFramework.Controls.MetroTextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Teal;
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(30, 593);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(252, 62);
            this.buttonSave.TabIndex = 18;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxAction
            // 
            this.comboBoxAction.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAction.FormattingEnabled = true;
            this.comboBoxAction.Items.AddRange(new object[] {
            "Confirm",
            "Reject"});
            this.comboBoxAction.Location = new System.Drawing.Point(30, 365);
            this.comboBoxAction.Name = "comboBoxAction";
            this.comboBoxAction.Size = new System.Drawing.Size(541, 38);
            this.comboBoxAction.TabIndex = 17;
            // 
            // labelPaymentMethod
            // 
            this.labelPaymentMethod.AutoSize = true;
            this.labelPaymentMethod.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaymentMethod.Location = new System.Drawing.Point(30, 202);
            this.labelPaymentMethod.Name = "labelPaymentMethod";
            this.labelPaymentMethod.Size = new System.Drawing.Size(197, 31);
            this.labelPaymentMethod.TabIndex = 16;
            this.labelPaymentMethod.Text = "Payment Method:";
            // 
            // labelAmountShow
            // 
            this.labelAmountShow.AutoSize = true;
            this.labelAmountShow.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmountShow.Location = new System.Drawing.Point(142, 151);
            this.labelAmountShow.Name = "labelAmountShow";
            this.labelAmountShow.Size = new System.Drawing.Size(157, 31);
            this.labelAmountShow.TabIndex = 15;
            this.labelAmountShow.Text = "Amount Show";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmount.Location = new System.Drawing.Point(30, 150);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(103, 31);
            this.labelAmount.TabIndex = 14;
            this.labelAmount.Text = "Amount:";
            // 
            // labelTransactionIDShow
            // 
            this.labelTransactionIDShow.AutoSize = true;
            this.labelTransactionIDShow.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransactionIDShow.Location = new System.Drawing.Point(203, 100);
            this.labelTransactionIDShow.Name = "labelTransactionIDShow";
            this.labelTransactionIDShow.Size = new System.Drawing.Size(219, 31);
            this.labelTransactionIDShow.TabIndex = 13;
            this.labelTransactionIDShow.Text = "Transaction ID Show";
            // 
            // labelTransactionID
            // 
            this.labelTransactionID.AutoSize = true;
            this.labelTransactionID.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTransactionID.Location = new System.Drawing.Point(30, 98);
            this.labelTransactionID.Name = "labelTransactionID";
            this.labelTransactionID.Size = new System.Drawing.Size(169, 31);
            this.labelTransactionID.TabIndex = 12;
            this.labelTransactionID.Text = "Transaction ID:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(105, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(383, 41);
            this.labelTitle.TabIndex = 11;
            this.labelTitle.Text = "Manage Payment Action";
            // 
            // textBoxPaymentMethod
            // 
            this.textBoxPaymentMethod.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPaymentMethod.Location = new System.Drawing.Point(30, 254);
            this.textBoxPaymentMethod.Name = "textBoxPaymentMethod";
            this.textBoxPaymentMethod.ReadOnly = true;
            this.textBoxPaymentMethod.Size = new System.Drawing.Size(541, 38);
            this.textBoxPaymentMethod.TabIndex = 22;
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAction.Location = new System.Drawing.Point(30, 313);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(87, 31);
            this.labelAction.TabIndex = 23;
            this.labelAction.Text = "Action:";
            // 
            // labelRemarks
            // 
            this.labelRemarks.AutoSize = true;
            this.labelRemarks.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemarks.Location = new System.Drawing.Point(30, 424);
            this.labelRemarks.Name = "labelRemarks";
            this.labelRemarks.Size = new System.Drawing.Size(108, 31);
            this.labelRemarks.TabIndex = 24;
            this.labelRemarks.Text = "Remarks:";
            // 
            // metroTextBoxRemarks
            // 
            // 
            // 
            // 
            this.metroTextBoxRemarks.CustomButton.Image = null;
            this.metroTextBoxRemarks.CustomButton.Location = new System.Drawing.Point(473, 2);
            this.metroTextBoxRemarks.CustomButton.Name = "";
            this.metroTextBoxRemarks.CustomButton.Size = new System.Drawing.Size(65, 65);
            this.metroTextBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxRemarks.CustomButton.TabIndex = 1;
            this.metroTextBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxRemarks.CustomButton.UseSelectable = true;
            this.metroTextBoxRemarks.CustomButton.Visible = false;
            this.metroTextBoxRemarks.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.metroTextBoxRemarks.Lines = new string[0];
            this.metroTextBoxRemarks.Location = new System.Drawing.Point(30, 472);
            this.metroTextBoxRemarks.MaxLength = 32767;
            this.metroTextBoxRemarks.Multiline = true;
            this.metroTextBoxRemarks.Name = "metroTextBoxRemarks";
            this.metroTextBoxRemarks.PasswordChar = '\0';
            this.metroTextBoxRemarks.WaterMark = "If Rejected, require Remarks.";
            this.metroTextBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxRemarks.SelectedText = "";
            this.metroTextBoxRemarks.SelectionLength = 0;
            this.metroTextBoxRemarks.SelectionStart = 0;
            this.metroTextBoxRemarks.ShortcutsEnabled = true;
            this.metroTextBoxRemarks.ShowClearButton = true;
            this.metroTextBoxRemarks.Size = new System.Drawing.Size(541, 70);
            this.metroTextBoxRemarks.TabIndex = 25;
            this.metroTextBoxRemarks.UseSelectable = true;
            this.metroTextBoxRemarks.WaterMark = "If Rejected, require Remarks.";
            this.metroTextBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Red;
            this.buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Transparent;
            this.buttonCancel.Location = new System.Drawing.Point(317, 593);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(252, 62);
            this.buttonCancel.TabIndex = 26;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormReviewTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(604, 674);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.metroTextBoxRemarks);
            this.Controls.Add(this.labelRemarks);
            this.Controls.Add(this.labelAction);
            this.Controls.Add(this.textBoxPaymentMethod);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxAction);
            this.Controls.Add(this.labelPaymentMethod);
            this.Controls.Add(this.labelAmountShow);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelTransactionIDShow);
            this.Controls.Add(this.labelTransactionID);
            this.Controls.Add(this.labelTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormReviewTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReviewTransaction";
            this.Load += new System.EventHandler(this.FormReviewTransaction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxAction;
        private System.Windows.Forms.Label labelPaymentMethod;
        private System.Windows.Forms.Label labelAmountShow;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelTransactionIDShow;
        private System.Windows.Forms.Label labelTransactionID;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxPaymentMethod;
        private System.Windows.Forms.Label labelAction;
        private System.Windows.Forms.Label labelRemarks;
        private MetroFramework.Controls.MetroTextBox metroTextBoxRemarks;
        private System.Windows.Forms.Button buttonCancel;
    }
}