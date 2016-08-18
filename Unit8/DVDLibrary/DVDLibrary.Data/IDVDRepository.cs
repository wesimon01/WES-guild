using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;

namespace DVDLibrary.Data
{
    public interface IDVDRepository
    {
        List<DVD> GetAll();
        DVD Get(int dvdId);
        DVD GetbyTitle(string title);
        void RemoveDVD(int dvdId);
        void AddDVD(DVD dvd);
        List<Borrower> GetBorrowerList(int id);
        List<Borrower> GetAllBorrowers();
        
    }
}
