using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarDealership.Models
{
    public class Vehicle
    {
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public string Make { get; set; } //manufacturer
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Mileage { get; set; }
        public string AdTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string PicUrl { get; set; }
        [Required]
        public bool IsAvailable { get; set; }

        public Vehicle()
        {
            IsAvailable = true;
            PicUrl = "PicUrl";
        }

    }
}
