using static System.Windows.Forms.DataFormats;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace InventorySystem
{
    public partial class LoginForm : Form
    {
        public static class Session // public static class to store session data (who accessed the system?)
        {
            public static int UserID = -1;
            public static string Username = "";
            public static string Role = "";
        }

        public LoginForm()
        {

            InitializeComponent();
            this.AcceptButton = BtnLog;
            TxtPas.UseSystemPasswordChar = true;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnCle_Click(object sender, EventArgs e)
        {

            TxtPas.Text = "";
            TxtUse.Text = "";

        }

        private void BtnLog_Click(object sender, EventArgs e)
        {
            string username = TxtUse.Text.Trim();
            string password = TxtPas.Text.Trim();

            // Detects if user inputs an empty string for username and password
            if (TxtUse.Text == "" || TxtPas.Text == "")
            {
                MessageBox.Show("Please enter username and password", "Warning!",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(DB.conStr))
                {
                    con.Open(); // Opens DB connection

                    // Compares the inputted username and password with the database records
                    SqlCommand cmd = new SqlCommand(
                        "SELECT UserID, Username, Role FROM Users WHERE Username=@u AND PasswordHash=@p",
                        con);

                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        // Stores session data (who accessed the system?)
                        Session.UserID = Convert.ToInt32(dr["UserID"]);
                        Session.Username = dr["Username"]?.ToString() ?? "";
                        Session.Role = dr["Role"]?.ToString() ?? "";

                        MessageBox.Show("Login Successful!", "Success!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Opens Inventory Form
                        Inventory dashboard = new Inventory();
                        dashboard.Show();
                        this.Hide();
                    }
                    else // If the username and password do not match any record in the database, an error message is displayed
                    {
                        MessageBox.Show("Invalid Username or Password", "Error!",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                        TxtPas.Clear();
                        TxtPas.Focus();
                    }
                }
            }
            catch (Exception ex) // if try fails do this
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void ChkPass_CheckedChanged(object sender, EventArgs e)
        {
            TxtPas.UseSystemPasswordChar = !ChkPass.Checked;

            if (ChkPass.Checked)
            {
                TxtPas.UseSystemPasswordChar = false;
            }
            else
            {
                TxtPas.UseSystemPasswordChar = true;
            }
        }
        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }

        private void LblSig_Click(object sender, EventArgs e)
        {

        }

        private void LblExt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to Exit?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void LblExt_MouseEnter(object sender, EventArgs e)
        {
            LblExt.BackColor = Color.Crimson;
            LblExt.ForeColor = Color.Black;
        }

        private void LblExt_MouseHover(object sender, EventArgs e)
        {
            LblExt.BackColor = Color.Crimson;
            LblExt.ForeColor = Color.Black;
        }

        private void LblExt_MouseLeave(object sender, EventArgs e)
        {
            LblExt.BackColor = Color.White;
            LblExt.ForeColor = Color.Red;
        }

        private void TxtPas_TextChanged(object sender, EventArgs e)
        {

        }
    }
}