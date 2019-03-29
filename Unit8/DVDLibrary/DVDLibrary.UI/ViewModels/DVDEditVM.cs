using DVDLibrary.Models;
using DVDLibrary.UI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibrary.UI.ViewModels
{
    public class DVDEditVM
    {
        public IDictionary<int, string> mpaaRatings { get; set; }
        public DVD DVD { get; set; }

        public DVDEditVM()
        {
            mpaaRatings = Utilities.PopulateRatingsDictionary();
        }
    }
}