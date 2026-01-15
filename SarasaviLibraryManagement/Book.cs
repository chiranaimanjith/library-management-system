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
        public string Publisher { get; set; }
        public bool IsReferenceOnly { get; set; }
        public bool IsAvailable { get; set; }
    }
}
