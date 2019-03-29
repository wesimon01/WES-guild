using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DVDLibrary.Data
{
    public class DVDDapperRepository : IDVDRepository
    {
        private static string cxnStr = Settings.GetConnectionString();

        public void AddDVD(DVD dvd)
        {
            using (var cxn = new SqlConnection(cxnStr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", ParameterDirection.Output);
                parameters.Add("@Title", dvd.Title);
                parameters.Add("@ReleaseDate", dvd.ReleaseDate);
                parameters.Add("@MPAARating", (int)dvd.MPAARating);
                parameters.Add("@DirectorName", dvd.DirectorName);
                parameters.Add("@Studio", dvd.Studio);
                parameters.Add("@UserRating", dvd.UserRating);
                parameters.Add("@UserNotes", (object)dvd.UserNotes ?? DBNull.Value);
                parameters.Add("@ActorsInMovie", dvd.ActorsInMovie);
                parameters.Add("@IsBorrowed", dvd.IsBorrowed);

                cxn.Execute("DVDInsert", parameters, commandType: CommandType.StoredProcedure);
                dvd.Id = parameters.Get<int>("@Id");
            }            
        }

        public void EditDVD(DVD dvd)
        {
            using (var cxn = new SqlConnection(cxnStr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", dvd.Id);
                parameters.Add("@Title", dvd.Title);
                parameters.Add("@ReleaseDate", dvd.ReleaseDate);
                parameters.Add("@MPAARating", (int)dvd.MPAARating);
                parameters.Add("@DirectorName", dvd.DirectorName);
                parameters.Add("@Studio", dvd.Studio);
                parameters.Add("@UserRating", dvd.UserRating);
                parameters.Add("@UserNotes", (object)dvd.UserNotes ?? DBNull.Value);
                parameters.Add("@ActorsInMovie", dvd.ActorsInMovie);
                parameters.Add("@IsBorrowed", dvd.IsBorrowed);

                cxn.Execute("DVDUpdate", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public DVD Get(int dvdId)
        {
            var dvd = new DVD();
            using (var cxn = new SqlConnection(cxnStr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", dvdId);
                dvd = cxn.QuerySingle<DVD>("DVDGetById", parameters, commandType: CommandType.StoredProcedure);
            }
            return dvd;
        }

        public List<DVD> GetAll()
        {
            var dvds = new List<DVD>();
            using (var cxn = new SqlConnection(cxnStr))
            {
                dvds = cxn.Query<DVD>("DVDGetAll", commandType: CommandType.StoredProcedure).ToList();
            }
            return dvds;
        }

        public List<Borrower> GetAllBorrowers()
        {
            var borrowers = new List<Borrower>();
            using (var cxn = new SqlConnection(cxnStr))
            {
                borrowers = cxn.Query<Borrower>("BorrowerGetAll", commandType: CommandType.StoredProcedure).ToList();
            }
            return borrowers;
        }

        public List<Borrower> GetBorrowerList(int id)
        {
            var borrowerList = GetAllBorrowers();
            var dvdborrowerlist = borrowerList.Where(b => b.dvdBorrowedId == id).ToList();
            return dvdborrowerlist;
        }

        public DVD GetbyTitle(string title)
        {
            var dvd = new DVD();
            using (var cxn = new SqlConnection(cxnStr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@title", title);               
                dvd = cxn.QuerySingle<DVD>("DVDGetByTitle", parameters, commandType: CommandType.StoredProcedure);
            }
            return dvd;
        }

        public void RemoveDVD(int id)
        {           
            using (var cxn = new SqlConnection(cxnStr))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                cxn.Execute("DVDRemove", parameters, commandType: CommandType.StoredProcedure);
            }           
        }        
    }
}
