using DVDLibrary.BLL;
using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDLibrary.UI.ViewModels
{
    public class DVDremoveVM
    {
        private IDVDService _service;
        public int _selectedDVDId { get; set; }
        public List<DVD> _dvds { get; set; }
        public DVD _dvd { get; set; }

        public DVDremoveVM(IDVDService service)
        {
            _service = service;
            _dvds = _service.GetDVDlist();
        }

    }
}