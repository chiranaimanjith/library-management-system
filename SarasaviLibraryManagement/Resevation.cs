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
    public partial class Resevation : Form
    {
        private string connectionString = "server=localhost;user=root;password=2004;database=library_db;";
        private bool isUserVerified = false;

        public Resevation()
        {
            InitializeComponent();
        }

        public static List<Resevation> ReservationList = new List<Resevation>();

        private void Reservation_Load(object sender, EventArgs e)
        {

        }


        private void LoadBooks()
        {
            dgvReservation.Rows.Clear();
            dgvReservation.Columns.Clear();


            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn();
            selectColumn.HeaderText = "Select";
            selectColumn.Name = "Select";
            selectColumn.Width = 50;
            dgvReservation.Columns.Add(selectColumn);


            dgvReservation.Columns.Add("BookNumber", "Book Number");
            dgvReservation.Columns.Add("Title", "Title");
            dgvReservation.Columns.Add("Author", "Author");
            dgvReservation.Columns.Add("StockQuantity", "StockQuantity");
           

            dgvReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BookNumber, Title, Author, StockQuantity FROM Books";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader.GetInt32("StockQuantity") > 0 ? "Available" : "Not Available";
                            dgvReservation.Rows.Add(false,
                                reader.GetString("BookNumber"),
                                reader.GetString("Title"),
                                reader.GetString("Author"),
                                reader.GetInt32("StockQuantity"),
                                status);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }

        
        private void Resevation_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isUserVerified)
            {
                MessageBox.Show("Verify user first!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRows = dgvReservation.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["Select"].Value != null && (bool)r.Cells["Select"].Value)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Select at least one book.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (var row in selectedRows)
                    {
                        string bookNumber = row.Cells["BookNumber"].Value.ToString();
                        int stock = Convert.ToInt32(row.Cells["StockQuantity"].Value);

                        if (stock <= 0)
                        {
                            MessageBox.Show($"Book {bookNumber} not available.");
                            continue;
                        }

                        // 🔍 Check duplicate reservation
                        string checkQuery = @"SELECT COUNT(*) FROM Reservations
                                      WHERE UserNumber=@UserNumber
                                      AND BookNumber=@BookNumber
                                      AND Status='Reserved'";
                        using (MySqlCommand chk = new MySqlCommand(checkQuery, conn))
                        {
                            chk.Parameters.AddWithValue("@UserNumber", textBox1.Text.Trim());
                            chk.Parameters.AddWithValue("@BookNumber", bookNumber);

                            if (Convert.ToInt32(chk.ExecuteScalar()) > 0)
                            {
                                MessageBox.Show($"Already reserved book {bookNumber}");
                                continue;
                            }
                        }

                        // ➕ Insert reservation
                        string insertQuery = @"INSERT INTO Reservations
                    (UserNumber, BookNumber, ReservationDate, ExpectedPickupDate, Status)
                    VALUES
                    (@UserNumber, @BookNumber, @ResDate, @ExpDate, 'Reserved')";

                        using (MySqlCommand insert = new MySqlCommand(insertQuery, conn))
                        {
                            insert.Parameters.AddWithValue("@UserNumber", textBox1.Text.Trim());
                            insert.Parameters.AddWithValue("@BookNumber", bookNumber);
                            insert.Parameters.AddWithValue("@ResDate", DateTime.Today);
                            insert.Parameters.AddWithValue("@ExpDate", dateTimePicker2.Value.Date);
                            insert.ExecuteNonQuery();
                        }

                        // ➖ Update stock
                        string updateQuery = @"UPDATE Books
                                       SET StockQuantity = StockQuantity - 1
                                       WHERE BookNumber=@BookNumber";
                        using (MySqlCommand up = new MySqlCommand(updateQuery, conn))
                        {
                            up.Parameters.AddWithValue("@BookNumber", bookNumber);
                            up.ExecuteNonQuery();
                        }

                        // UI update
                        row.Cells["StockQuantity"].Value = stock - 1;
                    }
                }

                MessageBox.Show("Reservation completed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reserving book: " + ex.Message);
            }
        }





        private void txtUserNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ClearForm()
        {

            textBox1.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Enter User Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        cmd.Parameters.AddWithValue("@UserNumber", textBox1.Text.Trim());
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            isUserVerified = true;
                            MessageBox.Show("User verified successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBooks();
                        }
                        else
                        {
                            isUserVerified = false;
                            MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking user: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            dgvReservation.Rows.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}


