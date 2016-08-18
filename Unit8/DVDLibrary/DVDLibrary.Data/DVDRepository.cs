using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;

namespace DVDLibrary.Data
{
    public class DVDRepository : IDVDRepository
    {
        private static List<DVD> _DVDs;
        private static List<Borrower> _borrowers;

        public DVDRepository()
        {
            if (_borrowers == null)
            {
                _borrowers = new List<Borrower>()
            {
               new Borrower {BorrowerId = 1, BorrowerName = "Beavis", DateBorrowed =      new DateTime(2016, 7, 3), DateReturned = new DateTime(2016, 7, 5), dvdBorrowedId = 1},
               new Borrower {BorrowerId = 2, BorrowerName = "AgentSmith", DateBorrowed =  new DateTime(2016, 6, 3), DateReturned = new DateTime(2016, 6, 9), dvdBorrowedId = 4},
               new Borrower {BorrowerId = 3, BorrowerName = "SpaceGhost", DateBorrowed =  new DateTime(2016, 7, 3), DateReturned = new DateTime(2016, 7, 8), dvdBorrowedId = 4},
               new Borrower {BorrowerId = 4, BorrowerName = "Beavis", DateBorrowed =      new DateTime(2015, 6, 3), DateReturned = new DateTime(2015, 6, 5), dvdBorrowedId = 2},
               new Borrower {BorrowerId = 5, BorrowerName = "AgentSmith", DateBorrowed =  new DateTime(2015, 7, 3), DateReturned = new DateTime(2015, 7, 9), dvdBorrowedId = 1},
               new Borrower {BorrowerId = 6, BorrowerName = "SpaceGhost", DateBorrowed =  new DateTime(2015, 7, 3), DateReturned = new DateTime(2015, 7, 8), dvdBorrowedId = 2},
               new Borrower {BorrowerId = 7, BorrowerName = "Beavis", DateBorrowed =      new DateTime(2014, 6, 3), DateReturned = new DateTime(2014, 6, 5), dvdBorrowedId = 3},
               new Borrower {BorrowerId = 8, BorrowerName = "AgentSmith", DateBorrowed =  new DateTime(2014, 7, 3), DateReturned = new DateTime(2014, 7, 9), dvdBorrowedId = 3},
               new Borrower {BorrowerId = 9, BorrowerName = "SpaceGhost", DateBorrowed =  new DateTime(2014, 7, 3), DateReturned = new DateTime(2014, 7, 8), dvdBorrowedId = 2}
            };
            }

            if (_DVDs == null)
            {
                _DVDs = new List<DVD>
            {
                new DVD {
                    Id = 1,
                    Title = "Tesla",
                    ReleaseDate =  new DateTime(2016,6,1),
                    Rating = MPAARating.R,
                    DirectorName = "Goat",
                    Studio = "MGM",
                    UserRating = 10.0M,
                    UserNotes = "Not as Good as PlanetGoat",
                    ActorsInMovie = "Andy Kauffmann",
                    BorrowerList = GetBorrowerList(1)
                },
                 new DVD {
                    Id = 2,
                    Title = "PlanetEarth",
                    ReleaseDate =  new DateTime(2016,4,1),
                    Rating = MPAARating.PG,
                    DirectorName = "Goat",
                    Studio = "BBC",
                    UserRating = 10.0M,
                    UserNotes = "great cinematography",
                    ActorsInMovie = "Marie Curie",
                    BorrowerList = GetBorrowerList(2),
                 },
                new DVD {
                    Id = 3,
                    Title = "PlanetGoat",
                    ReleaseDate =  new DateTime(2016,1,1),
                    Rating = MPAARating.NC_17,
                    DirectorName = "Goat",
                    Studio = "WarnerBros",
                    UserRating = 10.0M,
                    UserNotes = "Goat's best work",
                    ActorsInMovie = "Einstein",
                    BorrowerList = GetBorrowerList(3),
                },
                 new DVD {
                    Id = 4,
                    Title = "RoadWarrior",
                    ReleaseDate =  new DateTime(2010,3,1),
                    Rating = MPAARating.PG,
                    DirectorName = "Goat",
                    Studio = "Fox",
                    UserRating = 5.0M ,
                    UserNotes = "Romantic Comedy of the Year",
                    ActorsInMovie = "BoltzmannConstant",
                    BorrowerList = GetBorrowerList(4),
                 },
        };
     }          
 }

        public List<DVD> GetAll()
        {
            return _DVDs;
        }

        public DVD Get(int dvdId)
        {
            return _DVDs.FirstOrDefault(d => d.Id == dvdId);
        }

        public DVD GetbyTitle(string title)
        {       
             return _DVDs.FirstOrDefault(d => d.Title == title);          
        }

        public void RemoveDVD(int dvdId)
        {
            DVD selectedDVD = _DVDs.FirstOrDefault(d => d.Id == dvdId);

            if (selectedDVD != null)
            {
                _DVDs.RemoveAll(d => d.Id == selectedDVD.Id);
            }
        }

        public void AddDVD(DVD dvd)
        {
            if (_DVDs.Any())
                dvd.Id = _DVDs.Max(d => d.Id) + 1;
            else
                dvd.Id = 1;
            
            _DVDs.Add(dvd); 
        }

        public List<Borrower> GetBorrowerList(int id)
        {
            var borrowerList  = GetAllBorrowers(); 
            var dvdborrowerlist = (borrowerList.Where(b => b.dvdBorrowedId == id)).ToList();
            return dvdborrowerlist;
        }

        public List<Borrower> GetAllBorrowers()
        {
            return _borrowers;
        }
    }
}
