using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using CarDealership.Data;


namespace CarDealership.BLL
{
    public class DealershipService : IDealershipService
    {
        private IDealershipRepository _repo;

        public DealershipService(IDealershipRepository repo)
        {
            _repo = repo;
        }

        public List<Vehicle> GetVehiclelist()  //method
        {
            try
            {
                return _repo.GetAllVehicles();
            }

            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetVehiclelist service module :", ex);
            }
        }

        public Vehicle GetVehicle(int vehicleId)  //method
        {
            try
            {
                return _repo.GetVehicle(vehicleId);
            }

            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetVehicle service module :", ex);
            }
        }

        public void AddVehicle(Vehicle vehicle)  //method
        {
            try
            {
                _repo.AddVehicle(vehicle);
            }

            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the AddVehicle service module :", ex);
            }
        }

        public void RemoveVehicle(int vehicleId)  //method
        {
            try
            {
                _repo.RemoveVehicle(vehicleId);
            }

            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the RemoveVehicle service module :", ex);
            }
        }




        public List<InfoRequest> GetInfoRequestlist()  //method
        {
            try
            {
                return _repo.GetAllInfoRequests();
            }

            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetInfoRequestlist service module :", ex);
            }
        }

        public void AddInfoRequest(InfoRequest inforequest)  //method
        {
            try
            {
                _repo.AddInfoRequest(inforequest);
            }

            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the AddInfoRequest service module :", ex);
            }
        }

        public void UpdateRequestStatus(int inforequestId, RequestStatus status)
        {
            try
            {
                _repo.UpdateInfoRequestStatus(inforequestId, status);
            }

            catch (Exception ex)
            {

                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the UpdateRequestStatus service module :", ex);
            }
        }



    }
}



