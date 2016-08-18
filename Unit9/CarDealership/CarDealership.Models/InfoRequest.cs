using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models
{
    public class InfoRequest
    {        
        public int InfoRequestId { get; set; }
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public TimetoCall TimetoCall { get; set; }
        [Required]
        public ContactMethod ContactMethod { get; set; }
        [Required]
        public int PurchaseTimeFrame { get; set; } // Days
        public string AdditionalInfo { get; set; }
        public DateTime LastContactDate { get; set; }
        public RequestStatus Status { get; set; }


        public InfoRequest()
        {
            LastContactDate = DateTime.Now;
            Status = RequestStatus.New;
        }
    }
}
