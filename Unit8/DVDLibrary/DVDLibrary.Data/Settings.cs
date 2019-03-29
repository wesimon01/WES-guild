using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DVDLibrary.Data
{
    public class Settings
    {
        private static string _repoType;
        private static string _connectionString;

        public static string GetConnectionString()
        {          
                if (string.IsNullOrEmpty(_connectionString))               
                    _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                
                return _connectionString;           
        }

        public static string GetRepoType()
        {
            if (string.IsNullOrEmpty(_repoType))
                _repoType = ConfigurationManager.AppSettings["RepositoryType"].ToString();

            return _repoType;
        }

    }
}
