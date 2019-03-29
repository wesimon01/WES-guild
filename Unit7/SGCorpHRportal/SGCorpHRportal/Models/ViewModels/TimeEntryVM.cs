using SGCorpHRportal.Data;
using SGCorpHRportal.Models;
using SGCorpHRPortal.Data.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SGCorpHRportal.UI.Models.ViewModels
{
    public class TimeEntryVM
    {
        public TimeEntry TimeEntry { get; set; }   
        public List<SelectListItem> EmployeeItems { get; set; }
        public int selectedEmployeeId { get; set; }

        //public TimeEntryVM()
        //{        
        //    EmployeeItems = new List<SelectListItem>();
        //    TimeEntry = new TimeEntry();            
        //}
    }
}

