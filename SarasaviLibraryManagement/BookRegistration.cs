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
            if (string.IsNullOrWhiteSpace(txtbk.Text) || string.IsNullOrWhiteSpace(txttitle.Text) || string.IsNullOrWhiteSpace(txtauthour.Text))
            {
                MessageBox.Show("Fill All The Details Before Submit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int numCopies;
            if (!int.TryParse(textstock.Text, out numCopies) || numCopies < 1 || numCopies > 10)
            {
                MessageBox.Show("Number of Copies must be a number between 1 and 10.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book book = new Book
            {
                Classification = cmbcl.Text,
                BookNumber = txtbk.Text.Trim(),
                Title = txttitle.Text.Trim(),
                Author = txtauthour.Text.Trim(),
                CopyType = cmbcopy.Text,
                NumberOfCopies = numCopies,
                AvailableCopies = numCopies,
                IsAvailable = numCopies > 0
            };

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO books 
        ( Classification, BookNumber, Title, Author, Publisher, CopyType, NumberOfCopies, AvailableCopies)
        VALUES 
        (@Classification, @BookNumber, @Title, @Author, @Publisher, @CopyType, @NumberOfCopies, @AvailableCopies)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Classification", book.Classification);
                        cmd.Parameters.AddWithValue("@BookNumber", book.BookNumber);
                        cmd.Parameters.AddWithValue("@Title", book.Title);
                        cmd.Parameters.AddWithValue("@Author", book.Author);
                        cmd.Parameters.AddWithValue("@CopyType", book.CopyType);

                        int copies = book.NumberOfCopies;

                        cmd.Parameters.AddWithValue("@NumberOfCopies", copies);
                        cmd.Parameters.AddWithValue("@AvailableCopies", copies);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Book saved successfully to database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearForm();
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
    }
}
