﻿using IdeaBid__Project_Request___Management_Platform.DataBaseConnection;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IdeaBid__Project_Request___Management_Platform.GUI
{
    public partial class UserControlcategory : UserControl
    {


        private int? selectedCategoryId = null;
        private string oldCategoryName = null;
        public UserControlcategory()
        {
            InitializeComponent();

            dgvTable.MultiSelect = false;
            dgvTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTable.SelectionChanged += dgvTable_SelectionChanged;

            buttonDeleteUser.Enabled = false;

        }



                public void LoadCategories(string search = null)
        {
            string sql = "SELECT CategoryID, CategoryName FROM Category";

            if (!string.IsNullOrWhiteSpace(search))
            {
                sql += $" WHERE CAST(CategoryID AS NVARCHAR) LIKE '%{search}%' OR CategoryName LIKE '%{search}%'";
            }

            sql += " ORDER BY CategoryID ASC";

            DataTable dt = DataBase.GetDataTable(sql);

            dgvTable.AutoGenerateColumns = false;
            dgvTable.DataSource = dt;

            ClearFields();
            textBoxSearch.Focus();
        }
        private void dgvTable_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTable.SelectedRows.Count == 0)
            {
                selectedCategoryId = null;
                oldCategoryName = null;
                buttonDeleteUser.Enabled = false;
                return;
            }

            DataGridViewRow row = dgvTable.SelectedRows[0];

            var idCell = row.Cells["dgvCategoryID"];
            if (idCell == null || idCell.Value == null || !int.TryParse(idCell.Value.ToString(), out int id))
            {
                selectedCategoryId = null;
                buttonDeleteUser.Enabled = false;
                return;
            }

            selectedCategoryId = id;
            oldCategoryName = row.Cells["dgvCategoryName"].Value?.ToString();

            textBoxID.Text = selectedCategoryId.ToString();
            textBoxName.Text = oldCategoryName;

            buttonDeleteUser.Enabled = true;
        }

        private void ClearFields()
        {
            textBoxID.Text = "Auto Generated";
            textBoxName.Text = "";
            dgvTable.ClearSelection();
            if (dgvTable.CurrentCell != null) dgvTable.CurrentCell = null;
            selectedCategoryId = null;
            oldCategoryName = null;
            buttonDeleteUser.Enabled = false;
        }

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Category name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return;
            }

            // Check duplicate
            if (selectedCategoryId == null) // insert
            {
                string checkQuery = $"SELECT CategoryID FROM Category WHERE CategoryName = '{name}'";
                DataTable dt = DataBase.GetDataTable(checkQuery);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Category name already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert new category
                string insertSql = $"INSERT INTO Category (CategoryName) VALUES ('{name}')";

                if (DataBase.ExecuteNonQuery(insertSql) > 0)
                {
                    MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }
            }
            else 
            {
                name = name.Replace("'", "''");
                string oldName = oldCategoryName.Replace("'", "''");

                if (name != oldName)
                {
                    string checkQuery = $"SELECT CategoryID FROM Category WHERE CategoryName = '{name}'";
                    DataTable dt = DataBase.GetDataTable(checkQuery);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Category name already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                string updateSql = $"UPDATE Category SET CategoryName = '{name}' WHERE CategoryID = {selectedCategoryId}";
                int rowsAffected = DataBase.ExecuteNonQuery(updateSql);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }

            }
        }

        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {

            if (selectedCategoryId == null)
            {
                MessageBox.Show("Please select a category to delete.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this category? This action cannot be undone.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            string sql = $"DELETE FROM Category WHERE CategoryID = {selectedCategoryId}";

            int Result = DataBase.ExecuteNonQuery(sql);

            if (Result > 0)
            {
                MessageBox.Show("Category deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCategories();
            }

            else
            {
                MessageBox.Show("Delete failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = "";
            LoadCategories();
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string s = textBoxSearch.Text.Trim();
                LoadCategories(string.IsNullOrEmpty(s) ? null : s);
            }
        }

        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            ClearFields();
            textBoxName.Focus();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string s = textBoxSearch.Text.Trim();
            LoadCategories(string.IsNullOrEmpty(s) ? null : s);

        }
    }
}
    

