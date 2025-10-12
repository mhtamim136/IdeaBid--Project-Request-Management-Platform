namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    partial class UserControlTransaction
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanelTransaction = new System.Windows.Forms.TableLayoutPanel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonReview = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.metroGridDisplay = new MetroFramework.Controls.MetroGrid();
            this.dgvTransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPayerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConfirmBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConfirmationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanelTransaction.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelTransaction
            // 
            this.tableLayoutPanelTransaction.ColumnCount = 1;
            this.tableLayoutPanelTransaction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTransaction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTransaction.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanelTransaction.Controls.Add(this.panelDisplay, 0, 1);
            this.tableLayoutPanelTransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTransaction.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelTransaction.Name = "tableLayoutPanelTransaction";
            this.tableLayoutPanelTransaction.RowCount = 2;
            this.tableLayoutPanelTransaction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanelTransaction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTransaction.Size = new System.Drawing.Size(1167, 688);
            this.tableLayoutPanelTransaction.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(99)))), ((int)(((byte)(137)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.buttonReview);
            this.panelTop.Controls.Add(this.textBoxSearch);
            this.panelTop.Controls.Add(this.buttonSearch);
            this.panelTop.Controls.Add(this.buttonRefresh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1161, 61);
            this.panelTop.TabIndex = 1;
            // 
            // buttonReview
            // 
            this.buttonReview.BackColor = System.Drawing.Color.Teal;
            this.buttonReview.FlatAppearance.BorderSize = 0;
            this.buttonReview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonReview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.buttonReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReview.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReview.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonReview.Location = new System.Drawing.Point(217, 7);
            this.buttonReview.Name = "buttonReview";
            this.buttonReview.Size = new System.Drawing.Size(175, 47);
            this.buttonReview.TabIndex = 7;
            this.buttonReview.Text = "Review";
            this.buttonReview.UseVisualStyleBackColor = false;
            this.buttonReview.Click += new System.EventHandler(this.buttonReview_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(754, 11);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(460, 41);
            this.textBoxSearch.TabIndex = 6;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearch_KeyDown);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.Transparent;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.ForeColor = System.Drawing.Color.White;
            this.buttonSearch.Location = new System.Drawing.Point(614, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(127, 53);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Teal;
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonRefresh.Location = new System.Drawing.Point(3, 6);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(166, 47);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // panelDisplay
            // 
            this.panelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDisplay.Controls.Add(this.metroGridDisplay);
            this.panelDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisplay.Location = new System.Drawing.Point(3, 70);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(1161, 615);
            this.panelDisplay.TabIndex = 2;
            // 
            // metroGridDisplay
            // 
            this.metroGridDisplay.AllowUserToAddRows = false;
            this.metroGridDisplay.AllowUserToDeleteRows = false;
            this.metroGridDisplay.AllowUserToResizeRows = false;
            this.metroGridDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.metroGridDisplay.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGridDisplay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGridDisplay.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGridDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGridDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTransactionID,
            this.dgvRequestID,
            this.dgvPayerID,
            this.dgvAmount,
            this.dgvPaymentMethod,
            this.dgvPaymentDate,
            this.dgvPaymentStatus,
            this.dgvConfirmBy,
            this.dgvConfirmationDate,
            this.dgvRemarks});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGridDisplay.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGridDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGridDisplay.EnableHeadersVisualStyles = false;
            this.metroGridDisplay.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGridDisplay.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridDisplay.Location = new System.Drawing.Point(0, 0);
            this.metroGridDisplay.Name = "metroGridDisplay";
            this.metroGridDisplay.ReadOnly = true;
            this.metroGridDisplay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridDisplay.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGridDisplay.RowHeadersWidth = 51;
            this.metroGridDisplay.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGridDisplay.RowTemplate.Height = 24;
            this.metroGridDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGridDisplay.Size = new System.Drawing.Size(1159, 613);
            this.metroGridDisplay.TabIndex = 0;
            this.metroGridDisplay.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.metroGridDisplay_DataBindingComplete);
            // 
            // dgvTransactionID
            // 
            this.dgvTransactionID.DataPropertyName = "TransactionID";
            this.dgvTransactionID.HeaderText = "Transaction ID";
            this.dgvTransactionID.MinimumWidth = 6;
            this.dgvTransactionID.Name = "dgvTransactionID";
            this.dgvTransactionID.ReadOnly = true;
            // 
            // dgvRequestID
            // 
            this.dgvRequestID.DataPropertyName = "RequestID";
            this.dgvRequestID.HeaderText = "Request ID";
            this.dgvRequestID.MinimumWidth = 6;
            this.dgvRequestID.Name = "dgvRequestID";
            this.dgvRequestID.ReadOnly = true;
            // 
            // dgvPayerID
            // 
            this.dgvPayerID.DataPropertyName = "PayerID";
            this.dgvPayerID.HeaderText = "Payer ID";
            this.dgvPayerID.MinimumWidth = 6;
            this.dgvPayerID.Name = "dgvPayerID";
            this.dgvPayerID.ReadOnly = true;
            // 
            // dgvAmount
            // 
            this.dgvAmount.DataPropertyName = "Amount";
            this.dgvAmount.HeaderText = "Amount";
            this.dgvAmount.MinimumWidth = 6;
            this.dgvAmount.Name = "dgvAmount";
            this.dgvAmount.ReadOnly = true;
            // 
            // dgvPaymentMethod
            // 
            this.dgvPaymentMethod.DataPropertyName = "PaymentMethod";
            this.dgvPaymentMethod.FillWeight = 110F;
            this.dgvPaymentMethod.HeaderText = "Payment Method";
            this.dgvPaymentMethod.MinimumWidth = 6;
            this.dgvPaymentMethod.Name = "dgvPaymentMethod";
            this.dgvPaymentMethod.ReadOnly = true;
            // 
            // dgvPaymentDate
            // 
            this.dgvPaymentDate.DataPropertyName = "PaymentDate";
            this.dgvPaymentDate.HeaderText = "Payment Date";
            this.dgvPaymentDate.MinimumWidth = 6;
            this.dgvPaymentDate.Name = "dgvPaymentDate";
            this.dgvPaymentDate.ReadOnly = true;
            // 
            // dgvPaymentStatus
            // 
            this.dgvPaymentStatus.DataPropertyName = "PaymentStatus";
            this.dgvPaymentStatus.FillWeight = 110F;
            this.dgvPaymentStatus.HeaderText = "Payment Status";
            this.dgvPaymentStatus.MinimumWidth = 6;
            this.dgvPaymentStatus.Name = "dgvPaymentStatus";
            this.dgvPaymentStatus.ReadOnly = true;
            // 
            // dgvConfirmBy
            // 
            this.dgvConfirmBy.DataPropertyName = "ConfirmedBy";
            this.dgvConfirmBy.HeaderText = "Confirmed By";
            this.dgvConfirmBy.MinimumWidth = 6;
            this.dgvConfirmBy.Name = "dgvConfirmBy";
            this.dgvConfirmBy.ReadOnly = true;
            // 
            // dgvConfirmationDate
            // 
            this.dgvConfirmationDate.DataPropertyName = "ConfirmationDate";
            this.dgvConfirmationDate.FillWeight = 110F;
            this.dgvConfirmationDate.HeaderText = "Confirmation Date";
            this.dgvConfirmationDate.MinimumWidth = 6;
            this.dgvConfirmationDate.Name = "dgvConfirmationDate";
            this.dgvConfirmationDate.ReadOnly = true;
            // 
            // dgvRemarks
            // 
            this.dgvRemarks.DataPropertyName = "Remarks";
            this.dgvRemarks.FillWeight = 110F;
            this.dgvRemarks.HeaderText = "Remarks";
            this.dgvRemarks.MinimumWidth = 6;
            this.dgvRemarks.Name = "dgvRemarks";
            this.dgvRemarks.ReadOnly = true;
            // 
            // UserControlTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelTransaction);
            this.Name = "UserControlTransaction";
            this.Size = new System.Drawing.Size(1167, 688);
            this.Load += new System.EventHandler(this.UserControlTransaction_Load);
            this.tableLayoutPanelTransaction.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGridDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTransaction;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonReview;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Panel panelDisplay;
        private MetroFramework.Controls.MetroGrid metroGridDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTransactionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPayerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConfirmBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvConfirmationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRemarks;
    }
}
