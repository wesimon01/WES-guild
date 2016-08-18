using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarDealership.BLL;
using CarDealership.Models;

namespace CarDealership.UI.ViewModels
{
    public class VehicleremoveVM
    {    
        public int _selectedVehicleId { get; set; }
        public List<Vehicle> _vehicles { get; set; }
        public Vehicle _vehicle { get; set; }

    }
}