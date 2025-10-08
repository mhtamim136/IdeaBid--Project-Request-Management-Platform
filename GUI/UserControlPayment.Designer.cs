namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    partial class UserControlPayment
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
            this.tableLayoutPanelPayment = new System.Windows.Forms.TableLayoutPanel();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.metroGridPayment = new MetroFramework.Controls.MetroGrid();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonMakePayment = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.dgvTransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRequestID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanelPayment.SuspendLayout();
            this.panelDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridPayment)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelPayment
            // 
            this.tableLayoutPanelPayment.ColumnCount = 1;
            this.tableLayoutPanelPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPayment.Controls.Add(this.panelDisplay, 0, 1);
            this.tableLayoutPanelPayment.Controls.Add(this.panelTop, 0, 0);
            this.tableLayoutPanelPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPayment.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPayment.Name = "tableLayoutPanelPayment";
            this.tableLayoutPanelPayment.RowCount = 2;
            this.tableLayoutPanelPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanelPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPayment.Size = new System.Drawing.Size(1180, 673);
            this.tableLayoutPanelPayment.TabIndex = 0;
            // 
            // panelDisplay
            // 
            this.panelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDisplay.Controls.Add(this.metroGridPayment);
            this.panelDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisplay.Location = new System.Drawing.Point(3, 70);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(1174, 600);
            this.panelDisplay.TabIndex = 1;
            // 
            // metroGridPayment
            // 
            this.metroGridPayment.AllowUserToAddRows = false;
            this.metroGridPayment.AllowUserToDeleteRows = false;
            this.metroGridPayment.AllowUserToResizeRows = false;
            this.metroGridPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.metroGridPayment.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridPayment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGridPayment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGridPayment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridPayment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGridPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGridPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTransactionID,
            this.dgvRequestID,
            this.dgvAmount,
            this.dgvPaymentMethod,
            this.dgvPaymentStatus,
            this.dgvRemarks,
            this.dgvPaymentDate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGridPayment.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGridPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGridPayment.EnableHeadersVisualStyles = false;
            this.metroGridPayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGridPayment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridPayment.Location = new System.Drawing.Point(0, 0);
            this.metroGridPayment.Name = "metroGridPayment";
            this.metroGridPayment.ReadOnly = true;
            this.metroGridPayment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridPayment.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGridPayment.RowHeadersWidth = 51;
            this.metroGridPayment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGridPayment.RowTemplate.Height = 24;
            this.metroGridPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGridPayment.Size = new System.Drawing.Size(1172, 598);
            this.metroGridPayment.TabIndex = 0;
            this.metroGridPayment.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.metroGridPayment_DataBindingComplete);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(99)))), ((int)(((byte)(137)))));
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.buttonMakePayment);
            this.panelTop.Controls.Add(this.textBoxSearch);
            this.panelTop.Controls.Add(this.buttonSearch);
            this.panelTop.Controls.Add(this.buttonRefresh);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(3, 3);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1174, 61);
            this.panelTop.TabIndex = 0;
            // 
            // buttonMakePayment
            // 
            this.buttonMakePayment.BackColor = System.Drawing.Color.Teal;
            this.buttonMakePayment.FlatAppearance.BorderSize = 0;
            this.buttonMakePayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.buttonMakePayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.buttonMakePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakePayment.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMakePayment.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonMakePayment.Location = new System.Drawing.Point(200, 6);
            this.buttonMakePayment.Name = "buttonMakePayment";
            this.buttonMakePayment.Size = new System.Drawing.Size(230, 47);
            this.buttonMakePayment.TabIndex = 7;
            this.buttonMakePayment.Text = "Make Payment";
            this.buttonMakePayment.UseVisualStyleBackColor = false;
            this.buttonMakePayment.Click += new System.EventHandler(this.buttonMakePayment_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.Location = new System.Drawing.Point(754, 11);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(460, 41);
            this.textBoxSearch.TabIndex = 6;
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
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
            this.buttonSearch.Location = new System.Drawing.Point(614, 3);
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
            this.buttonRefresh.Location = new System.Drawing.Point(17, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(136, 50);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // dgvTransactionID
            // 
            this.dgvTransactionID.DataPropertyName = "TransactionID";
            this.dgvTransactionID.HeaderText = " Payment ID";
            this.dgvTransactionID.MinimumWidth = 6;
            this.dgvTransactionID.Name = "dgvTransactionID";
            this.dgvTransactionID.ReadOnly = true;
            // 
            // dgvRequestID
            // 
            this.dgvRequestID.DataPropertyName = "RequestID";
            this.dgvRequestID.FillWeight = 115F;
            this.dgvRequestID.HeaderText = "Project Reference ID";
            this.dgvRequestID.MinimumWidth = 6;
            this.dgvRequestID.Name = "dgvRequestID";
            this.dgvRequestID.ReadOnly = true;
            // 
            // dgvAmount
            // 
            this.dgvAmount.DataPropertyName = "Amount";
            this.dgvAmount.FillWeight = 80F;
            this.dgvAmount.HeaderText = "Amount";
            this.dgvAmount.MinimumWidth = 6;
            this.dgvAmount.Name = "dgvAmount";
            this.dgvAmount.ReadOnly = true;
            // 
            // dgvPaymentMethod
            // 
            this.dgvPaymentMethod.DataPropertyName = "PaymentMethod";
            this.dgvPaymentMethod.HeaderText = "Payment Method";
            this.dgvPaymentMethod.MinimumWidth = 6;
            this.dgvPaymentMethod.Name = "dgvPaymentMethod";
            this.dgvPaymentMethod.ReadOnly = true;
            // 
            // dgvPaymentStatus
            // 
            this.dgvPaymentStatus.DataPropertyName = "PaymentStatus";
            this.dgvPaymentStatus.HeaderText = "Payment Status";
            this.dgvPaymentStatus.MinimumWidth = 6;
            this.dgvPaymentStatus.Name = "dgvPaymentStatus";
            this.dgvPaymentStatus.ReadOnly = true;
            // 
            // dgvRemarks
            // 
            this.dgvRemarks.DataPropertyName = "Remarks";
            this.dgvRemarks.HeaderText = "Remarks";
            this.dgvRemarks.MinimumWidth = 6;
            this.dgvRemarks.Name = "dgvRemarks";
            this.dgvRemarks.ReadOnly = true;
            // 
            // dgvPaymentDate
            // 
            this.dgvPaymentDate.DataPropertyName = "PaymentDate";
            this.dgvPaymentDate.HeaderText = "Payment Date";
            this.dgvPaymentDate.MinimumWidth = 6;
            this.dgvPaymentDate.Name = "dgvPaymentDate";
            this.dgvPaymentDate.ReadOnly = true;
            // 
            // UserControlPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelPayment);
            this.Name = "UserControlPayment";
            this.Size = new System.Drawing.Size(1180, 673);
            this.Load += new System.EventHandler(this.UserControlPayment_Load_1);
            this.tableLayoutPanelPayment.ResumeLayout(false);
            this.panelDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGridPayment)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPayment;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelDisplay;
        private MetroFramework.Controls.MetroGrid metroGridPayment;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonMakePayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTransactionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRequestID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentDate;
    }
}
