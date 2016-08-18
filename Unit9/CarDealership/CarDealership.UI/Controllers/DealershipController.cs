using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDealership.Models;
using CarDealership.BLL;
using CarDealership.UI.ViewModels;

namespace CarDealership.UI.Controllers
{
    public class DealershipController : Controller
    {      
            private IDealershipService _service;

            public DealershipController(IDealershipService service)
            {
                _service = service;
            }

            public ActionResult Index()
            {
                return View();
            }

            [HttpGet]
            public ActionResult Vehiclelist()
            {
                List<Vehicle> list = _service.GetVehiclelist();

                if (list != null)
                {
                    return View(list);
                }
                return RedirectToAction("Index");
            }

          [HttpGet]
          public ActionResult Inforequestlist()
          {
            List<InfoRequest> list = _service.GetInfoRequestlist();

            if (list != null)
            {
                return View(list);
            }
            return RedirectToAction("Index");
          }

         [HttpGet]
           public ActionResult Vehicleadd()
           {
              return View(new Vehicle());
           }

           [HttpPost]
            public ActionResult Vehicleadd(Vehicle vehicle)
            {
             if (ModelState.IsValid)
            {
                _service.AddVehicle(vehicle);
                return RedirectToAction("Vehiclelist", "Dealership");
            }
            return View(vehicle);

           }

        [HttpGet]
        public ActionResult Vehicledisplay(int? selectedVehicleId)
        {
            //Vehicle vehicle = _service.GetVehicle(selectedVehicleId.Value);

            if (selectedVehicleId == null || selectedVehicleId == 0 || _service.GetVehicle(selectedVehicleId.Value) == null)
            {
                VehicledisplayVM viewmodel = new VehicledisplayVM();
                viewmodel._vehicles = _service.GetVehiclelist();
                viewmodel.SetVehicleItems(viewmodel._vehicles);

                return View(viewmodel);
            }

            else
            {
                VehicledisplayVM viewmodel = new VehicledisplayVM();
                viewmodel._vehicles = _service.GetVehiclelist();
                viewmodel.SetVehicleItems(viewmodel._vehicles);
                viewmodel._selectedVehicleId = selectedVehicleId.Value;
                viewmodel._vehicle = _service.GetVehicle(viewmodel._selectedVehicleId);

                return View(viewmodel);
            }
        }

        [HttpGet]
        public ActionResult Vehicleremove()
        {
            VehicleremoveVM viewmodel = new VehicleremoveVM();
            viewmodel._vehicles = _service.GetVehiclelist();

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Vehicleremove(int? vehicleId)
        {
            if (ModelState.IsValid && vehicleId != null)
            {
                _service.RemoveVehicle(vehicleId.Value);
                return RedirectToAction("Vehicleremove");
            }
            return RedirectToAction("Vehicleremove");
        }

        [HttpGet]
        public ActionResult Inforequestadd()
        {
            InforequestaddVM viewmodel = new InforequestaddVM();
            viewmodel._vehicles = _service.GetVehiclelist();
            viewmodel.SetVehicleItems(viewmodel._vehicles);
            viewmodel._inforequest = new InfoRequest();

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Inforequestadd(InforequestaddVM viewmodel)
        {
            viewmodel._inforequest.VehicleId = viewmodel._selectedVehicleId;

            if (ModelState.IsValid)
            {           
                _service.AddInfoRequest(viewmodel._inforequest);
                return RedirectToAction("Inforequestlist", "Dealership");
            }

            viewmodel._vehicles = _service.GetVehiclelist();
            viewmodel.SetVehicleItems(viewmodel._vehicles);
            viewmodel._inforequest = new InfoRequest();

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Inforequestupdate()
        {
            InforequestupdateVM viewmodel = new InforequestupdateVM();
            viewmodel._requests = _service.GetInfoRequestlist();
            viewmodel.SetRequestItems(viewmodel._requests);
            
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Inforequestupdate(InforequestupdateVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateRequestStatus(viewmodel._selectedRequestId, viewmodel._status);
                return RedirectToAction("Inforequestlist", "Dealership");
            }
            return View(viewmodel);
        }

    }
}