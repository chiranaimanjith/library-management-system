using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarasaviLibraryManagement
{
    public class Reservation
    {
        // 🔑 Primary Key
        public int ReservationID { get; set; }

        // 🔗 Foreign Keys
        public int UserID { get; set; }
        public int BookID { get; set; }

        // Display / Reference Fields
        public string UserNumber { get; set; }
        public string BookNumber { get; set; }

        // Dates
        public DateTime ReservationDate { get; set; }
        public DateTime ExpectedPickupDate { get; set; }

        // Status (Reserved, Cancelled, Collected)
        public string Status { get; set; }

        // 🔹 Constructor (optional but useful)
        public Reservation() { }

        // 🔹 Constructor with values
        public Reservation(
            int userID,
            int bookID,
            string userNumber,
            string bookNumber,
            DateTime reservationDate,
            DateTime expectedPickupDate,
            string status)
        {
            UserID = userID;
            BookID = bookID;
            UserNumber = userNumber;
            BookNumber = bookNumber;
            ReservationDate = reservationDate;
            ExpectedPickupDate = expectedPickupDate;
            Status = status;
        }
    }
}