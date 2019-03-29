using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.Models;
using DVDLibrary.BLL;
using DVDLibrary.UI.Util;

namespace DVDLibrary.UI.ViewModels
{
    public class DVDdisplayVM
    {
        public int? dvdId { get; set; }
        public IEnumerable<SelectListItem> DVDItems { get; set; }
        public IEnumerable<DVD> DVDs { get; set; }
        public DVD selectedDVD { get; set; }      
    }
}