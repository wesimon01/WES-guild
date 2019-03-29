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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public MPAARating MPAARating { get; set; }
        [Required]
        public string DirectorName { get; set; }
        [Required]
        public string Studio { get; set; }
        [Required]
        public decimal UserRating { get; set; }
        [Required]
        public string UserNotes { get; set; } 
        [Required]
        public string ActorsInMovie { get; set; } 
        public IEnumerable<Borrower> BorrowerList { get; set; }
        public bool IsBorrowed { get; set; }        
    }
}
