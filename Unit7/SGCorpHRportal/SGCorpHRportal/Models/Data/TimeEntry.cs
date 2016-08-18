using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace SGCorpHRportal.Models.Data
{
    public class TimeEntry
    {
        [Range(typeof(decimal), "0", "16", ErrorMessage="Maximum of 16 hrs per Entry")]
        public decimal HoursWorked { get; set; }
      
        [Required(ErrorMessage = "A Date is required to add a TimeEntry")]
        public DateTime dateTime { get; set; }

    }
}