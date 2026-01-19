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
            dgvReservation.Columns.Add("AvailableCopies", "Available Copies");
            dgvReservation.Columns.Add("Status", "Status");

            dgvReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BookNumber, Title, Author, NumberOfCopies, AvailableCopies FROM Books";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string status = reader.GetInt32("AvailableCopies") > 0 ? "Available" : "Not Available";
                            dgvReservation.Rows.Add(false,
                                reader.GetString("BookNumber"),
                                reader.GetString("Title"),
                                reader.GetString("Author"),
                                reader.GetInt32("AvailableCopies"),
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

        public static List<Resevation> ResevationList = new List<Resevation>();
        public Resevation()
        {
            InitializeComponent();
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
                .Where(r => Convert.ToBoolean(r.Cells["Select"].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Select at least one book to reserve.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        string title = row.Cells["Title"].Value.ToString();
                        int availableCopies = Convert.ToInt32(row.Cells["AvailableCopies"].Value);

                        if (availableCopies <= 0)
                        {
                            MessageBox.Show($"Book '{title}' is not available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }


                        string checkQuery = @"SELECT COUNT(*) FROM Reservations 
                                              WHERE UserNumber=@UserNumber AND BookNumber=@BookNumber 
                                              AND Status='Reserved'";
                        using (MySqlCommand cmdCheck = new MySqlCommand(checkQuery, conn))
                        {
                            cmdCheck.Parameters.AddWithValue("@UserNumber", textBox1.Text.Trim());
                            cmdCheck.Parameters.AddWithValue("@BookNumber", bookNumber);
                            int already = Convert.ToInt32(cmdCheck.ExecuteScalar());
                            if (already > 0)
                            {
                                MessageBox.Show($"You already reserved '{title}'.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                continue;
                            }
                        }


                        string insertQuery = @"INSERT INTO Reservations 
                                               (UserNumber, BookNumber,ReservationDate, ExpectedPickupDate, Status)
                                               VALUES (@UserNumber, @BookNumber,@ReservationDate, @ExpectedPickupDate, 'Reserved')";
                        using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@UserNumber", textBox1.Text.Trim());
                            cmdInsert.Parameters.AddWithValue("@BookNumber", bookNumber);
                            cmdInsert.Parameters.AddWithValue("@BookTitle", title);
                            cmdInsert.Parameters.AddWithValue("@ReservationDate", dateTimePicker1.Value.Date);
                            cmdInsert.Parameters.AddWithValue("@ExpectedPickupDate", dateTimePicker1.Value.Date);
                            cmdInsert.ExecuteNonQuery();
                        }


                        string updateQuery = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookNumber=@BookNumber";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn))
                        {
                            cmdUpdate.Parameters.AddWithValue("@BookNumber", bookNumber);
                            cmdUpdate.ExecuteNonQuery();
                        }


                        row.Cells["AvailableCopies"].Value = availableCopies - 1;
                        row.Cells["Status"].Value = availableCopies - 1 > 0 ? "Available" : "Not Available";
                    }
                }

                MessageBox.Show("Selected books reserved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reserving books: " + ex.Message);
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
            ClearForm();
        }
    }
}


