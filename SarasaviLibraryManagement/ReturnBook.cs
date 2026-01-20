using System;

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
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter User Number and Book Number",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string userNumber = textBox1.Text.Trim();
            string bookNumber = textBox2.Text.Trim();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    int loanId = 0;
                    string bookTitle = "";

                    // 1️⃣ Get Book Title using BookNumber
                    string titleQuery = "SELECT Title FROM Books WHERE BookNumber = @BookNumber";
                    using (MySqlCommand cmdTitle = new MySqlCommand(titleQuery, conn))
                    {
                        cmdTitle.Parameters.AddWithValue("@BookNumber", bookNumber);
                        object result = cmdTitle.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Book not found!",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        bookTitle = result.ToString();
                    }

                    // 2️⃣ Check loan exists
                    string checkLoanQuery = @"
                        SELECT LoanID 
                        FROM Loans 
                        WHERE UserNumber = @UserNumber 
                        AND BookTitle = @BookTitle";

                    using (MySqlCommand cmdCheck = new MySqlCommand(checkLoanQuery, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@UserNumber", userNumber);
                        cmdCheck.Parameters.AddWithValue("@BookTitle", bookTitle);

                        object loanResult = cmdCheck.ExecuteScalar();
                        if (loanResult == null)
                        {
                            MessageBox.Show("This book is not loaned to this user",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }

                        loanId = Convert.ToInt32(loanResult);
                    }

                    // 3️⃣ Delete from Loans
                    string deleteQuery = "DELETE FROM Loans WHERE LoanID = @LoanID";
                    using (MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, conn))
                    {
                        cmdDelete.Parameters.AddWithValue("@LoanID", loanId);
                        cmdDelete.ExecuteNonQuery();
                    }

                    // 4️⃣ Increase stock in Books
                    string updateQuery =
                        "UPDATE Books SET StockQuantity = StockQuantity + 1 WHERE BookNumber = @BookNumber";
                    using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@BookNumber", bookNumber);
                        cmdUpdate.ExecuteNonQuery();
                    }

                    MessageBox.Show(
                        $"Book returned successfully!\nTitle: {bookTitle}",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error returning book: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    


private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();  
            textBox2.Clear();
        }
    }
}
