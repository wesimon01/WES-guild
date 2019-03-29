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
        void RemoveDVD(int id);
        void AddDVD(DVD dvd);
        void EditDVD(DVD dvd);
        DVD Get(int dvdId);
        DVD GetbyTitle(string title);
        List<DVD> GetAll();
        List<Borrower> GetBorrowerList(int id);
        List<Borrower> GetAllBorrowers();       
    }
}
