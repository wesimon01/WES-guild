using System.Collections.Generic;
using DVDLibrary.Models;

namespace DVDLibrary.BLL
{
    public interface IDVDService
    {
        void AddDVD(DVD dvd);
        DVD DVDObjectCreate();
        DVD GetDVD(int dvdId);
        DVD GetDVDbyTitle(string title);
        List<DVD> GetDVDlist();
        void RemoveDVD(int DVDId);
    }
}