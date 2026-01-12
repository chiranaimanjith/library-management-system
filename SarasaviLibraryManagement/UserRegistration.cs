using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarasaviLibraryManagement
{
    public partial class UserRegistration : Form
    {
        public UserRegistration()
        {
            InitializeComponent();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUserNo.Text = "";
            txtName.Text = "";
            txtNIC.Text = "";
            //cmbSex.SelectedIndex = 0; 
            txtAddress.Text = "";

            txtUserNo.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text == "" ||
       txtName.Text == "" ||
       //cmbSex.SelectedIndex ==  ||
       txtNIC.Text == "" ||
       txtAddress.Text == "")
            {
                MessageBox.Show("Please fill all fields", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            User user = new User()
            {
                UserNumber = int.Parse(txtUserNo.Text),
                Name = txtName.Text,
                Sex = cmbSex.Text,
                NIC = txtNIC.Text,
                Address = txtAddress.Text
            };

            MessageBox.Show("User Registered Successfully",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
