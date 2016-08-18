using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DVDLibrary.BLL;
using DVDLibrary.Models;
using DVDLibrary.Data;


namespace DVDLibrary.Tests
{
    [TestFixture]
    public class DVDServiceTests
    {
        [Test]
        public void CanGetDVD()
        {
            DVDService service = new DVDService(new DVDRepository());
            var dvd = service.GetDVD(1);

            Assert.AreEqual(1, dvd.Id);
            Assert.AreEqual("Tesla", dvd.Title);
            Assert.AreEqual("MGM", dvd.Studio);
        }

        [Test]
        public void CanGetAllDVDs()
        {
            DVDService service = new DVDService(new DVDRepository());
            var dvds = service.GetDVDlist();

            Assert.AreEqual(4, dvds.Count());
        }

        [Test]
        public void CanRemoveDVD()
        {
            DVDService service = new DVDService(new DVDRepository());
            var dvds = service.GetDVDlist();
            service.RemoveDVD(2);

            Assert.AreEqual(3, dvds.Count());
        }

        [Test]
        public void CanAddDVD()
        {
            DVDService service = new DVDService(new DVDRepository());
            DVD dvd = new DVD
            {
                Id = 4,
                Title = "Godzilla, Rhow!",
                ReleaseDate = new DateTime(2010, 3, 1),
                Rating = MPAARating.PG,
                DirectorName = "Goat",
                Studio = "20th Century Fox",
                UserRating = 5.0M,
                UserNotes = "good action movie",
                ActorsInMovie = "Hopkins, Cage",
                BorrowerList = new List<Borrower>(),
            };

            service.AddDVD(dvd);
            var dvds = service.GetDVDlist();
            Assert.AreEqual(5, dvds.Count());
        }

        [Test]
        public void CanGetByTitle()
        {
            DVDService service = new DVDService(new DVDRepository());
            var dvd = service.GetDVDbyTitle("PlanetEarth");

            Assert.AreEqual(dvd.Rating, MPAARating.PG);
            Assert.AreEqual(dvd.Id, 2);
        }

    }

}
