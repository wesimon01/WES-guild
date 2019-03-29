﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SGCorpHRPortal.Data
{
    public class Settings
    {
        private static string _repoType;
        private static string _cxnStr;

        public static string GetRepoType()
        {
            if (string.IsNullOrEmpty(_repoType))
                _repoType = ConfigurationManager.AppSettings["RepositoryType"].ToString();

            return _repoType;
        }

        //public static string GetConnectionString()
        //{
        //    if (string.IsNullOrEmpty(_cxnStr))
        //        _cxnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //    return _cxnStr;

        //}
    }
}