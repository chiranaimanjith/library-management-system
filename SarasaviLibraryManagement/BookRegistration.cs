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
using MySql.Data.MySqlClient;

namespace SarasaviLibraryManagement
{
    public partial class BookRegistration : Form
            {
        private string connectionString = "server=localhost;user=root;password=2004;database=library_db;";
        private TextBox txtUserNumber;
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
            if (string.IsNullOrWhiteSpace(txtbk.Text) ||
               string.IsNullOrWhiteSpace(txttitle.Text) ||
               string.IsNullOrWhiteSpace(txtauthour.Text) ||
               cmbcl.SelectedIndex == -1 ||
               cmbcopy.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please fill all fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textstock.Text, out int stock) || stock < 1)
            {
                MessageBox.Show(
                    "Stock quantity must be a positive number.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                     string checkQuery =
                        "SELECT COUNT(*) FROM books WHERE BookNumber = @BookNumber";

                    using (MySqlCommand checkCmd =
                        new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@BookNumber", txtbk.Text.Trim());

                        int exists =
                            Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (exists > 0)
                        {
                            MessageBox.Show(
                                "This Book Number already exists.",
                                "Duplicate Entry",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insertQuery = @"INSERT INTO books
                    (Classification, BookNumber, Title, Author, ItemType, StockQuantity)
                    VALUES
                    (@Classification, @BookNumber, @Title, @Author, @ItemType, @StockQuantity)";

                    using (MySqlCommand cmd =
                        new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Classification", cmbcl.Text);
                        cmd.Parameters.AddWithValue("@BookNumber", txtbk.Text.Trim());
                        cmd.Parameters.AddWithValue("@Title", txttitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Author", txtauthour.Text.Trim());
                        cmd.Parameters.AddWithValue("@ItemType", cmbcopy.Text);
                        cmd.Parameters.AddWithValue("@StockQuantity", stock);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Book saved successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"MySQL Error {ex.Number}\n{ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            cmbcl.SelectedIndex = -1;
            cmbcopy.SelectedIndex = -1;
            txtbk.Clear();
            txttitle.Clear();
            txtauthour.Clear();
            textstock.Clear();
            txtbk.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void txtBookNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
            }
        }
    }
}
