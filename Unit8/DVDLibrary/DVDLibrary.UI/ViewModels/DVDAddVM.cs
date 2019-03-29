using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Models;
using DVDLibrary.BLL;
using System.IO;
using DVDLibrary.UI.Util;

namespace DVDLibrary.UI.ViewModels
{
    public class DVDAddVM
    {      
        public IDictionary<int, string> mpaaRatings { get; set; }       
        public DVD DVD { get; set; }

        public DVDAddVM()
        { 
            mpaaRatings = Utilities.PopulateRatingsDictionary();
        }        
    }
}