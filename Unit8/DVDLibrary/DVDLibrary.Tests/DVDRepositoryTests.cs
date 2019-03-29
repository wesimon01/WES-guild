using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DVDLibrary.Data;
using DVDLibrary.Models;

namespace DVDLibrary.Tests
{
    [TestFixture]
    public class DVDRepositoryTests
    {
        [Test]
        public void CanGetDVD()
        {
            var repo = new DVDRepository();
 
            var dvd = repo.Get(1);

            Assert.AreEqual(1, dvd.Id);
            Assert.AreEqual("Tesla", dvd.Title);
            Assert.AreEqual("MGM", dvd.Studio);
        }

        [Test]
        public void CanGetAllDVDs()
        {
            var repo = new DVDRepository();
            var dvds = repo.GetAll();

            Assert.AreEqual(4, dvds.Count());
        }

        [Test]
        public void CanRemoveDVD()
        {
            var repo = new DVDRepository();
           
            var dvds= repo.GetAll();
            repo.RemoveDVD(2);

            Assert.AreEqual(3, dvds.Count());
        }

        [Test]
        public void CanAddDVD()
        {
            var repo = new DVDRepository();

            DVD dvd = new DVD
            {
                Id = 4,
                Title = "Godzilla, Rhow!",
                ReleaseDate = new DateTime(2010, 3, 1),
                MPAARating = MPAARating.PG,
                DirectorName = "Goat",
                Studio = "20th Century Fox",
                UserRating = 5.0M,
                UserNotes = "good action movie",
                ActorsInMovie = "Hopkins, Cage",
                BorrowerList = new List<Borrower>(),
            };

            repo.AddDVD(dvd);
            var dvds = repo.GetAll();
            Assert.AreEqual(5, dvds.Count());
        }

        [Test]
        public void CanGetByTitle()
        {
            var repo = new DVDRepository();
            var dvd = repo.GetbyTitle("PlanetEarth");

            Assert.AreEqual(dvd.MPAARating, MPAARating.PG);
            Assert.AreEqual(dvd.Id, 2);
        }

       
    }
}
