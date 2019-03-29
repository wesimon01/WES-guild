using System.Collections.Generic;
using DVDLibrary.Models;

namespace DVDLibrary.BLL
{
    public interface IDVDService
    {
        void AddDVD(DVD dvd);
        void EditDVD(DVD dvd);
        void RemoveDVD(int DVDId);
        DVD GetDVD(int dvdId);
        DVD GetDVDbyTitle(string title);
        IEnumerable<DVD> GetDVDlist();
        IEnumerable<Borrower> GetBorrowerList(int id);               
    }
}