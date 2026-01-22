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
    public partial class UserLogin : Form
    {
        string connectionString = "server=localhost;user=root;password=2004;database=library_db;";
        public UserLogin()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserForgotPassword us = new UserForgotPassword();
            us.Show();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtpassword.Text == "")
            {
                MessageBox.Show("Please enter Username and Password");
                return;
            }

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT * FROM members WHERE username=@username AND password=@password";
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@username", txtusername.Text);
                    cmd.Parameters.AddWithValue("@password", txtpassword.Text);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        MessageBox.Show("Login Successful");

                        UserDashboard ud = new UserDashboard();
                        ud.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (txtusername.Text == "" || txtpassword.Text == "")
                {
                    MessageBox.Show("Please enter Username and Password");
                    return;
                }

                try
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();

                        string query = "SELECT * FROM members WHERE username=@username AND password=@password";
                        MySqlCommand cmd = new MySqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@password", txtpassword.Text);

                        MySqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            MessageBox.Show("Login Successful");

                            UserDashboard ud = new UserDashboard();
                            ud.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password");
                        }
                    }
                }
                catch (Exception innerEx)
                {
                    MessageBox.Show("Error: " + innerEx.Message);
                }
            }
        }
        private void UserLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
