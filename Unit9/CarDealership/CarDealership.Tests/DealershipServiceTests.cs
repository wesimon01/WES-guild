using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CarDealership.BLL;
using CarDealership.Models;
using CarDealership.Data;

namespace CarDealership.Tests
{
    public class DealershipServiceTests
    {
        [TestFixture]
        public class ServiceTests
        { 
            [Test]
            public void CanGetVehicle()
            {
                DealershipService service = new DealershipService(new TestDealershipRepository());
                var vehicle = service.GetVehicle(1);

                Assert.AreEqual(1, vehicle.VehicleId);
                Assert.AreEqual("Honda", vehicle.Make);
                Assert.AreEqual("Accordz", vehicle.Model);
            }

            [Test]
            public void CanGetAllVehicles()
            {
                DealershipService service = new DealershipService(new TestDealershipRepository());
                var vehicles = service.GetVehiclelist();

                Assert.AreEqual(4, vehicles.Count());
            }

            [Test]
            public void CanGetAllInfoRequests()
            {
                DealershipService service = new DealershipService(new TestDealershipRepository());
                var inforequests = service.GetInfoRequestlist();

                Assert.AreEqual(4, inforequests.Count());
            }

            [Test]
            public void CanRemoveVehicle()
            {
                DealershipService service = new DealershipService(new TestDealershipRepository());
                var vehicles = service.GetVehiclelist();
                service.RemoveVehicle(2);

                Assert.AreEqual(3, vehicles.Count());
            }

            [Test]
            public void CanAddVehicle()
            {
                DealershipService service = new DealershipService(new TestDealershipRepository());

                Vehicle vehicle = new Vehicle
                {

                    Make = "Honda",
                    Model = "Accordz",
                    Year = 1997,
                    Mileage = 5000,
                    AdTitle = "The Chronic",
                    Description = "Best ever",
                    Price = 30000.99M,
                    PicUrl = "/Content/images",
                    IsAvailable = true,
                };

                service.AddVehicle(vehicle);
                var vehicles = service.GetVehiclelist();
                var _vehicle = service.GetVehicle(5);
                Assert.AreEqual(5, vehicles.Count());
                Assert.AreEqual("Honda", _vehicle.Make);
                Assert.AreEqual("Accordz", _vehicle.Model);

            }

            [Test]
            public void CanAddInfoRequest()
            {
                DealershipService service = new DealershipService(new TestDealershipRepository());

                var inforequest = new InfoRequest
                {
                    InfoRequestId = 5,
                    VehicleId = 1,
                    PersonName = "AgentSmith",
                    EmailAddress = "Architect@Matrix.com",
                    PhoneNumber = "555-5555",
                    TimetoCall = TimetoCall.Evening,
                    ContactMethod = ContactMethod.Email,
                    PurchaseTimeFrame = 7,
                    AdditionalInfo = "Additional Info",
                    LastContactDate = new DateTime(2016,8,1),
                    Status = RequestStatus.New,
                };

                service.AddInfoRequest(inforequest);
                var requests = service.GetInfoRequestlist();
                Assert.AreEqual(5, requests.Count());             
            }


            [Test]
            public void CanGetUpdateInfoRequestStatus()
            {
                DealershipService service = new DealershipService(new TestDealershipRepository());
                var inforequestList = service.GetInfoRequestlist();
                var inforequest = inforequestList.FirstOrDefault(i => i.InfoRequestId == 2);
                inforequest.Status = RequestStatus.LostOpportunity;

                Assert.AreEqual(inforequest.Status, RequestStatus.LostOpportunity);
                Assert.AreEqual(inforequest.InfoRequestId, 2);
            }


        }

    }
}

