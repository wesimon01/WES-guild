using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;
using System.Data.SqlClient;
using System.Data;

namespace DVDLibrary.Data
{
    public class DVDSQLRepository
    {
        public List<DVD> GetAll()
        {
            List<DVD> dvds = new List<DVD>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAllDVDS";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
               
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvds.Add(PopulateFromDataReader(dr));
                    }
                }
            }

            return dvds;
        }

        public DVD Get(int dvdId)
        {
            DVD dvd = new DVD();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "GetDVDbyId";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Id", dvdId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd = PopulateFromDataReader(dr);
                    }
                }
            }
            return dvd;
        }
        
        public void AddDVD(DVD dvd)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
               
                var cmd = new SqlCommand();
                
                cmd.CommandText = "InsertDVD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                

                //var newId = cmd.ExecuteScalar();
                //cmd.Parameters.AddWithValue("@Id", (int)cmd.ExecuteScalar());
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", dvd.ReleaseDate);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@Studio", dvd.Studio);
                cmd.Parameters.AddWithValue("@UserRating", dvd.UserRating);
                cmd.Parameters.AddWithValue("@UserNotes", (object)dvd.UserNotes ??DBNull.Value);
                cmd.Parameters.AddWithValue("@ActorsInMovie", dvd.ActorsInMovie);

                cn.Open();
                cmd.ExecuteNonQuery();
                int Id = (int)cmd.ExecuteScalar();
                cn.Close();              
            }
        }   

       private DVD PopulateFromDataReader(SqlDataReader dr)
        {
            DVD dvd = new DVD();

            dvd.Id = (int)dr["Id"];
            dvd.Title = dr["Title"].ToString();
            dvd.ReleaseDate = (DateTime)dr["ReleaseDate"];
            dvd.Rating = (MPAARating)((int)dr["Rating"]);
            //string RatingString  = dr["Rating"].ToString();
            //dvd.Rating = (MPAARating)Enum.Parse(typeof(MPAARating), RatingString);

            dvd.DirectorName = dr["DirectorName"].ToString();
            dvd.Studio = dr["Studio"].ToString();
            dvd.UserRating = (decimal)dr["UserRating"];
            dvd.UserNotes = dr["UserNotes"].ToString();
            dvd.ActorsInMovie = dr["ActorsInMovie"].ToString();

            return dvd;




            //if (dr["BirthDate"] != DBNull.Value)
            //    employee.BirthDate = (DateTime)dr["BirthDate"];

            //if (dr["ReportsTo"] != DBNull.Value)
            //{
            //    employee.ReportsTo = (int)dr["ReportsTo"];
            //    employee.ManagerName = string.Format("{0} {1}",
            //        dr["ManagerFirstName"].ToString(),
            //        dr["ManagerLastName"].ToString());
            //}

        }
    }
}


