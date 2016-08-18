using System.Collections.Generic;
using CarDealership.Models;

namespace CarDealership.Data
{
    public interface IDealershipRepository
    {
        void AddInfoRequest(InfoRequest inforequest);
        void AddVehicle(Vehicle vehicle);
        List<InfoRequest> GetAllInfoRequests();
        List<Vehicle> GetAllVehicles();
        Vehicle GetVehicle(int vehicleId);
        void RemoveVehicle(int vehicleId);
        void UpdateInfoRequestStatus(int inforequestId, RequestStatus requestStatus);
    }
}