using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IdeaBid__Project_Request___Management_Platform.DataBaseConnection
{
    public static class DataBase
    {
        private const string ConnectionString = @"Data Source=TAMIM\SQLEXPRESS;Initial Catalog=IdeaBid;Integrated Security=True;TrustServerCertificate=True";

        public static object ExecuteScalar(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static int ExecuteNonQuery(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }

            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("That username or email is already registered.", "Duplicate entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            catch (SqlException ex) when (ex.Number == 8152)
            {
                MessageBox.Show("One of your inputs is too long. Please shorten it.", "Data Too Long", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public static string AuthenticateRole(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            username = username.Trim().Replace("'", "''");
            password = password.Trim().Replace("'", "''");

            string query = $@"
        SELECT TOP 1 Role FROM (
            SELECT 'Admin' AS Role FROM AdminInfo
            WHERE AdminUsername = '{username}'
            AND AdminPassword COLLATE SQL_Latin1_General_CP1_CS_AS = '{password}'
            UNION ALL
            SELECT 'Dev' FROM DevInfo
            WHERE DevUsername = '{username}'
            AND DevPassword COLLATE SQL_Latin1_General_CP1_CS_AS = '{password}'
            UNION ALL
            SELECT 'User' FROM UserInfo
            WHERE UserName = '{username}'
            AND Password COLLATE SQL_Latin1_General_CP1_CS_AS = '{password}'
        ) UserRoles;";

            try
            {
                object result = ExecuteScalar(query);
                return result?.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static (bool usernameExists, bool emailExists) CheckUsernameOrEmailExists(string username, string email)
        {

            username = (username ?? "").Trim().Replace("'", "''");
            email = (email ?? "").Trim().Replace("'", "''");

            string userQuery = $@"
        SELECT TOP 1 1 FROM (
            SELECT AdminUsername AS val FROM AdminInfo
            UNION ALL
            SELECT DevUsername FROM DevInfo
            UNION ALL
            SELECT UserName FROM UserInfo
        ) x
        WHERE val = '{username}';";

            string emailQuery = $@"
        SELECT TOP 1 1 FROM (
            SELECT AdminEmail AS val FROM AdminInfo
            UNION ALL
            SELECT DevEmail FROM DevInfo
            UNION ALL
            SELECT Email FROM UserInfo
        ) x
        WHERE val = '{email}';";

            try
            {
                bool uExists = ExecuteScalar(userQuery) != null;
                bool eExists = ExecuteScalar(emailQuery) != null;

                return (uExists, eExists);
            }

            catch (Exception)
            {
                return (false, false);
            }
        }



        public static DataTable GetDataTable(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }



    public static class ValidationHelper
    {
        public static (string error, string field) ValidateUserInput(
                 string username,
                 string fullName,
                 string email,
                 string password,
                 string userType)
        {

            if (string.IsNullOrWhiteSpace(username))
                return ("Please enter a username.", "username");

            if (username.Length < 4 || username.Length > 50)
                return ("Username should be 4 to 50 characters long.", "username");

            if (string.IsNullOrWhiteSpace(fullName))
                return ("Please enter full name.", "fullname");

            if (string.IsNullOrWhiteSpace(email))
                return ("Please enter an email address.", "email");

            if (!email.Contains("@") || !email.Contains("."))
                return ("Please enter a valid email address (e.g., name@example.com).", "email");

            if (string.IsNullOrWhiteSpace(userType))
                return ("Please select a user type.", "usertype");

            if (string.IsNullOrWhiteSpace(password))
                return ("Please enter a password.", "password");

            if (password.Length < 4 || password.Length > 20)
                return ("Password should be 4 to 20 characters long.", "password");

            return (null, null);
        }

    }

}
