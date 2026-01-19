using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarasaviLibraryManagement
{
    public class Book
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public bool IsReferenceOnly { get; set; }
        public bool IsAvailable { get; set; }
        public string Classification { get; set; } 
        public string Author { get; set; }      
        public string CopyType { get; set; }       
        public int NumberOfCopies { get; set; }  
        public int AvailableCopies { get; set; }  
        public string BookNumber { get; set; }
    }
}
