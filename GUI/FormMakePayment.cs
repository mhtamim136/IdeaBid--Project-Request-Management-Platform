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
    public partial class FormMakePayment : Form
    {
        private readonly int _transactionId; 

        public FormMakePayment(int transactionId)
        {
            InitializeComponent();
            _transactionId = transactionId;
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPayment.SelectedIndex < 0)
                {
                    MessageBox.Show("Please select a payment method.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int methodId = Convert.ToInt32(comboBoxPayment.SelectedValue);
                string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string updateSql = $@"
                                    UPDATE PaymentTransaction
                                    SET PaymentMethod = {methodId},
                                        PaymentDate = '{date}',
                                        PaymentStatus = 'Processing'
                                    WHERE TransactionID = {_transactionId}";


                int rows = DataBase.ExecuteNonQuery(updateSql);

                if (rows > 0)
                {
                    string updateRequest = $@"
                                    UPDATE ProjectRequest
                                    SET StatusID = 4
                                    WHERE RequestID = (
                                        SELECT RequestID FROM PaymentTransaction WHERE TransactionID = {_transactionId}
                                    )";
                    DataBase.ExecuteNonQuery(updateRequest);

                    MessageBox.Show("✅ Payment completed!\nPlease wait for confirmation from Admin.",
                                    "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; 
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Payment failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing payment:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMakePayment_Load_1(object sender, EventArgs e)
        {
            try
            {
                labelPaymentIDShow.Text = _transactionId.ToString();

                DataTable dtMethods = DataBase.GetDataTable("SELECT PaymentID, PaymentName FROM PaymentMethod ORDER BY PaymentName");
                comboBoxPayment.DataSource = dtMethods;
                comboBoxPayment.DisplayMember = "PaymentName";
                comboBoxPayment.ValueMember = "PaymentID";
                comboBoxPayment.SelectedIndex = -1;



                string sql = $"SELECT Amount, PaymentStatus, PaymentMethod FROM PaymentTransaction WHERE TransactionID = {_transactionId}";
                DataTable dt = DataBase.GetDataTable(sql);

                labelAmountShow.Text = "N/A";
                comboBoxPayment.Enabled = true;
                buttonPayment.Enabled = true;

                if (dt.Rows.Count > 0)
                {
                    var r = dt.Rows[0];

                    decimal amount = Convert.ToDecimal(r["Amount"]);
                    labelAmountShow.Text = $"{amount:0.00} ৳";

                    string status = r["PaymentStatus"].ToString();
                    string method = r["PaymentMethod"].ToString();


                    if (r["PaymentMethod"] != DBNull.Value)
                        comboBoxPayment.SelectedValue = Convert.ToInt32(r["PaymentMethod"]);


                    if (status != "Pending")
                    {
                        labelAlreadyPaid.Visible = true;
                        labelAlreadyPaid.ForeColor = Color.Green;

                        comboBoxPayment.Enabled = false;
                        buttonPayment.Enabled = false;
                    }
                    else
                    {
                        labelWarning.Visible = true;
                        labelWarning.Text = "⚠ Once payment is made, it cannot be undone.";
                        labelWarning.ForeColor = Color.DarkOrange;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading payment details: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
