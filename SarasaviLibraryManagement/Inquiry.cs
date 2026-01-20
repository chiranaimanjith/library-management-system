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
    public partial class Inquiry : Form
    {
        
        private TextBox txtUserNumber = null;
        
        private string connectionString = "server=localhost;user=root;password=2004;database=library_db;";

        public Inquiry()
        {
            InitializeComponent();
            
            this.txtUserNumber = this.searchText;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUserNumber.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = this.txtUserNumber.Text;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter User Number",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            dgvSearchResults.Rows.Clear();
            dgvSearchResults.Columns.Clear();

            try
            {
               using (MySqlConnection conn = new MySqlConnection(this.connectionString))
                {
                    conn.Open();

                    if (radioButtonUserId.Checked)
                    {
                        dgvSearchResults.Columns.Add("UserNumber", "User Number");
                        dgvSearchResults.Columns.Add("Name", "Name");
                        dgvSearchResults.Columns.Add("Sex", "Sex");
                        dgvSearchResults.Columns.Add("BookTitle", "Book Title");
                        dgvSearchResults.Columns.Add("LoanDate", "Loan Date");
                        dgvSearchResults.Columns.Add("ExpectedReturnDate", "Expected Return Date");

                        string query = @"
                    SELECT u.UserNumber, u.Name, u.Sex, l.BookTitle, l.LoanDate, l.ExpectedReturnDate
                    FROM Users u
                    LEFT JOIN Loans l ON u.UserNumber = l.UserNumber
                    WHERE u.UserNumber = @UserNumber";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserNumber", input);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                bool found = false;
                                while (reader.Read())
                                {
                                    found = true;
                                    dgvSearchResults.Rows.Add(
                                        reader["UserNumber"].ToString(),
                                        reader["Name"].ToString(),
                                        reader["Sex"].ToString(),
                                        reader["BookTitle"] == DBNull.Value ? "" : reader["BookTitle"].ToString(),
                                        reader["LoanDate"] == DBNull.Value ? "" : Convert.ToDateTime(reader["LoanDate"]).ToString("yyyy-MM-dd"),
                                        reader["ExpectedReturnDate"] == DBNull.Value ? "" : Convert.ToDateTime(reader["ExpectedReturnDate"]).ToString("yyyy-MM-dd")
                                    );
                                }
                                if (!found)
                                    MessageBox.Show("No user found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    else if (radioButtonBookId.Checked)
                    {
                        dgvSearchResults.Columns.Add("BookNumber", "Book ID");
                        dgvSearchResults.Columns.Add("Title", "Title");
                        dgvSearchResults.Columns.Add("ItemType", "Item Type");
                        dgvSearchResults.Columns.Add("StockQuantity", "Stock Quantity");

                        string query = "SELECT * FROM Books WHERE BookNumber = @BookNumber";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@BookNumber", input);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                bool found = false;
                                while (reader.Read())
                                {
                                    found = true;
                                    dgvSearchResults.Rows.Add(
                                        reader["BookNumber"].ToString(),
                                        reader["Title"].ToString(),
                                        reader["ItemType"].ToString(),
                                        reader["StockQuantity"].ToString()
                                    );
                                }
                                if (!found)
                                    MessageBox.Show("No book found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Inquiry_Load(object sender, EventArgs e)
        {

        }

        private void radioButtonBookId_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void searchText_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
