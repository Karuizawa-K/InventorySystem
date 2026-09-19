using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static InventorySystem.LoginForm;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace InventorySystem
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }
        bool shouldExpand = false;
        bool isExpanded = false;
        bool isAnimating = false;
        bool IsRowSelectedP = false;
        bool IsRowSelectedS = false;

        private void TbPDash_Click(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void Gb1_Enter(object sender, EventArgs e)
        {

        }
        private void label22_Click(object sender, EventArgs e)
        {

        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void LblMenu_MouseLeave(object sender, EventArgs e)
        {

        }
        private void PcBxLog_MouseLeave(object sender, EventArgs e)
        {

        }
        private void LblMenuInv_MouseLeave(object sender, EventArgs e)
        {

        }
        private void LblDash_MouseHover(object sender, EventArgs e)
        {
            LblDash.ForeColor = Color.LightBlue;
        }
        private void LblDash_MouseLeave(object sender, EventArgs e)
        {
            LblDash.ForeColor = Color.White;
        }
        private void LblRep_Click(object sender, EventArgs e)
        {
            Dashboard.SelectedIndex = 4;
        }
        private void LblDash_Click(object sender, EventArgs e)
        {
            Dashboard.SelectedIndex = 0;
        }
        private void LblProd_MouseHover(object sender, EventArgs e)
        {
            LblProd.ForeColor = Color.LightBlue;
        }
        private void LblProd_MouseLeave(object sender, EventArgs e)
        {
            LblProd.ForeColor = Color.White;
        }
        private void LblSupp_MouseHover(object sender, EventArgs e)
        {
            LblSupp.ForeColor = Color.LightBlue;
        }
        private void LblSupp_MouseLeave(object sender, EventArgs e)
        {
            LblSupp.ForeColor = Color.White;
        }
        private void LblInv_MouseHover(object sender, EventArgs e)
        {
            LblInv.ForeColor = Color.LightBlue;
        }
        private void LblInv_MouseLeave(object sender, EventArgs e)
        {
            LblInv.ForeColor = Color.White;
        }
        private void LblRep_MouseHover(object sender, EventArgs e)
        {
            LblRep.ForeColor = Color.LightBlue;
        }
        private void LblRep_MouseLeave(object sender, EventArgs e)
        {
            LblRep.ForeColor = Color.White;
        }
        private void LblLogout_MouseHover(object sender, EventArgs e)
        {
            LblLogout.ForeColor = Color.LightBlue;
        }
        private void LblLogout_MouseLeave(object sender, EventArgs e)
        {
            LblLogout.ForeColor = Color.White;
        }
        private void LblDash_MouseEnter(object sender, EventArgs e)
        {
            LblDash.ForeColor = Color.LightBlue;
        }
        private void LblProd_MouseEnter(object sender, EventArgs e)
        {
            LblProd.ForeColor = Color.LightBlue;
        }
        private void LblSupp_MouseEnter(object sender, EventArgs e)
        {
            LblSupp.ForeColor = Color.LightBlue;
        }
        private void LblInv_MouseEnter(object sender, EventArgs e)
        {
            LblInv.ForeColor = Color.LightBlue;
        }
        private void LblRep_MouseEnter(object sender, EventArgs e)
        {
            LblRep.ForeColor = Color.LightBlue;
        }
        private void LblLogout_MouseEnter(object sender, EventArgs e)
        {
            LblLogout.ForeColor = Color.LightBlue;
        }
        private void MenuTransition_Tick(object sender, EventArgs e)
        {
            if (shouldExpand)
            {
                PnlSidebar.Width += 10;

                if (PnlSidebar.Width >= 284)
                {
                    PnlSidebar.Width = 284;
                    isExpanded = true;
                    isAnimating = false;
                    MenuTransition.Stop();
                }
            }
            else
            {
                PnlSidebar.Width -= 10;

                if (PnlSidebar.Width <= 81)
                {
                    PnlSidebar.Width = 81;
                    isExpanded = false;
                    isAnimating = false;
                    MenuTransition.Stop();
                }
            }
        }
        private void LblMenu_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanded && !isAnimating)
            {
                shouldExpand = true;
                isAnimating = true;
                MenuTransition.Start();
            }
        }
        private void PnlSidebar_MouseEnter(object sender, EventArgs e)
        {
            if (isAnimating || isExpanded) return;

            shouldExpand = true;
            isAnimating = true;
            MenuTransition.Start();
        }
        private void PnlSidebar_MouseLeave(object sender, EventArgs e)
        {
            if (PnlSidebar.ClientRectangle.Contains(PnlSidebar.PointToClient(Cursor.Position)))
                return;

            if (isAnimating || !isExpanded) return;

            shouldExpand = false;
            isAnimating = true;
            MenuTransition.Start();
        }
        private void label8_MouseEnter(object sender, EventArgs e)
        {
            shouldExpand = false;
            MenuTransition.Start();
        }
        private void label8_MouseLeave(object sender, EventArgs e)
        {
            shouldExpand = true;
            MenuTransition.Start();
        }
        private void LblProd_Click(object sender, EventArgs e)
        {
            Dashboard.SelectedIndex = 1;
        }

        private void LblSupp_Click(object sender, EventArgs e)
        {
            Dashboard.SelectedIndex = 2;
        }

        private void LblInv_Click(object sender, EventArgs e)
        {
            Dashboard.SelectedIndex = 3;
        }
        private void LblLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();
            }
        }
        private void PcBxDash_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanded && !isAnimating)
            {
                shouldExpand = true;
                isAnimating = true;
                MenuTransition.Start();
            }
        }
        private void PcBxProd_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanded && !isAnimating)
            {
                shouldExpand = true;
                isAnimating = true;
                MenuTransition.Start();
            }
        }
        private void PcBxSupp_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanded && !isAnimating)
            {
                shouldExpand = true;
                isAnimating = true;
                MenuTransition.Start();
            }
        }
        private void PcBxInv_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanded && !isAnimating)
            {
                shouldExpand = true;
                isAnimating = true;
                MenuTransition.Start();
            }
        }
        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanded && !isAnimating)
            {
                shouldExpand = true;
                isAnimating = true;
                MenuTransition.Start();
            }
        }
        private void LblMenuInv_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanded && !isAnimating)
            {
                shouldExpand = true;
                isAnimating = true;
                MenuTransition.Start();
            }
        }
        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            Point mousePos = PnlSidebar.PointToClient(Cursor.Position);

            if (PnlSidebar.ClientRectangle.Contains(mousePos))
                return;

            if (isAnimating || !isExpanded) return;

            shouldExpand = false;
            isAnimating = true;
            MenuTransition.Start();
        }
        private void PcBxLog_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanded && !isAnimating)
            {
                shouldExpand = true;
                isAnimating = true;
                MenuTransition.Start();
            }
        }
        private void PcBxRep_MouseEnter(object sender, EventArgs e)
        {
            if (!isExpanded && !isAnimating)
            {
                shouldExpand = true;
                isAnimating = true;
                MenuTransition.Start();
            }
        }
        private void TxtInQuanti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtOutQuanti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox? txt = sender as TextBox;

            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (txt != null)
            {
                if (e.KeyChar == '.' && !txt.Text.Contains("."))
                    return;
            }

            e.Handled = true;
        }
        private void TxtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtContact_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtContact_Leave(object sender, EventArgs e)
        {

        }
        private void label25_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Are you sure you want to go to Trash Bin?",
               "Trash Bin Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                Form Trash = new Trash();
                Trash.Show();
                this.Hide();
            }
        }
        private void label25_MouseEnter(object sender, EventArgs e)
        {
            label25.ForeColor = Color.LightBlue;
        }
        private void label25_MouseHover(object sender, EventArgs e)
        {
            label25.ForeColor = Color.LightBlue;
        }
        private void label25_MouseLeave(object sender, EventArgs e)
        {
            label25.ForeColor = Color.White;
        }

        private void Inventory_Load(object sender, EventArgs e) // Method to initialize data and apply role-based permissions
        {
            LoadProducts();
            LoadSuppliers();
            LoadCategories();
            LoadProductCmBox();
            LoadSupplierCmBox();
            LoadInventory();
            LoadRecentOrders();
            LoadLowStockDashboard();
            ApplyRolePermissions();

            CmBoxRepType.Items.Clear();
            CmBoxRepType.Items.Add("All Stock Movement");
            CmBoxRepType.Items.Add("Stock In");
            CmBoxRepType.Items.Add("Stock Out");
            CmBoxRepType.Items.Add("All Stocks");
            CmBoxRepType.Items.Add("High Stocks");
            CmBoxRepType.Items.Add("Low Stocks");
            CmBoxRepType.SelectedIndex = -1;

            DtFrom.MinDate = new DateTime(2000, 1, 1);
            DtTo.MinDate = new DateTime(2000, 1, 1);

            DtFrom.MaxDate = DateTime.Today;
            DtTo.MaxDate = DateTime.Today;

            TxtContact.MaxLength = 11;

            CmBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            CmBoxCategory.IntegralHeight = false;

            CmBoxInPro.DropDownStyle = ComboBoxStyle.DropDownList;
            CmBoxInPro.IntegralHeight = false;

            CmBoxOutPro.DropDownStyle = ComboBoxStyle.DropDownList;
            CmBoxOutPro.IntegralHeight = false;

            CmBoxInSup.DropDownStyle = ComboBoxStyle.DropDownList;
            CmBoxInSup.IntegralHeight = false;
        }

        private void CmBoxRepType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selected = CmBoxRepType.SelectedItem?.ToString();

            bool useDate = selected == "All Stock Movement" ||
                           selected == "Stock In" ||
                           selected == "Stock Out";

            DtFrom.Enabled = useDate;
            DtTo.Enabled = useDate;

            if (!useDate)
            {
                DtFrom.Value = DateTime.Today;
                DtTo.Value = DateTime.Today;
            }
        }

        private void ApplyRolePermissions() // Method to enable/disable controls based on user role
        {
            string role = LoginForm.Session.Role;

            if (role == "Staff")
            {
                BtnAddProduct.Enabled = false;
                BtnDelProduct.Enabled = false;
                BtnUpdProduct.Enabled = false;
                BtnAddSupp.Enabled = false;
                BtnUpdSupp.Enabled = false;
                BtnDelSupp.Enabled = false;
                label25.Enabled = false;
            }
            else if (role == "Manager")
            {
                // Full access
            }
            else if (role == "Admin")
            {
                // Full access
            }
        }

        private void LoadProducts() // Method to load products into DataGridView
        {
            using (SqlConnection con = new SqlConnection(DB.conStr ?? throw new InvalidOperationException("DB.conStr is null")))
            {
                string query = @"SELECT p.ProductID,                           
                             p.ProductName,
                             p.CategoryID,
                             c.CategoryName,                            
                             p.UnitPrice,
                             p.Quantity,
                             p.DateAdded
                FROM Products p
                LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
                WHERE p.IsDeleted = 0";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DgvProducts.DataSource = dt;
                DgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                IsRowSelectedP = false;
                DgvProducts.ClearSelection();
                DgvProducts.CurrentCell = null;
            }
        }

        private void LoadSuppliers() // Method to load suppliers into DataGridView
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT s.SupplierID,
                                        s.SupplierName,
                                        s.ContactNumber,
                                        s.Email,
                                        s.Address 

                                 FROM Suppliers s
                                 WHERE s.IsDeleted = 0";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSuppliers.DataSource = dt;
                dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                IsRowSelectedS = false;
                dgvSuppliers.ClearSelection();
                dgvSuppliers.CurrentCell = null;
            }
        }

        private void LoadCategories() // Method to load categories into CategoryComboBox
        {
            using (SqlConnection con = new SqlConnection(DB.conStr ?? throw new InvalidOperationException("DB.conStr is null")))
            {
                string query = "SELECT CategoryID, CategoryName FROM Categories";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CmBoxCategory.DataSource = dt;
                CmBoxCategory.DisplayMember = "CategoryName";
                CmBoxCategory.ValueMember = "CategoryID";

                CmBoxCategory.SelectedIndex = -1;
            }
        }

        private void LoadProductCmBox() // Method to load products into Stock In/Out ComboBoxes
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = "SELECT ProductID, ProductName FROM Products";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CmBoxInPro.DataSource = dt;
                CmBoxInPro.DisplayMember = "ProductName";
                CmBoxInPro.ValueMember = "ProductID";
                CmBoxInPro.SelectedIndex = -1;

                CmBoxOutPro.DataSource = dt.Copy();
                CmBoxOutPro.DisplayMember = "ProductName";
                CmBoxOutPro.ValueMember = "ProductID";
                CmBoxOutPro.SelectedIndex = -1;
            }
        }

        private void LoadSupplierCmBox() // Method to load suppliers into Stock In ComboBox
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = "SELECT SupplierID, SupplierName FROM Suppliers";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CmBoxInSup.DataSource = dt;
                CmBoxInSup.DisplayMember = "SupplierName";
                CmBoxInSup.ValueMember = "SupplierID";
                CmBoxInSup.SelectedIndex = -1;
            }
        }

        private void LoadInventory() // Method to load inventory movements into DataGridView
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT p.ProductName,
                                        'IN' AS Type,
                                         si.QuantityAdded,
                                         p.Quantity AS CurrentStock,
                                         si.DateReceived AS Date,
                                         s.SupplierName

                                FROM STOCK_IN si
                                JOIN Products p ON si.ProductID = p.ProductID
                                JOIN Suppliers s ON si.SupplierID = s.SupplierID
                                WHERE p.IsDeleted = 0

                                UNION ALL

                                SELECT p.ProductName,
                                       'OUT' AS Type,
                                       so.QuantityRemoved,
                                       p.Quantity AS CurrentStock,    
                                       so.DateReleased AS Date,
                                      'N/A' AS SupplierName

                                FROM STOCK_OUT so
                                JOIN Products p ON so.ProductID = p.ProductID
                                WHERE p.IsDeleted = 0

                                ORDER BY Date DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DgvStock.DataSource = dt;
                DgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadReport(DateTime from, DateTime to) // Method to load all stock movement report based on date range
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT p.ProductName,
                                        'IN' AS Type,
                                         si.QuantityAdded,
                                         p.Quantity AS CurrentStocks,
                                         si.DateReceived AS Date,
                                         s.SupplierName

                                FROM STOCK_IN si
                                JOIN Products p ON si.ProductID = p.ProductID
                                JOIN Suppliers s ON si.SupplierID = s.SupplierID
                                WHERE si.DateReceived BETWEEN @from AND @to AND p.IsDeleted = 0

                                UNION ALL

                                SELECT p.ProductName,
                                       'OUT' AS Type,
                                       so.QuantityRemoved,
                                       p.Quantity AS CurrentStocks,
                                       so.DateReleased AS Date,
                                      'N/A' AS SupplierName

                                FROM STOCK_OUT so
                                JOIN Products p ON so.ProductID = p.ProductID
                                WHERE so.DateReleased BETWEEN @from AND @to AND p.IsDeleted = 0

                                ORDER BY Date DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@from", from);
                da.SelectCommand.Parameters.AddWithValue("@to", to);

                DataTable dt = new DataTable();
                da.Fill(dt);

                int totalIn = 0;
                int totalOut = 0;
                HashSet<string> products = new HashSet<string>();

                foreach (DataRow row in dt.Rows)
                {
                    string? type = row["Type"].ToString();
                    int qty = Convert.ToInt32(row["CurrentStocks"]);
                    string? product = row["ProductName"].ToString();

                    if (product != null)
                    {
                        products.Add(product);
                    }

                    if (type == "IN") totalIn += qty;
                    else if (type == "OUT") totalOut += qty;
                }

                LblTotalProd.Text = "Total Records " + dt.Rows.Count;
                LblTotalIn.Text = "Total Stock In: " + totalIn;
                LblTotalOut.Text = "Total Stock Out: " + totalOut;

                DgvRep.DataSource = dt;
                DgvRep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadStockInReport(DateTime from, DateTime to) // Method to load stock in report based on date range
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT p.ProductName,
                                        'IN' AS Type,
                                         si.QuantityAdded,
                                         p.Quantity AS CurrentStocks,
                                         si.DateReceived AS Date,
                                         s.SupplierName

                                FROM STOCK_IN si
                                JOIN Products p ON si.ProductID = p.ProductID
                                JOIN Suppliers s ON si.SupplierID = s.SupplierID
                                WHERE si.DateReceived BETWEEN @from AND @to AND p.IsDeleted = 0
                                ORDER BY Date DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@from", from);
                da.SelectCommand.Parameters.AddWithValue("@to", to);

                DataTable dt = new DataTable();
                da.Fill(dt);

                int total = 0;

                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToInt32(row["CurrentStocks"]);
                }

                LblTotalProd.Text = "Total Records: " + dt.Rows.Count;
                LblTotalIn.Text = "Total Stock In: " + total;
                LblTotalOut.Text = "Total Stock Out: 0";

                DgvRep.DataSource = dt;
                DgvRep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadStockOutReport(DateTime from, DateTime to) // Method to load stock out report based on date range
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT p.ProductName,
                                       'OUT' AS Type,
                                       so.QuantityRemoved,
                                       p.Quantity AS CurrentStocks,    
                                       so.DateReleased AS Date,
                                      'N/A' AS SupplierName

                                FROM STOCK_OUT so
                                JOIN Products p ON so.ProductID = p.ProductID
                                WHERE so.DateReleased BETWEEN @from AND @to AND p.IsDeleted = 0
                                ORDER BY Date DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@from", from);
                da.SelectCommand.Parameters.AddWithValue("@to", to);

                DataTable dt = new DataTable();
                da.Fill(dt);

                int total = 0;

                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToInt32(row["CurrentStocks"]);
                }

                LblTotalProd.Text = "Total Records: " + dt.Rows.Count;
                LblTotalIn.Text = "Total Stock In: 0";
                LblTotalOut.Text = "Total Stock Out: " + total;
                DgvRep.DataSource = dt;
                DgvRep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadAllStocks() // Method to load all stocks into report
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT ProductName, Quantity AS CurrentStocks, UnitPrice                
                            FROM Products
                            ORDER BY ProductName";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                LblTotalProd.Text = "Total Products: " + dt.Rows.Count;
                LblTotalIn.Text = "";
                LblTotalOut.Text = "";

                DgvRep.DataSource = dt;
                DgvRep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadHighStock() // Method to load products with high stock (items with quantity >= 50) into report
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT ProductName, Quantity AS CurrentStocks, UnitPrice
                            FROM Products
                            WHERE Quantity >= 50
                            ORDER BY Quantity DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                LblTotalProd.Text = "High Stock Items: " + dt.Rows.Count;
                LblTotalIn.Text = "";
                LblTotalOut.Text = "";

                DgvRep.DataSource = dt;
                DgvRep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadLowStock() // Method to load products with low stock (items with quantity <= 20) into report
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT ProductName, Quantity AS CurrentStocks, UnitPrice
                            FROM Products
                            WHERE Quantity <= 20
                            ORDER BY Quantity ASC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                LblTotalProd.Text = "Low Stock Items: " + dt.Rows.Count;
                LblTotalIn.Text = "";
                LblTotalOut.Text = "";

                DgvRep.DataSource = dt;
                DgvRep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadRecentOrders() // Method to load recent stock movements (both in and out and last 10 records) into dashboard
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT TOP 10 p.ProductName,
                                              'IN' AS Type,
                                               si.QuantityAdded AS Quantity,
                                               si.DateReceived AS Date
                               FROM STOCK_IN si
                               JOIN Products p ON si.ProductID = p.ProductID

                          UNION ALL
                                 SELECT TOP 10 p.ProductName,
                                              'OUT' AS Type,
                                               so.QuantityRemoved AS Quantity,
                                               so.DateReleased AS Date

                               FROM STOCK_OUT so
                               JOIN Products p ON so.ProductID = p.ProductID
                               ORDER BY Date DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DgvRecent.DataSource = dt;
                DgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadLowStockDashboard() // Method to load products with low stock (items with quantity <= 20) into low stock section of dashboard
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT ProductName,
                                        Quantity,
                                        UnitPrice
                                 FROM Products
                                 WHERE Quantity <= 20
                                 ORDER BY Quantity ASC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DgvLowStock.DataSource = dt;
                DgvLowStock.DefaultCellStyle.ForeColor = Color.Black;
                DgvLowStock.DefaultCellStyle.SelectionForeColor = Color.Black;
                DgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void SearchProducts(string keyword) // Method to search products based on keyword matching in product name, category name, price, quantity, or product ID
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT p.ProductID,
                                        p.ProductName,
                                        p.CategoryID,
                                        c.CategoryName,
                                        p.UnitPrice,
                                        p.Quantity,
                                        p.DateAdded

                                 FROM Products p
                                 LEFT JOIN Categories c ON p.CategoryID = c.CategoryID

                                 WHERE IsDeleted = 0 AND (p.ProductName LIKE @key OR
                                       c.CategoryName LIKE @key OR
                                       CAST(p.UnitPrice AS NVARCHAR) LIKE @key OR
                                       CAST(p.Quantity AS NVARCHAR) LIKE @key OR
                                       CAST(p.ProductID AS NVARCHAR) LIKE @key)";


                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@key", "%" + keyword + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                DgvProducts.DataSource = dt;
            }
        }

        private void SearchSuppliers(string keyword) // Method to search suppliers based on keyword matching in supplier name, contact number, email, address, or supplier ID
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT SupplierID,
                                        SupplierName,
                                        ContactNumber,
                                        Email,
                                        Address
                                 FROM Suppliers

                                 WHERE IsDeleted = 0 AND (
                                        SupplierName LIKE @key OR
                                        ContactNumber LIKE @key OR
                                        Email LIKE @key OR
                                        Address LIKE @key OR
                                        CAST(SupplierID AS NVARCHAR) LIKE @key)";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@key", "%" + keyword + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSuppliers.DataSource = dt;
            }
        }

        private void SearchInventory(string keyword) // Method to search inventory movements based on keyword matching in product name, type (in/out), quantity, date, or product ID
        {
            using (SqlConnection con = new SqlConnection(DB.conStr))
            {
                string query = @"SELECT p.ProductName,
                                       'IN' AS Type,
                                        si.QuantityAdded,
                                        p.Quantity,
                                        si.DateReceived AS Date,
                                        s.SupplierName,
                                        p.ProductID

                                FROM STOCK_IN si
                                JOIN Products p ON si.ProductID = p.ProductID
                                JOIN Suppliers s ON si.SupplierID = s.SupplierID

                                UNION ALL

                                SELECT p.ProductName,
                                       'OUT' AS Type,
                                       so.QuantityRemoved,
                                       p.Quantity,
                                       so.DateReleased AS Date,
                                       'N/A' AS SupplierName,
                                       p.ProductID
                     
                                FROM STOCK_OUT so
                                JOIN Products p ON so.ProductID = p.ProductID";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataView dv = dt.DefaultView;

                dv.RowFilter = $@"ProductName LIKE '%{keyword}%' OR
                                  Type LIKE '%{keyword}%' OR
                                  SupplierName LIKE '%{keyword}%' OR
                                  CONVERT(Quantity, 'System.String') LIKE '%{keyword}%' OR
                                  CONVERT(Date, 'System.String') LIKE '%{keyword}%' OR
                                  CONVERT(ProductID, 'System.String') LIKE '%{keyword}%'";

                    DgvStock.DataSource = dv;
                    DgvStock.Columns["ProductID"]?.Visible = false;
                    DgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e) // Method to add new product to database
        {
            try
            {
                if (TxtProduct.Text == "" || TxtPrice.Text == "" || CmBoxCategory.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill all fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show(
                "Are you sure you want to add this product?",
                "Confirm Add",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(DB.conStr))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Products (ProductName, CategoryID, Quantity, UnitPrice) VALUES (@n, @c, 0, @p)", con);

                        cmd.Parameters.AddWithValue("@n", TxtProduct.Text);
                        cmd.Parameters.AddWithValue("@c", CmBoxCategory.SelectedValue);
                        cmd.Parameters.AddWithValue("@p", decimal.Parse(TxtPrice.Text));

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Product added successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product:\n" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadProducts();
            LoadSuppliers();
            LoadCategories();
            LoadProductCmBox();
            LoadSupplierCmBox();
            LoadInventory();
            LoadRecentOrders();
            LoadLowStockDashboard();
        }

        private void BtnAdd2_Click(object sender, EventArgs e) // Method to add new supplier to database
        {
            try
            {
                if (TxtSupp.Text == "" || TxtAddr.Text == "" || TxtContact.Text == "" || TxtEmail.Text == "")
                {
                    MessageBox.Show("Please enter all supplier details.", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (TxtContact.Text.Length != 12)
                {
                    MessageBox.Show("Enter a valid PH number (63XXXXXXXXXX)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult result = MessageBox.Show(
                "Are you sure you want to add this supplier?",
                "Confirm Add",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(DB.conStr))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Suppliers (SupplierName, ContactNumber, Email, Address) VALUES (@n, @c, @e, @a)", con);

                        cmd.Parameters.AddWithValue("@n", TxtSupp.Text);
                        cmd.Parameters.AddWithValue("@c", TxtContact.Text);
                        cmd.Parameters.AddWithValue("@e", TxtEmail.Text);
                        cmd.Parameters.AddWithValue("@a", TxtAddr.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Supplier added successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding supplier:\n" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadProducts();
            LoadSuppliers();
            LoadCategories();
            LoadProductCmBox();
            LoadSupplierCmBox();
            LoadInventory();
            LoadRecentOrders();
            LoadLowStockDashboard();
        }

        private void BtnAddStock_Click(object sender, EventArgs e) // Method to add stock to inventory and update product quantity in database
        {
            try
            {
                if (CmBoxInPro.SelectedIndex == -1 || CmBoxInSup.SelectedIndex == -1 || TxtInQuanti.Text == "")
                {
                    MessageBox.Show("Fill all fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int productId = Convert.ToInt32(CmBoxInPro.SelectedValue);
                int supplierId = Convert.ToInt32(CmBoxInSup.SelectedValue);
                int qty = int.Parse(TxtInQuanti.Text);

                DialogResult result = MessageBox.Show(
                "Are you sure you want to add stocks for this product?",
                "Confirm Add",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(DB.conStr))
                    {
                        con.Open();

                        SqlTransaction trans = con.BeginTransaction();

                        try
                        {
                            SqlCommand cmd1 = new SqlCommand(
                                @"INSERT INTO STOCK_IN 
                            (ProductID, QuantityAdded, SupplierID, DateReceived, RecordedBy) 
                            VALUES (@p, @q, @s, GETDATE(), @u)",
                                con, trans);

                            cmd1.Parameters.AddWithValue("@p", productId);
                            cmd1.Parameters.AddWithValue("@q", qty);
                            cmd1.Parameters.AddWithValue("@s", supplierId);
                            cmd1.Parameters.AddWithValue("@u", Session.UserID);

                            cmd1.ExecuteNonQuery();

                            SqlCommand cmd2 = new SqlCommand(
                                @"UPDATE Products 
                            SET Quantity = Quantity + @q 
                            WHERE ProductID = @p",
                                con, trans);

                            cmd2.Parameters.AddWithValue("@q", qty);
                            cmd2.Parameters.AddWithValue("@p", productId);

                            cmd2.ExecuteNonQuery();

                            trans.Commit();

                            MessageBox.Show("Stock added!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exTrans)
                        {
                            trans.Rollback();
                            MessageBox.Show("Transaction failed:\n" + exTrans.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadProducts();
            LoadSuppliers();
            LoadCategories();
            LoadProductCmBox();
            LoadSupplierCmBox();
            LoadInventory();
            LoadRecentOrders();
            LoadLowStockDashboard();
        }

        private void BtnDel1_Click(object sender, EventArgs e) // Method to soft delete product from database (moves to trash bin)
        {
            try
            {
                if (!IsRowSelectedP)
                {
                    MessageBox.Show("Please select a product first.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = Convert.ToInt32(DgvProducts.CurrentRow?.Cells["ProductID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this product?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(DB.conStr))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Products SET IsDeleted = 1 WHERE ProductID=@id", con);

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Product deleted successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product:\n" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadProducts();
            LoadSuppliers();
            LoadCategories();
            LoadProductCmBox();
            LoadSupplierCmBox();
            LoadInventory();
            LoadRecentOrders();
            LoadLowStockDashboard();
        }

        private void BtnDelSupp_Click(object sender, EventArgs e) // Method to soft delete supplier from database (moves to trash bin)
        {
            try
            {
                if (!IsRowSelectedS)
                {
                    MessageBox.Show("Please select a supplier first.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = Convert.ToInt32(DgvProducts.CurrentRow?.Cells["SupplierID"].Value);

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this supplier?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(DB.conStr))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Suppliers SET IsDeleted = 1 WHERE SupplierID=@id", con);

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Supplier deleted successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting supplier:\n" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadProducts();
            LoadSuppliers();
            LoadCategories();
            LoadProductCmBox();
            LoadSupplierCmBox();
            LoadInventory();
            LoadRecentOrders();
            LoadLowStockDashboard();
        }

        private void BtnRmStock_Click(object sender, EventArgs e) // Method to remove stock from inventory and update product quantity in database
        {
            try
            {
                if (CmBoxOutPro.SelectedIndex == -1 || TxtOutQuanti.Text == "")
                {
                    MessageBox.Show("Fill all fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int productId = Convert.ToInt32(CmBoxOutPro.SelectedValue);
                int qty = int.Parse(TxtOutQuanti.Text);

                DialogResult result = MessageBox.Show(
                "Are you sure you want to remove stocks for this product?",
                "Confirm remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(DB.conStr))
                    {
                        con.Open();

                        SqlTransaction trans = con.BeginTransaction();

                        try
                        {
                            SqlCommand checkCmd = new SqlCommand(
                                "SELECT Quantity FROM Products WHERE ProductID=@p",
                                con, trans);

                            checkCmd.Parameters.AddWithValue("@p", productId);

                            int currentStock = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (qty > currentStock)
                            {
                                MessageBox.Show("Not enough stock!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                trans.Rollback();
                                return;
                            }

                            SqlCommand cmd1 = new SqlCommand(
                                @"INSERT INTO STOCK_OUT 
                                (ProductID, QuantityRemoved, DateReleased, RecordedBy) 
                            VALUES (@p, @q, GETDATE(), @u)",
                                con, trans);

                            cmd1.Parameters.AddWithValue("@p", productId);
                            cmd1.Parameters.AddWithValue("@q", qty);
                            cmd1.Parameters.AddWithValue("@u", Session.UserID);

                            cmd1.ExecuteNonQuery();

                            SqlCommand cmd2 = new SqlCommand(
                                @"UPDATE Products 
                                SET Quantity = Quantity - @q 
                            WHERE ProductID=@p",
                                con, trans);

                            cmd2.Parameters.AddWithValue("@q", qty);
                            cmd2.Parameters.AddWithValue("@p", productId);

                            cmd2.ExecuteNonQuery();

                            trans.Commit();

                            MessageBox.Show("Stock removed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exTrans)
                        {
                            trans.Rollback();
                            MessageBox.Show("Transaction failed:\n" + exTrans.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadProducts();
            LoadSuppliers();
            LoadCategories();
            LoadProductCmBox();
            LoadSupplierCmBox();
            LoadInventory();
            LoadRecentOrders();
            LoadLowStockDashboard();
        }

        private void BtnUpd1_Click(object sender, EventArgs e) // Method to update selected product's details in database
        {
            try
            {
                if (DgvProducts.CurrentRow == null)
                {
                    MessageBox.Show("Please select a product first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = Convert.ToInt32(DgvProducts.CurrentRow.Cells["ProductID"].Value);

                DialogResult result = MessageBox.Show(
                "Are you sure you want to update this product?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(DB.conStr))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Products SET ProductName=@n, CategoryID=@c, UnitPrice=@p WHERE ProductID=@id", con);

                        cmd.Parameters.AddWithValue("@n", TxtProduct.Text);
                        cmd.Parameters.AddWithValue("@c", CmBoxCategory.SelectedValue);
                        cmd.Parameters.AddWithValue("@p", decimal.Parse(TxtPrice.Text));
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product:\n" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadProducts();
            LoadSuppliers();
            LoadCategories();
            LoadProductCmBox();
            LoadSupplierCmBox();
            LoadInventory();
            LoadRecentOrders();
            LoadLowStockDashboard();
        }

        private void BtnUpdSupp_Click(object sender, EventArgs e) // Method to update selected supplier's details in database
        {
            try
            {
                if (dgvSuppliers.CurrentRow == null)
                {
                    MessageBox.Show("Please select a supplier first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = Convert.ToInt32(dgvSuppliers.CurrentRow.Cells["SupplierID"].Value);

                DialogResult result = MessageBox.Show(
                "Are you sure you want to update this supplier?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(DB.conStr))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Suppliers SET SupplierName=@n, ContactNumber=@c, Email=@e, Address=@a WHERE SupplierID=@id", con);

                        cmd.Parameters.AddWithValue("@n", TxtSupp.Text);
                        cmd.Parameters.AddWithValue("@c", TxtContact.Text);
                        cmd.Parameters.AddWithValue("@e", TxtEmail.Text);
                        cmd.Parameters.AddWithValue("@a", TxtAddr.Text);
                        cmd.Parameters.AddWithValue("@id", id);

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating supplier:\n" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadProducts();
            LoadSuppliers();
            LoadCategories();
            LoadProductCmBox();
            LoadSupplierCmBox();
            LoadInventory();
            LoadRecentOrders();
            LoadLowStockDashboard();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e) // Method to fill product details into input fields when a product is selected in DataGridView
        {
            if (e.RowIndex >= 0)
            {
                IsRowSelectedP = true;
            }

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DgvProducts.Rows[e.RowIndex];

                TxtProduct.Text = row.Cells["ProductName"].Value?.ToString() ?? "";
                TxtPrice.Text = row.Cells["UnitPrice"].Value?.ToString() ?? "";

                object? categoryValue = row.Cells["CategoryID"].Value;
                if (categoryValue != null && categoryValue != DBNull.Value)
                {
                    CmBoxCategory.SelectedValue = categoryValue;
                }
                else
                {
                    CmBoxCategory.SelectedIndex = -1;
                }
            }
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e) // Method to fill supplier details into input fields when a supplier is selected in DataGridView
        {
            if (e.RowIndex >= 0)
            {
                IsRowSelectedS = true;
            }

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];

                TxtSupp.Text = row.Cells["SupplierName"].Value?.ToString() ?? "";
                TxtAddr.Text = row.Cells["Address"].Value?.ToString() ?? "";
                TxtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                TxtContact.Text = row.Cells["ContactNumber"].Value?.ToString() ?? "";
            }
        }

        private void BtnCleSupp_Click(object sender, EventArgs e) // Method to clear supplier input fields
        {
            TxtSupp.Clear();
            TxtContact.Clear();
            TxtEmail.Clear();
            TxtAddr.Clear();
            TxtSrcSup.Clear();
            IsRowSelectedS = false;
            dgvSuppliers.ClearSelection();
            dgvSuppliers.CurrentCell = null;
        }

        private void BtnCleStock_Click(object sender, EventArgs e) // Method to clear inventory input fields
        {
            TxtInQuanti.Clear();
            TxtOutQuanti.Clear();
            TxtSrcStock.Clear();
            CmBoxInPro.SelectedIndex = -1;
            CmBoxOutPro.SelectedIndex = -1;
            CmBoxInSup.SelectedIndex = -1;
            DgvStock.ClearSelection();
        }

        private void BtnClr1_Click(object sender, EventArgs e) // Method to clear product input fields
        {
            TxtProduct.Clear();
            TxtPrice.Clear();
            TxtSrcPro.Clear();
            CmBoxCategory.SelectedIndex = -1;
            IsRowSelectedP = false;
            DgvProducts.ClearSelection();
            DgvProducts.CurrentCell = null;
        }

        private void BtnRfrSupp_Click(object sender, EventArgs e) // Method to refresh suppliers data in DataGridView
        {
            LoadSuppliers();
        }

        private void BtnRfr1_Click(object sender, EventArgs e) // Method to refresh products data in DataGridView
        {
            LoadProducts();
            LoadCategories();
        }

        private void BtnRfrStock_Click(object sender, EventArgs e) // Method to refresh inventory data in DataGridView
        {
            LoadInventory();
            LoadProductCmBox();
            LoadSupplierCmBox();
        }

        private void BtnRef_Click(object sender, EventArgs e) // Method to refresh dashboard data in DataGridViews
        {
            LoadRecentOrders();
            LoadLowStockDashboard();
        }

        private void BtnSrc1_Click(object sender, EventArgs e) // Method to search products based on keyword entered in search box
        {
            SearchProducts(TxtSrcPro.Text);
        }


        private void BtnSrc2_Click(object sender, EventArgs e) // Method to search suppliers based on keyword entered in search box
        {
            SearchSuppliers(TxtSrcSup.Text);
        }


        private void BtnSrc3_Click(object sender, EventArgs e) // Method to search inventory movements based on keyword entered in search box
        {
            SearchInventory(TxtSrcStock.Text);
        }

        private void BtnGen_Click(object sender, EventArgs e) // Method to generate report based on selected report type and date range
        {
            try
            {
                string? selected = CmBoxRepType.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selected))
                {
                    MessageBox.Show("Please select a report type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DateTime from = DtFrom.Value.Date;
                DateTime to = DtTo.Value.Date.AddDays(1);

                switch (selected)
                {
                    case "All Stock Movement":
                        LoadReport(from, to);
                        break;

                    case "Stock In":
                        LoadStockInReport(from, to);
                        break;

                    case "Stock Out":
                        LoadStockOutReport(from, to);
                        break;

                    case "All Stocks":
                        LoadAllStocks();
                        break;

                    case "High Stocks":
                        LoadHighStock();
                        break;

                    case "Low Stocks":
                        LoadLowStock();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}