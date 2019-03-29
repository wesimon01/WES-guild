using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BlogEngine.Data
{
    public static class Settings
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))                
                    _connectionString = ConfigurationManager.ConnectionStrings["BlogEngine"].ConnectionString;
                
                return _connectionString;
            }
        }
    }
}
