using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class DVDbasic
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
       
        public DateTime ReleaseDate { get; set; }
        
        public MPAARating Rating { get; set; }
       
        public string DirectorName { get; set; }
       
        public string Studio { get; set; }
        
        public decimal UserRating { get; set; }
     
        public string UserNotes { get; set; } // public List<string> UserNotes { get; set; }
       
        public string ActorsInMovie { get; set; } // public List<string> ActorsInMovie { get ; set; }




    }
}
