namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    partial class FormMakePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMakePayment));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPaymentID = new System.Windows.Forms.Label();
            this.labelPaymentIDShow = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelAmountShow = new System.Windows.Forms.Label();
            this.labelPaymentMethod = new System.Windows.Forms.Label();
            this.comboBoxPayment = new System.Windows.Forms.ComboBox();
            this.buttonPayment = new System.Windows.Forms.Button();
            this.labelWarining = new System.Windows.Forms.Label();
            this.labelWarning = new System.Windows.Forms.Label();
            this.labelAlreadyPaid = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(126, 25);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(270, 41);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Process Payment";
            // 
            // labelPaymentID
            // 
            this.labelPaymentID.AutoSize = true;
            this.labelPaymentID.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaymentID.Location = new System.Drawing.Point(104, 104);
            this.labelPaymentID.Name = "labelPaymentID";
            this.labelPaymentID.Size = new System.Drawing.Size(139, 31);
            this.labelPaymentID.TabIndex = 1;
            this.labelPaymentID.Text = "Payment ID:";
            // 
            // labelPaymentIDShow
            // 
            this.labelPaymentIDShow.AutoSize = true;
            this.labelPaymentIDShow.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaymentIDShow.Location = new System.Drawing.Point(250, 105);
            this.labelPaymentIDShow.Name = "labelPaymentIDShow";
            this.labelPaymentIDShow.Size = new System.Drawing.Size(191, 31);
            this.labelPaymentIDShow.TabIndex = 2;
            this.labelPaymentIDShow.Text = "Payment ID Show";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmount.Location = new System.Drawing.Point(104, 159);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(103, 31);
            this.labelAmount.TabIndex = 3;
            this.labelAmount.Text = "Amount:";
            // 
            // labelAmountShow
            // 
            this.labelAmountShow.AutoSize = true;
            this.labelAmountShow.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmountShow.Location = new System.Drawing.Point(104, 214);
            this.labelAmountShow.Name = "labelAmountShow";
            this.labelAmountShow.Size = new System.Drawing.Size(157, 31);
            this.labelAmountShow.TabIndex = 4;
            this.labelAmountShow.Text = "Amount Show";
            // 
            // labelPaymentMethod
            // 
            this.labelPaymentMethod.AutoSize = true;
            this.labelPaymentMethod.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaymentMethod.Location = new System.Drawing.Point(104, 269);
            this.labelPaymentMethod.Name = "labelPaymentMethod";
            this.labelPaymentMethod.Size = new System.Drawing.Size(197, 31);
            this.labelPaymentMethod.TabIndex = 5;
            this.labelPaymentMethod.Text = "Payment Method:";
            // 
            // comboBoxPayment
            // 
            this.comboBoxPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPayment.FormattingEnabled = true;
            this.comboBoxPayment.Location = new System.Drawing.Point(104, 324);
            this.comboBoxPayment.Name = "comboBoxPayment";
            this.comboBoxPayment.Size = new System.Drawing.Size(331, 38);
            this.comboBoxPayment.TabIndex = 6;
            // 
            // buttonPayment
            // 
            this.buttonPayment.BackColor = System.Drawing.Color.Teal;
            this.buttonPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.buttonPayment.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPayment.ForeColor = System.Drawing.Color.White;
            this.buttonPayment.Location = new System.Drawing.Point(104, 402);
            this.buttonPayment.Name = "buttonPayment";
            this.buttonPayment.Size = new System.Drawing.Size(331, 62);
            this.buttonPayment.TabIndex = 7;
            this.buttonPayment.Text = "Pay Now";
            this.buttonPayment.UseVisualStyleBackColor = false;
            this.buttonPayment.Click += new System.EventHandler(this.buttonPayment_Click);
            // 
            // labelWarining
            // 
            this.labelWarining.AutoSize = true;
            this.labelWarining.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarining.Location = new System.Drawing.Point(181, 538);
            this.labelWarining.Name = "labelWarining";
            this.labelWarining.Size = new System.Drawing.Size(0, 31);
            this.labelWarining.TabIndex = 8;
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.Location = new System.Drawing.Point(54, 527);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(400, 25);
            this.labelWarning.TabIndex = 9;
            this.labelWarning.Text = " Once payment is made, it cannot be undone.";
            this.labelWarning.Visible = false;
            // 
            // labelAlreadyPaid
            // 
            this.labelAlreadyPaid.AutoSize = true;
            this.labelAlreadyPaid.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlreadyPaid.Location = new System.Drawing.Point(193, 526);
            this.labelAlreadyPaid.Name = "labelAlreadyPaid";
            this.labelAlreadyPaid.Size = new System.Drawing.Size(146, 25);
            this.labelAlreadyPaid.TabIndex = 10;
            this.labelAlreadyPaid.Text = "✅ Already Paid";
            this.labelAlreadyPaid.Visible = false;
            // 
            // FormMakePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(536, 590);
            this.Controls.Add(this.labelAlreadyPaid);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.labelWarining);
            this.Controls.Add(this.buttonPayment);
            this.Controls.Add(this.comboBoxPayment);
            this.Controls.Add(this.labelPaymentMethod);
            this.Controls.Add(this.labelAmountShow);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelPaymentIDShow);
            this.Controls.Add(this.labelPaymentID);
            this.Controls.Add(this.labelTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMakePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.FormMakePayment_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPaymentID;
        private System.Windows.Forms.Label labelPaymentIDShow;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelAmountShow;
        private System.Windows.Forms.Label labelPaymentMethod;
        private System.Windows.Forms.ComboBox comboBoxPayment;
        private System.Windows.Forms.Button buttonPayment;
        private System.Windows.Forms.Label labelWarining;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Label labelAlreadyPaid;
    }
}