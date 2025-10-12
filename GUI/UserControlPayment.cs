using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    public partial class UserControlPayment : UserControl
    {
        int currentUserId;
        public UserControlPayment()
        {
            InitializeComponent();
        }

        private void LoadUserPayments(int userId, string search = null)
        {
            try
            {
                        string sql = $@"
                                        SELECT
                            pt.TransactionID,
                            pt.RequestID,
                            pt.Amount,
                            ISNULL(pm.PaymentName, 'Not Paid') AS PaymentMethod,
                            ISNULL(CONVERT(VARCHAR(20), pt.PaymentDate, 120), 'Not Paid') AS PaymentDate,
                            pt.PaymentStatus
                        FROM PaymentTransaction pt
                        INNER JOIN ProjectRequest pr ON pt.RequestID = pr.RequestID
                        LEFT JOIN PaymentMethod pm ON pt.PaymentMethod = pm.PaymentID
                        WHERE pr.UserID = { userId}";




                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.Trim();

                    if (int.TryParse(search, out int idValue))
                    {
                        sql += $" AND (pt.TransactionID = {idValue} OR pt.RequestID = {idValue})";
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid numeric ID to search.", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                sql += " ORDER BY pt.TransactionID DESC";

                DataTable dt = DataBase.GetDataTable(sql);

                metroGridPayment.AutoGenerateColumns = false;
                metroGridPayment.DataSource = dt;
                metroGridPayment.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UserControlPayment_Load_1(object sender, EventArgs e)
        {
            try
            {
                currentUserId = FormUserDashboard.CurrentUserId;

                string insertPendingPayments = $@"
                INSERT INTO PaymentTransaction (RequestID, Amount, PaymentStatus)
                SELECT 
                    pr.RequestID,
                    pr.BudgetOffered,
                    'Pending'
                FROM ProjectRequest pr
                WHERE pr.StatusID = 9  
                AND pr.UserID = {currentUserId}
                AND NOT EXISTS (
                    SELECT 1 FROM PaymentTransaction pt WHERE pt.RequestID = pr.RequestID
                )";

                DataBase.ExecuteNonQuery(insertPendingPayments);

                LoadUserPayments(currentUserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadUserPayments(currentUserId, textBoxSearch.Text.Trim());

        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LoadUserPayments(currentUserId, textBoxSearch.Text.Trim());
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadUserPayments(currentUserId);
        }

        private void buttonMakePayment_Click(object sender, EventArgs e)
        {
            if (metroGridPayment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a payment first.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int transactionId = Convert.ToInt32(
                metroGridPayment.SelectedRows[0].Cells["dgvTransactionID"].Value
            );

            using (var makePaymentForm = new FormMakePayment(transactionId))
            {
                if (makePaymentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUserPayments(currentUserId);
                }
            }

        }

        private void metroGridPayment_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            metroGridPayment.ClearSelection();
            metroGridPayment.CurrentCell = null;
        }
    }
}
