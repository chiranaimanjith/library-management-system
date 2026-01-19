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
        public LoanBook()
        {
            InitializeComponent();
            LoadLoanBook();

            dateTimeexpedcted = new DateTimePicker();
            dateTimeexpedcted.MinDate = DateTime.Today;
            this.Controls.Add(dateTimeexpedcted); 

            dateTimeexpedcted.MaxDate = new DateTime(2026, 12, 31);

            DateTime defaultDate = DateTime.Today.AddDays(14);
            if (defaultDate < dateTimeexpedcted.MinDate)
                defaultDate = dateTimeexpedcted.MinDate;

            dateTimeexpedcted.Value = defaultDate;
            dateTimeexpedcted.Format = DateTimePickerFormat.Long;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
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

            if (!dgvBooksToLoan.Columns.Contains("Select"))
            {
                MessageBox.Show("Select column not found.");
                return;
            }

            bool IsRowSelected(DataGridViewRow r)
            {
                if (r == null || r.IsNewRow)
                    return false;

                // Safe access to the "Select" cell
                DataGridViewCell cell;
                try
                {
                    cell = r.Cells["Select"];
                }
                catch
                {
                    return false;
                }

                if (cell == null)
                    return false;

                var val = cell.Value;
                if (val is bool b)
                    return b;

                if (val == null)
                    return false;

                bool parsed;
                return bool.TryParse(val.ToString(), out parsed) && parsed;
            }

            var rowsToLoan = dgvBooksToLoan.Rows
                .Cast<DataGridViewRow>()
                .Where(r => IsRowSelected(r))
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
                        // Safe reads with null checks and parsing
                        string title = row.Cells["Title"]?.Value?.ToString() ?? string.Empty;
                        string copyType = row.Cells["CopyType"]?.Value?.ToString() ?? string.Empty;

                        int available = 0;
                        var availableObj = row.Cells["AvailableCopies"]?.Value;
                        if (availableObj != null)
                            int.TryParse(availableObj.ToString(), out available);

                        if (string.Equals(copyType, "reference", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Reference books cannot be borrowed: " + title);
                            continue;
                        }

                        if (available <= 0)
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

                        string updateQuery = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE Title=@Title";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@Title", title);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        // Update grid safely
                        try
                        {
                            row.Cells["AvailableCopies"].Value = Math.Max(0, available - 1);
                        }
                        catch
                        {
                            // ignore UI update errors
                        }

                        MessageBox.Show("Books loaned successfully!");
                    }
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
    }
}
