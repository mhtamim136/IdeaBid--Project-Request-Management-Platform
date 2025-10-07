using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    public partial class FormNewResponed : Form
    {
        private readonly int _currentUserId;
        private readonly string _role;
        public readonly int _requestId;

        public FormNewResponed(string loggedInUser, string role, int requestId)
        {
            InitializeComponent();
            _role = role;
            _requestId = requestId;

            string sql;

            if (role == "Admin")
            {
                sql = $"SELECT AdminID FROM AdminInfo WHERE AdminUsername = '{loggedInUser}'";
            }
            else
            {
                sql = $"SELECT DevID FROM DevInfo WHERE DevUsername = '{loggedInUser}'";
            }

            object res = DataBase.ExecuteScalar(sql);
            _currentUserId = (res != null && int.TryParse(res.ToString(), out int id)) ? id : 0;
        }



        private void FormNewResponed_Load(object sender, EventArgs e)
        {
            LoadStatusCombo();
            LoadRequestDeadline();
            textBoxResponseID.Text = "Auto Generated";
            textBoxRequestID.Text = _requestId.ToString();
        }

        private void LoadStatusCombo()
        {
            string sql = "SELECT StatusID, StatusName FROM ProjectStatus ORDER BY StatusName";
            DataTable dt = DataBase.GetDataTable(sql);
            if (dt == null) return;

            comboBoxStatus.DisplayMember = "StatusName";
            comboBoxStatus.ValueMember = "StatusID";
            comboBoxStatus.DataSource = dt;
            comboBoxStatus.SelectedIndex = -1;
        }

        private void LoadRequestDeadline()
        {
            string sql = $"SELECT Deadline FROM ProjectRequest WHERE RequestID = {_requestId}";

            object res = DataBase.ExecuteScalar(sql);
            if (res != null && DateTime.TryParse(res.ToString(), out DateTime deadline))
            {
                metroDateTimeExpectedDate.Value = deadline;
            }
            else
            {
                metroDateTimeExpectedDate.Value = DateTime.Now.AddDays(7);
            }
        }


        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (comboBoxStatus.SelectedIndex == -1 || comboBoxStatus.SelectedValue == null)
            {
                MessageBox.Show("Please select a status.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxStatus.Focus();
                return;
            }

            int statusId = Convert.ToInt32(comboBoxStatus.SelectedValue);
            string feedback = string.IsNullOrWhiteSpace(textBoxFeedback.Text) ? null : textBoxFeedback.Text.Trim();
            if (!string.IsNullOrEmpty(feedback))
            {
                feedback = feedback.Replace("'", "''"); 
            }
            decimal? proposalAmount = null;

            if (!string.IsNullOrWhiteSpace(textBoxProposalAmount.Text))
            {
                if (decimal.TryParse(textBoxProposalAmount.Text, out decimal amount))
                {
                    proposalAmount = amount;
                }
                else
                {
                    MessageBox.Show("Proposal amount must be a valid number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxProposalAmount.Focus();
                    return;
                }
            }

            DateTime? expectedDeadline = null;
            if (metroDateTimeExpectedDate.Checked)
            {
                expectedDeadline = metroDateTimeExpectedDate.Value;
            }

            try
            {
                string insertSql = $@"
                                INSERT INTO ProjectResponse 
                                    (RequestID, DevID, AdminID, ProposalDate, ProposalAmount, Deadline, Feedback, StatusID)
                                VALUES
                                    ({_requestId},
                                     {(_role == "Admin" ? "NULL" : _currentUserId.ToString())},
                                     {(_role == "Admin" ? _currentUserId.ToString() : "NULL")},
                                     GETDATE(),
                                     {(proposalAmount.HasValue ? proposalAmount.Value.ToString() : "NULL")},
                                     {(expectedDeadline.HasValue ? $"'{expectedDeadline.Value:yyyy-MM-dd HH:mm:ss}'" : "NULL")},
                                     {(string.IsNullOrEmpty(feedback) ? "NULL" : $"'{feedback}'")},
                                     {statusId});
                                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                object res = DataBase.ExecuteScalar(insertSql);

                if (res != null && int.TryParse(res.ToString(), out int newResponseId))
                {
                    textBoxResponseID.Text = newResponseId.ToString();

  
                    string updateRequestSql = $"UPDATE ProjectRequest SET StatusID = {statusId}";

                    if (proposalAmount.HasValue)
                        updateRequestSql += $", BudgetOffered = {proposalAmount.Value}";

                    if (expectedDeadline.HasValue)
                        updateRequestSql += $", Deadline = '{expectedDeadline.Value:yyyy-MM-dd HH:mm:ss}'";

                    updateRequestSql += $" WHERE RequestID = {_requestId};";

                    DataBase.ExecuteNonQuery(updateRequestSql);

                    MessageBox.Show("Response sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to send response.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending response:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFeedback.Clear();
            textBoxProposalAmount.Clear();

            metroDateTimeExpectedDate.Value = DateTime.Now;
            metroDateTimeExpectedDate.Checked = false; 

            comboBoxStatus.SelectedIndex = -1;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel? Unsaved changes will be lost.",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void FormNewResponed_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

    }
}
