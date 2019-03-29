using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.BLL;
using DVDLibrary.Models;


namespace DVDLibrary.UI.ViewModels
{
    public class DVDsearchVM
    {
        public int _selectedDVDId { get; set; }
        public IEnumerable<DVD> DVDs { get; set; }
        public DVD DVD { get; set; }
    }
}