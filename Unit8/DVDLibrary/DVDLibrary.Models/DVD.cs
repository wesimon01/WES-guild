using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVDLibrary.Models
{
    public class DVD
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public MPAARating Rating { get; set; }
        [Required]
        public string DirectorName { get; set; }
        [Required]
        public string Studio { get; set; }
        [Required]
        public decimal UserRating { get; set; }
        [Required]
        public string UserNotes { get; set; } // public List<string> UserNotes { get; set; }
        [Required]
        public string ActorsInMovie { get; set; } // public List<string> ActorsInMovie { get ; set; }
        public List<Borrower> BorrowerList { get; set; }
        public bool IsBorrowed { get; set; }        
    }
}
