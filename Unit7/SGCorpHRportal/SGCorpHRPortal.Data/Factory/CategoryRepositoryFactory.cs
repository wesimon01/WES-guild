using SGCorpHRPortal.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHRportal.Data;

namespace SGCorpHRPortal.Data.Factory
{
    public class CategoryRepositoryFactory
    {
        public static ICategoryRepository GetRepository()
        {
            string repoType = Settings.GetRepoType();

            switch (repoType.ToUpper())
            {
                case "MOCK":
                    return new CategoryRepository();

                default:
                    throw new Exception("Unable to determine value for Category Repository from config file");
            }
        }


    }
}
