using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SarasaviLibraryManagement
{
    public partial class UserRegistration : Form
    {
        private string connectionString = "server=localhost;user=root;password=2004;database=library_db;";
        private TextBox txtUserNumber;
        private Panel panel4;

        public UserRegistration(lbs main)
        {
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUserNo.Clear();
            txtName.Clear();
            cmbSex.SelectedIndex = -1;
            txtNIC.Clear();
            txtAddress.Clear();
            txtUserNo.Focus();
            cmbUserType.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserNo.Text) ||
        string.IsNullOrWhiteSpace(txtName.Text) ||
        string.IsNullOrWhiteSpace(txtNIC.Text) ||
        string.IsNullOrWhiteSpace(txtAddress.Text) ||
        string.IsNullOrWhiteSpace(cmbSex.Text) ||
        string.IsNullOrWhiteSpace(cmbUserType.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    string query = @"INSERT INTO users
                            (UserNumber, Name, Sex, NIC, Address, UserType)
                            VALUES
                            (@UserNumber, @Name, @Sex, @NIC, @Address, @UserType)";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserNumber", txtUserNo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Sex", cmbSex.Text);
                        cmd.Parameters.AddWithValue("@NIC", txtNIC.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@UserType", cmbUserType.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User registered successfully ✅");

                txtUserNo.Clear();
                txtName.Clear();
                txtNIC.Clear();
                txtAddress.Clear();
                cmbSex.SelectedIndex = -1;
                cmbUserType.SelectedIndex = -1;
                txtUserNo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BackToPrevious(panel4);
        }

        private void txtUserNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbl4_Click(object sender, EventArgs e)
        {

        }

        private void cmbSex_SelectedIndexChanged(object sender, EventArgs e)

        {
        }

        private void UserRegistration_Load(object sender, EventArgs e)
        {
            cmbSex.Items.Add("Male");
            cmbSex.Items.Add("Female");
            cmbSex.Items.Add("Other");

            cmbUserType.Items.Add("Member");
            cmbUserType.Items.Add("Visitor");

            cmbSex.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUserType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void UserRegistration_Load_1(object sender, EventArgs e)
        {

        }

        private void BackToPrevious(Panel panel)
        {
            this.Hide();
            this.Close();
        }
    }
}
