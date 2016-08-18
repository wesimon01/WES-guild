using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.Models;
using DVDLibrary.BLL;

namespace DVDLibrary.UI.ViewModels
{
    public class DVDdisplayVM
    {
        private IDVDService _service;
        public List<SelectListItem> _DVDitems = new List<SelectListItem>();
        public int _selectedDVDId { get; set; }
        public List<DVD> _dvds { get; set; }
        public DVD _dvd { get; set; }
        
        public DVDdisplayVM(IDVDService service)
        {
            _service = service;
            _dvds = _service.GetDVDlist();
            SetDVDItems(_service.GetDVDlist()); 
        }

        public void SetDVDItems(List<DVD> dvds)
        {
            foreach (var dvd in dvds)
            {
                _DVDitems.Add(new SelectListItem()
                {
                    Value = dvd.Id.ToString(),
                    Text = dvd.Title
                });
            }
        }
     
        public DVD Get(int dvdId)
        {
           return _service.GetDVD(dvdId);
        }
      
    }
}