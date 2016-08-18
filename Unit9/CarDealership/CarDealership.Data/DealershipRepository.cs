using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using System.Data.SqlClient;
using System.Data;

namespace CarDealership.Data
{
    public class DealershipRepository : IDealershipRepository
    {
        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAllVehicles";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cxn;

                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vehicles.Add(PopulateVehicleFromDataReader(dr));
                    }
                }
            }

            return vehicles;
        }

        public Vehicle GetVehicle(int vehicleId)
        {
            Vehicle vehicle = new Vehicle();

            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetVehicle";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cxn;
                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vehicle = PopulateVehicleFromDataReader(dr);
                    }
                }
            }
            return vehicle;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {

                var cmd = new SqlCommand();

                cmd.CommandText = "AddVehicle";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cxn;
                         
                cmd.Parameters.AddWithValue("@Make", vehicle.Make);
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@AdTitle", vehicle.AdTitle);
                cmd.Parameters.AddWithValue("@Description", vehicle.Description);
                cmd.Parameters.AddWithValue("@Price", vehicle.Price);
                cmd.Parameters.AddWithValue("@PicUrl", vehicle.PicUrl);
                cmd.Parameters.AddWithValue("@IsAvailable", vehicle.IsAvailable);

                cxn.Open();
                cmd.ExecuteNonQuery();           
                cxn.Close();
             
            }
        }

        public void RemoveVehicle(int vehicleId)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {

                var cmd = new SqlCommand();
                //var cmd2 = new SqlCommand();

                cmd.CommandText = "RemoveVehicle";
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd2.CommandText = "RemoveInfoRequests";
                //cmd2.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cxn;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                //cmd2.Parameters.AddWithValue("@VehicleId", vehicleId);

                cxn.Open();
                cmd.ExecuteNonQuery();
                //cmd2.ExecuteNonQuery();
                cxn.Close();
                //return (int)cmd.ExecuteScalar();
            }
        }


        public List<InfoRequest> GetAllInfoRequests()
        {
            List<InfoRequest> infoRequests = new List<InfoRequest>();

            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAllInfoRequests";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cxn;

                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        infoRequests.Add(PopulateInfoRequestFromDataReader(dr));
                    }
                }
            }

            return infoRequests;
        }

        public void AddInfoRequest(InfoRequest inforequest)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {

                var cmd = new SqlCommand();

                cmd.CommandText = "AddInfoRequest";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cxn;
            
                cmd.Parameters.AddWithValue("@VehicleId", inforequest.VehicleId);
                cmd.Parameters.AddWithValue("@Name", inforequest.PersonName);
                cmd.Parameters.AddWithValue("@EmailAddress", inforequest.EmailAddress);
                cmd.Parameters.AddWithValue("@PhoneNumber", inforequest.PhoneNumber);
                cmd.Parameters.AddWithValue("@TimetoCallId", (((int)inforequest.TimetoCall)+1));
                cmd.Parameters.AddWithValue("@ContactMethodId", (((int)inforequest.ContactMethod)+1));
                cmd.Parameters.AddWithValue("@PurchaseTimeFrame", inforequest.PurchaseTimeFrame);
                cmd.Parameters.AddWithValue("@AdditionalInfo", inforequest.AdditionalInfo);
                cmd.Parameters.AddWithValue("@LastContactDate", inforequest.LastContactDate);
                cmd.Parameters.AddWithValue("@RequestStatusId", (((int)inforequest.Status)+1));
                
                cxn.Open();
                cmd.ExecuteNonQuery();
                cxn.Close();
            }
        }

        public void UpdateInfoRequestStatus(int inforequestId, RequestStatus requestStatus)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {

                var cmd = new SqlCommand();

                cmd.CommandText = "UpdateRequestStatus";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cxn;

                cmd.Parameters.AddWithValue("@InfoRequestId", inforequestId);             
                cmd.Parameters.AddWithValue("@RequestStatusId", ((int)requestStatus)+1);
                cmd.Parameters.AddWithValue("@LastContactDate", DateTime.Now);
                //cmd.Parameters.AddWithValue("@Price", (object)dvd.UserNotes ?? DBNull.Value);

                cxn.Open();
                cmd.ExecuteNonQuery();
                cxn.Close();
            }
        }

        private Vehicle PopulateVehicleFromDataReader(SqlDataReader dr)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.VehicleId = (int)dr["VehicleId"];
            vehicle.Make = dr["Make"].ToString();
            vehicle.Model = dr["Model"].ToString();
            vehicle.Year = (int)dr["Year"];
            vehicle.Mileage = (int)dr["Mileage"];
            vehicle.AdTitle = dr["AdTitle"].ToString();
            vehicle.Description = dr["Description"].ToString();
            vehicle.Price = (decimal)dr["Price"];
            vehicle.PicUrl = dr["PicUrl"].ToString();
            vehicle.IsAvailable = (bool)dr["IsAvailable"];

            return vehicle;
        }

        private InfoRequest PopulateInfoRequestFromDataReader(SqlDataReader dr)
        {
            InfoRequest inforequest = new InfoRequest();
            
            //if(dr["column"] != DBNull.Value)
            inforequest.InfoRequestId = (int)dr["InfoRequestId"];
            inforequest.VehicleId = (int)dr["VehicleId"];
            inforequest.PersonName = dr["Name"].ToString();
            inforequest.EmailAddress = dr["EmailAddress"].ToString();
            inforequest.PhoneNumber = dr["PhoneNumber"].ToString();
            inforequest.TimetoCall = (TimetoCall)((int)dr["TimetocallId"]-1);
            inforequest.ContactMethod = (ContactMethod)((int)dr["ContactMethodId"]-1);
            inforequest.PurchaseTimeFrame = (int)dr["PurchaseTimeFrame"];
            inforequest.AdditionalInfo = dr["AdditionalInfo"].ToString();
            inforequest.LastContactDate = (DateTime)dr["LastContactDate"];
            inforequest.Status = (RequestStatus)((int)dr["RequestStatusId"]-1);

            return inforequest;
        }

    }
}