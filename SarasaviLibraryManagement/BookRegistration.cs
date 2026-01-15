using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SarasaviLibraryManagement
{
    public partial class BookRegistration : Form
    {
        private object txtUserNo;

        public BookRegistration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmbcl.SelectedIndex = -1;
            cmbcopy.SelectedIndex = -1;

            txtbk.Clear();
            txttitle.Clear();
            txtauthour.Clear();
            textstock.Clear();
            txtbk.Focus();
            txttitle.Focus();
            txtauthour.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbcl.SelectedIndex == -1 ||
       txtbk.Text == "" ||
       txttitle.Text == "" ||
       txtauthour.Text == "" ||
       cmbcopy.SelectedIndex == -1 ||
       textstock.Text == "")
            {
                MessageBox.Show("Please fill all fields",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

             int stock;
            if (!int.TryParse(textstock.Text, out stock))
            {
                MessageBox.Show("Stock must be a number",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                textstock.Focus();
                return;
            }

            MessageBox.Show("Book Registered Successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
