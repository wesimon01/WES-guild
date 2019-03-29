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
    public class DVDSQLRepository : IDVDRepository
    {
        private static string cxnStr = Settings.GetConnectionString();
       
        public List<DVD> GetAll()
        {
            var dvds = new List<DVD>();

            using (var cxn = new SqlConnection(cxnStr))
            using (var cmd = new SqlCommand("DVDGetAll", cxn))
            {                
                cmd.CommandType = CommandType.StoredProcedure;
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvds.Add(PopulateDVDFromDataReader(dr));
                    }
                }
            }
            return dvds;
        }

        public DVD Get(int dvdId)
        {
            var dvd = new DVD();

            using (var cxn = new SqlConnection(cxnStr))
            using (var cmd = new SqlCommand("DVDGetById", cxn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", dvdId);
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd = PopulateDVDFromDataReader(dr);
                    }
                }
            }
            return dvd;
        }

        public DVD GetbyTitle(string title)
        {
            var dvd = new DVD();

            using (var cxn = new SqlConnection(cxnStr))
            using (var cmd = new SqlCommand("DVDGetByTitle", cxn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", title);
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd = PopulateDVDFromDataReader(dr);
                    }
                }
            }
            return dvd;
        }

        public void AddDVD(DVD dvd)
        {
            using (var cxn = new SqlConnection(cxnStr))            
            using (var cmd = new SqlCommand("DVDInsert", cxn))
            {                    
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", dvd.ReleaseDate);
                cmd.Parameters.AddWithValue("@MPAARating", (int)dvd.MPAARating);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@Studio", dvd.Studio);
                cmd.Parameters.AddWithValue("@UserRating", dvd.UserRating);
                cmd.Parameters.AddWithValue("@UserNotes", (object)dvd.UserNotes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ActorsInMovie", dvd.ActorsInMovie);
                cmd.Parameters.AddWithValue("@IsBorrowed", dvd.IsBorrowed);

                cxn.Open();
                cmd.ExecuteNonQuery();
                dvd.Id = (int)cmd.Parameters["@Id"].Value;
            }            
        }

        public void EditDVD(DVD dvd)
        {
            using (var cxn = new SqlConnection(cxnStr))
            using (var cmd = new SqlCommand("DVDUpdate", cxn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", dvd.Id);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", dvd.ReleaseDate);
                cmd.Parameters.AddWithValue("@MPAARating", (int)dvd.MPAARating);
                cmd.Parameters.AddWithValue("@DirectorName", dvd.DirectorName);
                cmd.Parameters.AddWithValue("@Studio", dvd.Studio);
                cmd.Parameters.AddWithValue("@UserRating", dvd.UserRating);
                cmd.Parameters.AddWithValue("@UserNotes", (object)dvd.UserNotes ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ActorsInMovie", dvd.ActorsInMovie);
                cmd.Parameters.AddWithValue("@IsBorrowed", dvd.IsBorrowed);

                cxn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveDVD(int id)
        {
            using (var cxn = new SqlConnection(cxnStr))
            using (var cmd = new SqlCommand("DVDRemove", cxn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                
                cxn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Borrower> GetBorrowerList(int id)
        {
            var borrowerList = GetAllBorrowers();
            var dvdborrowerlist = (borrowerList.Where(b => b.dvdBorrowedId == id)).ToList();
            return dvdborrowerlist;
        }

        public List<Borrower> GetAllBorrowers()
        {
            var borrowers = new List<Borrower>();

            using (var cxn = new SqlConnection(cxnStr))
            using (var cmd = new SqlCommand("BorrowerGetAll", cxn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        borrowers.Add(PopulateBorrowerFromDataReader(dr));
                    }
                }
            }
            return borrowers;
        }

        private DVD PopulateDVDFromDataReader(SqlDataReader dr)
        {
            var dvd = new DVD();

            dvd.Id = (int)dr["Id"];
            dvd.Title = dr["Title"].ToString();
            dvd.ReleaseDate = (DateTime)dr["ReleaseDate"];
            dvd.MPAARating = (MPAARating)((int)dr["MPAARating"]);           
            dvd.DirectorName = dr["DirectorName"].ToString();
            dvd.Studio = dr["Studio"].ToString();
            dvd.UserRating = (decimal)dr["UserRating"];
            dvd.UserNotes = dr["UserNotes"].ToString();
            dvd.ActorsInMovie = dr["ActorsInMovie"].ToString();
            dvd.IsBorrowed = (bool)dr["IsBorrowed"];

            return dvd;
        }

        private Borrower PopulateBorrowerFromDataReader(SqlDataReader dr)
        {
            var borrower = new Borrower();

            borrower.BorrowerId = (int)dr["BorrowerId"];
            borrower.BorrowerName = dr["BorrowerName"].ToString();
            borrower.dvdBorrowedId = (int)dr["DVDBorrowedId"];

            if (dr["DateBorrowed"] != DBNull.Value)
                borrower.DateBorrowed = (DateTime)dr["DateBorrowed"];
            if (dr["DateReturned"] != DBNull.Value)
                borrower.DateBorrowed = (DateTime)dr["DateReturned"];

            return borrower;

        }

        


        //public List<MPAARating> MPAARatingGetAll()
        //{
        //    var ratings = new List<MPAARating>();

        //    using (cxn)
        //    using (var cmd = new SqlCommand("MPAARatingGetAll", (SqlConnection)cxn))
        //    {
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cxn.Open();

        //        using (SqlDataReader dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                ratings.Add(PopulateRatingFromDataReader(dr));
        //            }
        //        }
        //    }
        //    return ratings;
        //}

        //private MPAARating PopulateRatingFromDataReader(SqlDataReader dr)
        //{          
        //    var ratingId = (int)dr["MPAARatingId"];
        //    return (MPAARating)ratingId;
        //}
    }
}


