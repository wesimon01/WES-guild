using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class Borrower
    {
        public int BorrowerId { get; set; }
        public string BorrowerName { get; set; }
        public int dvdBorrowedId { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DateReturned { get; set; }
        
    }
}
