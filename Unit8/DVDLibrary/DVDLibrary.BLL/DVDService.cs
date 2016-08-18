using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data;
using DVDLibrary.Models;
using System.Configuration;

namespace DVDLibrary.BLL
{
    public class DVDService : IDVDService
    {
        private IDVDRepository _repo;
            
        public DVDService(IDVDRepository repo) 
        {
            _repo = repo;
        }

        public List<DVD> GetDVDlist()  //method
        {
            try
            {
                return _repo.GetAll();
            }

            catch (Exception ex)
            {
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetDVDlist service module :", ex);
            }
        }

        public DVD GetDVD(int dvdId)  //method
        { 
            try {

                return _repo.Get(dvdId); 
            }

            catch (Exception ex)
            {
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetDVD service module :", ex);
            }
        }

        public DVD DVDObjectCreate()   //method
        {
            return (new DVD()); 
        }
      
        public void RemoveDVD(int DVDId)  //method
        {
            try {

                _repo.RemoveDVD(DVDId); 
            }

            catch (Exception ex)
            {
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the RemoveDVD service module :", ex);
            }
        }

        public void AddDVD(DVD dvd)  //method
        {
            try
            {
                _repo.AddDVD(dvd); 
            }

            catch (Exception ex)
            {
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the AddDVD service module :", ex);
            }
        }

        public DVD GetDVDbyTitle(string title)  //method
        {
            try {

                return _repo.GetbyTitle(title);
            }

            catch (Exception ex)
            {
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetDVDbyTitle service module :", ex);
            }
        }

    }
}

//public DVDService() // previous constructor used before NINJECT was installed
//{
//    AppSettingsReader reader = new AppSettingsReader();
//    string repo_Set = reader.GetValue("mode", typeof(string)).ToString();

//    if (repo_Set == "test")
//    {
//        _repo = new DVDRepository();
//    }
//    else
//    {
//        _repo = new DVDRepository();
//    }
//}