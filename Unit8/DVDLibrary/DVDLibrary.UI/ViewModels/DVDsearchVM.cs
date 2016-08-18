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
        private IDVDService _service;
        public int _selectedDVDId { get; set; }
        public List<DVD> _dvds { get; set; }
        public DVD _dvd { get; set; }


        public DVDsearchVM(IDVDService service)
        {
            _service = service;
            _dvds = _service.GetDVDlist();
        }

    }
}