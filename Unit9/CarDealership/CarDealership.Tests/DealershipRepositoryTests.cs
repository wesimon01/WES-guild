using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.BLL;
using CarDealership.Models;
using NUnit.Framework;
using CarDealership.Data;

namespace CarDealership.Tests
{
    public class DealershipRepositoryTests
    {
        [TestFixture]
        public class repoTests
        {
            [Test]
            public void CanGetVehicle()
            {
                TestDealershipRepository repo = new TestDealershipRepository();
                var vehicle = repo.GetVehicle(1);

                Assert.AreEqual(1, vehicle.VehicleId);
                Assert.AreEqual("Honda", vehicle.Make);
                Assert.AreEqual("Accordz", vehicle.Model);
            }

            [Test]
            public void CanGetAllVehicles()
            {
                TestDealershipRepository repo = new TestDealershipRepository();
                var vehicles = repo.GetAllVehicles();

                Assert.AreEqual(4, vehicles.Count());
            }

            [Test]
            public void CanGetAllInfoRequests()
            {
                TestDealershipRepository repo = new TestDealershipRepository();
                var inforequests = repo.GetAllInfoRequests();

                Assert.AreEqual(4, inforequests.Count());
            }

            [Test]
            public void CanRemoveVehicle()
            {
                TestDealershipRepository repo = new TestDealershipRepository();
                var vehicles = repo.GetAllVehicles();
                repo.RemoveVehicle(2);

                Assert.AreEqual(3, vehicles.Count());
            }

            [Test]
            public void CanAddVehicle()
            {
                TestDealershipRepository repo = new TestDealershipRepository();

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

                repo.AddVehicle(vehicle);
                var vehicles = repo.GetAllVehicles();
                var _vehicle = repo.GetVehicle(5);
                Assert.AreEqual(5, vehicles.Count());
                Assert.AreEqual("Honda", _vehicle.Make);
                Assert.AreEqual("Accordz", _vehicle.Model);

            }

            [Test]
            public void CanAddInfoRequest()
            {
                TestDealershipRepository repo = new TestDealershipRepository();

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
                    LastContactDate = new DateTime(2016, 8, 1),
                    Status = RequestStatus.New,
                };

                repo.AddInfoRequest(inforequest);
                var requests = repo.GetAllInfoRequests();
                Assert.AreEqual(5, requests.Count());
            }


            [Test]
            public void CanGetUpdateInfoRequestStatus()
            {
                TestDealershipRepository repo = new TestDealershipRepository();
                var inforequestList = repo.GetAllInfoRequests();
                var inforequest = inforequestList.FirstOrDefault(i => i.InfoRequestId == 2);
                inforequest.Status = RequestStatus.LostOpportunity;

                Assert.AreEqual(inforequest.Status, RequestStatus.LostOpportunity);
                Assert.AreEqual(inforequest.InfoRequestId, 2);
            }


        }
    }
}
