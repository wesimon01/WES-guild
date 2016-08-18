using System.Collections.Generic;
using CarDealership.Models;

namespace CarDealership.BLL
{
    public interface IDealershipService
    {
        void AddInfoRequest(InfoRequest inforequest);
        void AddVehicle(Vehicle vehicle);
        List<InfoRequest> GetInfoRequestlist();
        Vehicle GetVehicle(int vehicleId);
        List<Vehicle> GetVehiclelist();
        void RemoveVehicle(int vehicleId);
        void UpdateRequestStatus(int inforequestId, RequestStatus status);
    }
}