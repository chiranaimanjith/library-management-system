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
    public partial class LoanBook : Form
    {
        public static List<Loan> LoanList = new List<Loan>();
        private string connectionString = "server=localhost;user=root;password=2004;database=library_db;";
        private MySqlConnection con;
        private bool isUserVerified = false;
        private TextBox txtUserNumber => txtun;
        private int verifiedUserID;
        public LoanBook()
        {
            InitializeComponent();
            LoadBooks();


            dateTimeexpedcted.MaxDate = new DateTime(2026, 12, 31);
            DateTime defaultDate = DateTime.Today.AddDays(14);
            if (defaultDate < dateTimeexpedcted.MinDate)
            {
                defaultDate = dateTimeexpedcted.MinDate;
            }
            dateTimeexpedcted.Value = defaultDate;
            dateTimeexpedcted.Format = DateTimePickerFormat.Long;
        }


        private void LoadBooks()
        {
            dgvBooksToLoan.Rows.Clear();
            dgvBooksToLoan.Columns.Clear();


            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "Select";
            checkColumn.Name = "Select";
            checkColumn.Width = 50;
            dgvBooksToLoan.Columns.Add(checkColumn);


            dgvBooksToLoan.Columns.Add("Title", "Title");
            dgvBooksToLoan.Columns.Add("ItemType", "ItemType");
            dgvBooksToLoan.Columns.Add("StockQuantity", "StockQuantity");

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Title, ItemType, StockQuantity FROM Books";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader.GetString("Title");
                            string ItemType = reader.GetString("ItemType");
                            int StockQuantity = reader.GetInt32("StockQuantity");

                            dgvBooksToLoan.Rows.Add(false, title, ItemType, StockQuantity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }

            dgvBooksToLoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnConfirmLoan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserNumber.Text))
            {
                MessageBox.Show("Please check user first.");
                return;
            }

            var rowsToLoan = dgvBooksToLoan.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells["Select"].Value) == true)
                .ToList();

            if (rowsToLoan.Count == 0)
            {
                MessageBox.Show("Please select at least one book to loan.");
                return;
            }

            if (!isUserVerified)
            {
                MessageBox.Show("Please verify user before loaning books.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (var row in rowsToLoan)
                    {
                        string title = row.Cells["Title"].Value.ToString();
                        string itemtype = row.Cells["CopyType"].Value.ToString();
                        int stockquantity = Convert.ToInt32(row.Cells["AvailableCopies"].Value);

                        if (itemtype.ToLower() == "reference")
                        {
                            MessageBox.Show("Reference books cannot be borrowed: " + title);
                            continue;
                        }

                        if (stockquantity <= 0)
                        {
                            MessageBox.Show("No available copies for: " + title);
                            continue;
                        }
                        int copyNo = 1;


                        string insertQuery = @"INSERT INTO Loans 
                         (UserNumber, CopyNumber, BookTitle, LoanDate, ExpectedReturnDate)
                         VALUES (@UserNumber, @CopyNumber, @BookTitle, @LoanDate, @ExpectedReturnDate)";

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserNumber", txtUserNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@CopyNumber", copyNo);
                            cmd.Parameters.AddWithValue("@BookTitle", title);
                            cmd.Parameters.AddWithValue("@LoanDate", DateTime.Today);
                            cmd.Parameters.AddWithValue("@ExpectedReturnDate", dateTimeexpedcted.Value.Date);

                            cmd.ExecuteNonQuery();
                        }

                        string updateQuery = "UPDATE Books SET StockQuantity = StockQuantity - 1 WHERE Title = @Title";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@Title", title);
                            cmdUpdate.Parameters.AddWithValue("@CopyNumber", copyNo);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        row.Cells["StockQuantity"].Value = stockquantity - 1;

                        MessageBox.Show("Book loaned successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving loan: " + ex.Message);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtun.Text))
            {
                MessageBox.Show("Please enter User Number");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE UserNumber=@UserNumber";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserNumber", txtun.Text.Trim());
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            isUserVerified = true;
                            MessageBox.Show("User verified successfully!");
                        }
                        else
                        {
                            isUserVerified = false;
                            MessageBox.Show("User not found!");
                            txtun.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking user: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserNumber.Text))
            {
                MessageBox.Show("Please check user first.");
                return;
            }

            if (!isUserVerified)
            {
                MessageBox.Show("Please verify user before loaning books.");
                return;
            }

            // Get selected rows
            var rowsToLoan = dgvBooksToLoan.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["Select"].Value != null && (bool)r.Cells["Select"].Value)
                .ToList();

            if (rowsToLoan.Count == 0)
            {
                MessageBox.Show("Please select at least one book to loan.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (var row in rowsToLoan)
                    {
                        string title = row.Cells["Title"].Value.ToString();
                        string itemType = row.Cells["ItemType"].Value.ToString();
                        int stockQuantity = Convert.ToInt32(row.Cells["StockQuantity"].Value);

                        if (itemType.Equals("Reference", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Reference books cannot be borrowed: " + title);
                            continue;
                        }

                        if (stockQuantity <= 0)
                        {
                            MessageBox.Show("No available copies for: " + title);
                            continue;
                        }

                        int copyNo = 1; 

                        string insertQuery = @"INSERT INTO Loans 
                    (UserNumber, CopyNumber, BookTitle, LoanDate, ExpectedReturnDate)
                    VALUES (@UserNumber, @CopyNumber, @BookTitle, @LoanDate, @ExpectedReturnDate)";

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserNumber", txtUserNumber.Text.Trim());
                            cmd.Parameters.AddWithValue("@CopyNumber", copyNo);
                            cmd.Parameters.AddWithValue("@BookTitle", title);
                            cmd.Parameters.AddWithValue("@LoanDate", DateTime.Today);
                            cmd.Parameters.AddWithValue("@ExpectedReturnDate", dateTimeexpedcted.Value.Date);
                            cmd.ExecuteNonQuery();
                        }

                        string updateQuery = "UPDATE Books SET StockQuantity = StockQuantity - 1 WHERE Title = @Title";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@Title", title);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        row.Cells["StockQuantity"].Value = stockQuantity - 1;
                    }

                    MessageBox.Show("Selected books loaned successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving loan: " + ex.Message);
            }
        }
    

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvBooksToLoan.Rows.Clear();
        }

        private void LoadLoanBook()
        {

        }

        private void dgvBooksToLoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoanBook_Load(object sender, EventArgs e)
        {

        }

        private void dateTimeexpedcted_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
