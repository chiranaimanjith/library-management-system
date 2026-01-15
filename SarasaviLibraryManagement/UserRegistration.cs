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

namespace SarasaviLibraryManagement
{
    public partial class UserRegistration : Form
    {
        // Add this field to match the usage of txtUserNumber in the form
        private TextBox txtUserNumber;

        public UserRegistration()
        {
            InitializeComponent();

            // Ensure txtUserNumber is initialized if not done by designer
            if (txtUserNumber == null)
            {
                txtUserNumber = new TextBox();
                txtUserNumber.Name = "txtUserNumber";
                // Optionally, add to Controls if needed:
                // this.Controls.Add(txtUserNumber);
            }
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
            if (string.IsNullOrWhiteSpace(txtUserNumber.Text) ||
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
                using (SqlConnection con = DBConnection.GetConnection())
                {
                    string query = @"INSERT INTO users
                            (UserNumber, Name, Sex, NIC, Address, UserType)
                             VALUES
                            (@UserNumber, @Name, @Sex, @NIC, @Address, @UserType)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserNumber", txtUserNumber.Text.Trim());
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

                txtUserNumber.Clear();
                txtName.Clear();
                txtNIC.Clear();
                txtAddress.Clear();
                cmbSex.SelectedIndex = -1;
                cmbUserType.SelectedIndex = -1;
                txtUserNumber.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

            this.Hide();
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
    }
}
