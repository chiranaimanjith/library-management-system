using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SarasaviLibraryManagement
{
    public class Loan
    {
        private bool isUserVerified = false;
        public int LoanID { get; set; }
        public int UserNumber { get; set; }
        public string BookNumber { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public List<int> CopyNumbers { get; set; }
        public List<string> BookTitles { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public Loan()
        {
            CopyNumbers = new List<int>();
            BookTitles = new List<string>();
            LoanDate = DateTime.Today;
            ExpectedReturnDate = DateTime.Today.AddDays(14);
        
    }
    }
}
