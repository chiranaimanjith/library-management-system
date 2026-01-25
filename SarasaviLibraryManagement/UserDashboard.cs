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
    public partial class UserDashboard : Form
    {
        private string connectionString =
            "server=localhost;user=root;password=2004;database=library_db;";

        public UserDashboard()
        {
            InitializeComponent();
            this.Load += UserDashboard_Load;
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadAvailableBooks();
        }

        private void SetupGrid()
        {
            dgvUserInquiry.Columns.Clear();

            dgvUserInquiry.ReadOnly = true;
            dgvUserInquiry.AllowUserToAddRows = false;
            dgvUserInquiry.AllowUserToDeleteRows = false;
            dgvUserInquiry.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUserInquiry.MultiSelect = false;
            dgvUserInquiry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvUserInquiry.Columns.Add("BookNumber", "Book Number");
            dgvUserInquiry.Columns.Add("Title", "Title");
            dgvUserInquiry.Columns.Add("Author", "Author");
            dgvUserInquiry.Columns.Add("Classification", "Classification");
            dgvUserInquiry.Columns.Add("ItemType", "Item Type");
            dgvUserInquiry.Columns.Add("StockQuantity", "Stock Quantity");
        }

        private void LoadAvailableBooks()
        {
            dgvUserInquiry.Rows.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT BookNumber, Title, Author, Classification, ItemType, StockQuantity
                        FROM Books
                        WHERE StockQuantity > 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvUserInquiry.Rows.Add(
                                reader["BookNumber"].ToString(),
                                reader["Title"].ToString(),
                                reader["Author"].ToString(),
                                reader["Classification"].ToString(),
                                reader["ItemType"].ToString(),
                                reader["StockQuantity"].ToString()
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading books: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
