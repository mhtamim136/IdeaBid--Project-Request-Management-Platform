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
    public partial class FormReviewTransaction : Form
    {
        private readonly int _transactionId;
        private readonly int _loggedInAdminId;

        public FormReviewTransaction(int transactionId)
        {
            InitializeComponent();
            _transactionId = transactionId;

            try
            {
                string username = FormControlPortal.LoggedInUser;
                string query = $"SELECT AdminID FROM AdminInfo WHERE AdminUsername = '{username}'";
                object result = DataBase.ExecuteScalar(query);
                if (result != null && int.TryParse(result.ToString(), out int id))
                    _loggedInAdminId = id;
                else
                    _loggedInAdminId = 0; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admin info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormReviewTransaction_Load(object sender, EventArgs e)
        {
            try
            {
            //    string sql = $@"
            //SELECT TransactionID, Amount, PaymentMethod, PaymentStatus, Remarks
            //FROM PaymentTransaction
            //WHERE TransactionID = {_transactionId}";

                string sql = $@"
                                SELECT 
                                    pt.TransactionID, 
                                    pt.Amount, 
                                    pm.PaymentName AS PaymentMethodName, 
                                    pt.PaymentStatus, 
                                    pt.Remarks
                                FROM PaymentTransaction pt
                                INNER JOIN PaymentMethod pm ON pt.PaymentMethod = pm.PaymentID
                                WHERE pt.TransactionID = {_transactionId}";

                DataTable dt = DataBase.GetDataTable(sql);
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Transaction not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                DataRow row = dt.Rows[0];
                labelTransactionIDShow.Text = row["TransactionID"].ToString();
                labelAmountShow.Text = $"{Convert.ToDecimal(row["Amount"]):0.00} ৳";
                textBoxPaymentMethod.Text = row["PaymentMethodName"]?.ToString();
                metroTextBoxRemarks.Text = row["Remarks"]?.ToString();

                string status = row["PaymentStatus"].ToString();


                if (status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxAction.SelectedItem = "Confirm";
                    comboBoxAction.Enabled = false;
                    metroTextBoxRemarks.ReadOnly = true;
                    buttonSave.Enabled = false;
                    MessageBox.Show("This transaction has already been confirmed. You cannot modify it.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (status.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxAction.SelectedItem = "Reject";
                    comboBoxAction.Enabled = true;
                    metroTextBoxRemarks.ReadOnly = false;
                    buttonSave.Enabled = true;
                }
                else
                {
                    comboBoxAction.SelectedIndex = 0; 
                    comboBoxAction.Enabled = true;
                    metroTextBoxRemarks.ReadOnly = false;
                    buttonSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transaction details:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                string action = comboBoxAction.Text;
                string remarks = metroTextBoxRemarks.Text.Trim();

                if (string.IsNullOrEmpty(action))
                {
                    MessageBox.Show("⚠ Please select an action.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (action == "Reject" && string.IsNullOrWhiteSpace(remarks))
                {
                    MessageBox.Show("⚠ Remarks are required when rejecting a transaction.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string currentStatus = DataBase.ExecuteScalar($"SELECT PaymentStatus FROM PaymentTransaction WHERE TransactionID={_transactionId}")?.ToString();
                if (currentStatus == "Confirmed")
                {
                    MessageBox.Show("⚠ This transaction has already been confirmed.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string status = action + "ed";

                string updateQuery = $@"
                                UPDATE PaymentTransaction
                                SET PaymentStatus = '{status}',
                                    ConfirmedBy = {_loggedInAdminId},
                                    ConfirmationDate = GETDATE(),
                                    Remarks = '{remarks.Replace("'", "''")}'
                                WHERE TransactionID = {_transactionId}";

                int updated = DataBase.ExecuteNonQuery(updateQuery);
                if (updated > 0)
                {
                    string logQuery = $@"
                                        INSERT INTO PaymentLog (TransactionID, ActionType, ActionBy, ActionDate, Remarks)
                                        VALUES ({_transactionId}, '{status}', {_loggedInAdminId}, GETDATE(), '{remarks.Replace("'", "''")}')";
                    DataBase.ExecuteNonQuery(logQuery);

                    if (action == "Confirm")
                    {
                        string sql = $@"
                    UPDATE ProjectRequest
                    SET StatusID = 3
                    WHERE RequestID = (
                        SELECT RequestID FROM PaymentTransaction WHERE TransactionID = {_transactionId}
                    )";
                        DataBase.ExecuteNonQuery(sql);
                    }

                    MessageBox.Show("Transaction updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No changes were made.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
