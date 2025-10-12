using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    public partial class UserControlTransaction : UserControl
    {
        public UserControlTransaction()
        {
            InitializeComponent();
        }

        private void LoadTransactions(string search = null)
        {
            try
            {

                string query = @"
                                SELECT 
                                    pt.TransactionID,
                                    pt.RequestID,
                                    pr.UserID AS PayerID,
                                    pt.Amount,
                                    pt.PaymentMethod,
                                    pt.PaymentDate,
                                    pt.PaymentStatus,
                                    a.AdminUsername AS ConfirmedBy,
                                    pt.ConfirmationDate,
                                    pt.Remarks
                                FROM PaymentTransaction pt
                                INNER JOIN ProjectRequest pr ON pt.RequestID = pr.RequestID
                                LEFT JOIN AdminInfo a ON pt.ConfirmedBy = a.AdminID
                                WHERE pt.PaymentStatus <> 'Pending'";


                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.Trim().Replace("'", "''");

                    if (int.TryParse(search, out int id))
                    {
                        query += $" AND (pt.TransactionID = {id} OR pt.RequestID = {id})";
                    }
                    else
                    {
                        query += $@"
                    AND (
                        pt.PaymentMethod LIKE '%{search}%' 
                        OR pt.PaymentStatus LIKE '%{search}%' 
                        OR CONVERT(NVARCHAR(50), pt.PaymentDate, 120) LIKE '%{search}%'
                    )";
                    }
                }

                query += " ORDER BY pt.TransactionID DESC";

                DataTable dt = DataBase.GetDataTable(query);
                metroGridDisplay.AutoGenerateColumns = false;
                metroGridDisplay.DataSource = dt;
                metroGridDisplay.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions:\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            textBoxSearch.Clear();
            LoadTransactions();

        }

        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LoadTransactions(textBoxSearch.Text.Trim());
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadTransactions(textBoxSearch.Text.Trim());
        }

        private void UserControlTransaction_Load(object sender, EventArgs e)
        {
            LoadTransactions();

        }

        private void buttonReview_Click(object sender, EventArgs e)
        {
            if (metroGridDisplay.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int transactionId = Convert.ToInt32(
                    metroGridDisplay.SelectedRows[0].Cells["dgvTransactionID"].Value
                );

                using (FormReviewTransaction form = new FormReviewTransaction(transactionId))
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        LoadTransactions(); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening review form:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void metroGridDisplay_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            metroGridDisplay.ClearSelection();
            metroGridDisplay.CurrentCell = null;
        }
    }
}
