using System;

namespace SarasaviLibraryManagement
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int UserID { get; set; }
        public int CopyID { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Returned { get; set; }
         
        public int verifiedUserID = 0;

        public Loan()
        {
            LoanDate = DateTime.Today;
            DueDate = DateTime.Today.AddDays(14);
            Returned = false;
        }
    }
}
