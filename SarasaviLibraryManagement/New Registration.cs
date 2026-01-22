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
    public partial class New_Registration : Form
    {
        string connectionString = "server=localhost;user=root;password=2004;database=library_db;";

        public New_Registration()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = "INSERT INTO members (username, email, password) " +
                                   "VALUES (@username, @email, @password)";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registration Successful");

                    txtUsername.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
