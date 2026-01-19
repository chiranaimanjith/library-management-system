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
    public partial class ReturnBook : Form
    {
        private string connectionString = "server=localhost;user=root;password=2004;database=library_db;";
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter all fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userNumber = textBox1.Text.Trim();
            string bookNumber = textBox2.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();


                    string checkQuery = @"
                SELECT LoanID, BookTitle 
                FROM Loans 
                WHERE UserNumber = @UserNumber 
                AND BookTitle = (SELECT Title FROM Books WHERE BookNumber = @BookNumber)";

                    int loanId;
                    string bookTitle;

                    using (MySqlCommand cmd = new MySqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserNumber", userNumber);
                        cmd.Parameters.AddWithValue("@BookNumber", bookNumber);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("This book is not currently loaned to this user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            loanId = reader.GetInt32("LoanID");
                            bookTitle = reader.GetString("BookTitle");
                        }
                    }


                    string deleteQuery = "DELETE FROM Loans WHERE LoanID = @LoanID";
                    using (MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, conn))
                    {
                        cmdDelete.Parameters.AddWithValue("@LoanID", loanId);
                        cmdDelete.ExecuteNonQuery();
                    }


                    string updateQuery = "UPDATE Books SET AvailableCopies = AvailableCopies + 1 WHERE BookNumber = @BookNumber";
                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@BookNumber", bookNumber);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Book returned successfully!\nTitle: {bookTitle}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error returning book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
