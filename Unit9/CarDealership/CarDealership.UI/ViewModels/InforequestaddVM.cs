using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarDealership.Models;
using CarDealership.BLL;


namespace CarDealership.UI.ViewModels
{
    public class InforequestaddVM
    {
        
        public List<SelectListItem> _Vehicleitems = new List<SelectListItem>();
        public int _selectedVehicleId { get; set; }
        public List<Vehicle> _vehicles { get; set; }
        public InfoRequest _inforequest { get; set; }
   

        public void SetVehicleItems(List<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                _Vehicleitems.Add(new SelectListItem()
                {
                    Value = vehicle.VehicleId.ToString(),
                    Text = vehicle.Make + " " + vehicle.Model
                });
            }
        }
        
    }
}