using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SarasaviLibraryManagement
{
    public partial class UserForgotPassword : Form
    {
        string connectionString = "server=localhost;user=root;password=2004;database=library_db;";
        public UserForgotPassword()
        {
            InitializeComponent();
        }

        private void UserForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" ||
       txtEmail.Text.Trim() == "" ||
       txtNewPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                using (MySqlConnection con = new MySqlConnection(
                    "server=localhost;user=root;password=2004;database=library_db;"))
                {
                    con.Open();

                    string checkQuery =
                        "SELECT COUNT(*) FROM members " +
                        "WHERE LOWER(username) = LOWER(@username) " +
                        "AND LOWER(email) = LOWER(@email)";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, con);
                    checkCmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        string updateQuery =
                            "UPDATE members SET password=@password WHERE username=@username";

                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, con);
                        updateCmd.Parameters.AddWithValue("@password", txtNewPassword.Text.Trim());
                        updateCmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());

                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Password updated successfully");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username and Email do not match");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
