using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class Trash : Form
    {
        public Trash()
        {
            InitializeComponent();
        }

        private void Trash_Load(object sender, EventArgs e)
        {
            LoadTrash();

            string role = LoginForm.Session.Role;

            if (role != "Admin") // only Admin can permanently delete records
            {
                BtnDelPerma.Enabled = false;
            }

            BtnDelPerma.Text = "";
            BtnRes.Text = "";
            BtnBack.Text = "";

            BtnRes.Image = new Bitmap(Properties.Resources.recycle_symbol, 32, 32);
            BtnDelPerma.Image = new Bitmap(Properties.Resources.delete, 32, 32);
            BtnBack.Image = new Bitmap(Properties.Resources.back, 32, 32);

            BtnRes.ImageAlign = ContentAlignment.MiddleCenter;
            BtnDelPerma.ImageAlign = ContentAlignment.MiddleCenter;
            BtnBack.ImageAlign = ContentAlignment.MiddleCenter;

            BtnRes.FlatStyle = FlatStyle.Flat;
            BtnRes.FlatAppearance.BorderSize = 0;
            BtnRes.BackColor = Color.Transparent;

            BtnDelPerma.FlatStyle = FlatStyle.Flat;
            BtnDelPerma.FlatAppearance.BorderSize = 0;
            BtnDelPerma.BackColor = Color.Transparent;

            BtnBack.FlatStyle = FlatStyle.Flat;
            BtnBack.FlatAppearance.BorderSize = 0;
            BtnBack.BackColor = Color.Transparent;
        }

        private void BtnBack_MouseEnter(object sender, EventArgs e)
        {
            BtnBack.BackColor = Color.LightGray;
        }

        private void BtnBack_MouseLeave(object sender, EventArgs e)
        {
            BtnBack.BackColor = Color.Transparent;
        }

        private void BtnDelPerma_MouseEnter(object sender, EventArgs e)
        {
            BtnDelPerma.BackColor = Color.LightGray;
        }

        private void BtnDelPerma_MouseLeave(object sender, EventArgs e)
        {
            BtnDelPerma.BackColor = Color.Transparent;
        }

        private void BtnRes_MouseEnter(object sender, EventArgs e)
        {
            BtnRes.BackColor = Color.LightGray;
        }

        private void BtnRes_MouseLeave(object sender, EventArgs e)
        {
            BtnRes.BackColor = Color.Transparent;
        }

        private void BtnBack_Click(object sender, EventArgs e) // Confirmation dialog before going back to Inventory
        {
            DialogResult result = MessageBox.Show(
               "Are you sure you want to go back to Inventory?",
               "Inventory Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                Form Inventory = new Inventory();
                Inventory.Show();
                this.Hide();
            }
        }
        private void LoadTrash() // Load deleted products and suppliers into DataGridView
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT ProductID AS ID,
                                        ProductName AS Name,
                                       'Product' AS Type
                                 FROM Products
                                 WHERE IsDeleted = 1

                           UNION ALL
                                 SELECT SupplierID AS ID,
                                        SupplierName AS Name,
                                       'Supplier' AS Type
                                        FROM Suppliers
                                        WHERE IsDeleted = 1";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DgvTrash.DataSource = dt;
                DgvTrash.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void BtnRes_Click(object sender, EventArgs e) // Restore selected product or supplier
        {
            try
            {
                if (DgvTrash.CurrentRow == null)
                {
                    MessageBox.Show("Select a record first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show(
                "Are you sure you want to restore this record?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
           );
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(DgvTrash.CurrentRow.Cells["ID"].Value);
                    string? type = DgvTrash.CurrentRow.Cells["Type"].Value?.ToString();

                    using (SqlConnection con = new SqlConnection(DB.conStr))
                    {
                        con.Open();

                        string query = "";

                        if (type == "Product")
                            query = "UPDATE Products SET IsDeleted = 0 WHERE ProductID = @id";
                        else if (type == "Supplier")
                            query = "UPDATE Suppliers SET IsDeleted = 0 WHERE SupplierID = @id";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(type + " restored successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTrash();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelPerma_Click(object sender, EventArgs e) // Permanently delete selected product or supplier
        {
            try
            {
                if (DgvTrash.CurrentRow == null)
                {
                    MessageBox.Show("Select a record first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = Convert.ToInt32(DgvTrash.CurrentRow.Cells["ID"].Value);
                string? type = DgvTrash.CurrentRow.Cells["Type"].Value?.ToString();

                DialogResult result = MessageBox.Show(
                    "Permanently delete this " + type + "?\n\nThis will remove ALL related records.",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                using (SqlConnection con = new SqlConnection(DB.conStr))
                {
                    con.Open();

                    SqlTransaction trans = con.BeginTransaction();

                    try
                    {
                        if (type == "Product")
                        {
                            SqlCommand cmd1 = new SqlCommand(
                                "DELETE FROM STOCK_OUT WHERE ProductID = @id", con, trans);
                            cmd1.Parameters.AddWithValue("@id", id);
                            cmd1.ExecuteNonQuery();

                            SqlCommand cmd2 = new SqlCommand(
                                "DELETE FROM STOCK_IN WHERE ProductID = @id", con, trans);
                            cmd2.Parameters.AddWithValue("@id", id);
                            cmd2.ExecuteNonQuery();

                            SqlCommand cmd3 = new SqlCommand(
                                "DELETE FROM Products WHERE ProductID = @id", con, trans);
                            cmd3.Parameters.AddWithValue("@id", id);
                            cmd3.ExecuteNonQuery();
                        }
                        else if (type == "Supplier")
                        {
                            SqlCommand cmd1 = new SqlCommand(
                                "DELETE FROM STOCK_IN WHERE SupplierID = @id", con, trans);
                            cmd1.Parameters.AddWithValue("@id", id);
                            cmd1.ExecuteNonQuery();

                            SqlCommand cmd2 = new SqlCommand(
                                "DELETE FROM Suppliers WHERE SupplierID = @id", con, trans);
                            cmd2.Parameters.AddWithValue("@id", id);
                            cmd2.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Unknown record type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            trans.Rollback();
                            return;
                        }
                        trans.Commit();

                        MessageBox.Show(type + " permanently deleted.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exTrans)
                    {
                        trans.Rollback();
                        MessageBox.Show("Transaction failed:\n" + exTrans.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                LoadTrash();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}