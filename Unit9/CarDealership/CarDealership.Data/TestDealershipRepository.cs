using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;


namespace CarDealership.Data
{
    public class TestDealershipRepository : IDealershipRepository
    {
        private static List<Vehicle> _vehicles;
        private static List<InfoRequest> _inforequests;

        public TestDealershipRepository()
        {
            if (_vehicles == null)
            {
                _vehicles = new List<Vehicle>
            {

            new Vehicle
            {
            VehicleId = 1,
            Make = "Honda",
            Model = "Accordz",
            Year = 1997,
            Mileage = 5000,
            AdTitle = "The Chronic",
            Description = "Best ever",
            Price = 30000.99M,
            PicUrl = "/Content/images",
            IsAvailable = true,
            },

               new Vehicle
                {
                    VehicleId = 2,
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 1988,
                    Mileage = 100000,
                    AdTitle = "Don't just look at the odometer",
                    Description = "Don't make em like in the old days",
                    Price = 1000.00M,
                    PicUrl = "/Content/images",
                    IsAvailable = true,
                },
                new Vehicle
                {
                    VehicleId = 3,
                    Make = "Porsche",
                    Model = "911",
                    Year = 1991,
                    Mileage = 5000,
                    AdTitle = "old school",
                    Description = "Best ever",
                    Price = 10000.00M,
                    PicUrl = "/Content/images",
                    IsAvailable = true,
                },
                new Vehicle
                {
                    VehicleId = 4,
                    Make = "Delorean",
                    Model = "TimeMachine",
                    Year = 1985,
                    Mileage = 5000,
                    AdTitle = "time machine",
                    Description = "88 mph wormhole initiator",
                    Price = 20000.00M,
                    PicUrl = "/Content/images",
                    IsAvailable = true,
                },


            };
                if (_inforequests == null)
                {
                    _inforequests = new List<InfoRequest>()
            {
               new InfoRequest {InfoRequestId = 1, VehicleId = 1, PersonName = "Beavis", EmailAddress = "304750@yahoo.com" , PhoneNumber = "555-5557", TimetoCall = TimetoCall.Afternoon, ContactMethod = ContactMethod.Email, PurchaseTimeFrame = 27, AdditionalInfo = "additionalinfo1", LastContactDate = DateTime.Now.AddDays(-5), Status = RequestStatus.FutureProspect},
               new InfoRequest {InfoRequestId = 2, VehicleId = 2, PersonName = "Bullwinkle", EmailAddress = "as;djf@rocky.com", PhoneNumber = "555-5551", TimetoCall = TimetoCall.Morning, ContactMethod = ContactMethod.Phone, PurchaseTimeFrame = 14, AdditionalInfo = "additionalinfo2", LastContactDate = DateTime.Now.AddDays(-9), Status = RequestStatus.AwaitingReply },
               new InfoRequest {InfoRequestId = 3, VehicleId = 3, PersonName = "Shinobi", EmailAddress = "304750@yahoo.com" , PhoneNumber = "555-5554", TimetoCall = TimetoCall.Afternoon, ContactMethod = ContactMethod.Email, PurchaseTimeFrame = 10, AdditionalInfo = "additionalinfo3", LastContactDate = DateTime.Now.AddDays(-4), Status = RequestStatus.FutureProspect},
               new InfoRequest {InfoRequestId = 4, VehicleId = 4, PersonName = "Xenomorph", EmailAddress = "acid@alien.com", PhoneNumber = "555-5550", TimetoCall = TimetoCall.Evening, ContactMethod = ContactMethod.Phone, PurchaseTimeFrame = 4, AdditionalInfo = "additionalinfo4", LastContactDate = DateTime.Now.AddDays(-2), Status = RequestStatus.AwaitingReply },
            };
                }
            }
   }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public Vehicle GetVehicle(int vehicleId)
        {
            return _vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (_vehicles.Any())
                vehicle.VehicleId = _inforequests.Max(d => d.InfoRequestId) + 1;
            else
                vehicle.VehicleId= 1;

            _vehicles.Add(vehicle);

        }

        public void RemoveVehicle(int vehicleId)
        {
            Vehicle selectedvehicle = _vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);

            if (selectedvehicle != null)
            {
                _vehicles.RemoveAll(d => d.VehicleId == selectedvehicle.VehicleId);
            }
        }

        public List<InfoRequest> GetAllInfoRequests()
        {
            return _inforequests;
        }

        public void AddInfoRequest(InfoRequest inforequest)
        {
            if (_inforequests.Any())
                inforequest.InfoRequestId = _inforequests.Max(d => d.InfoRequestId) + 1;
            else
                inforequest.InfoRequestId = 1;

            _inforequests.Add(inforequest);
        }

        public void UpdateInfoRequestStatus(int inforequestId, RequestStatus requestStatus)
        {
            var inforequestList = GetAllInfoRequests();
            var inforequest = inforequestList.FirstOrDefault(i => i.InfoRequestId == inforequestId);
            inforequest.Status = requestStatus;
        }
    }
}
