using SGCorpHRportal.Data;
using SGCorpHRPortal.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHRPortal.Data.Factory
{
    public class PolicyRepositoryFactory
    {

        public static IPolicyRepository GetRepository()
        {
            string repoType = Settings.GetRepoType();

            switch (repoType.ToUpper())
            {
                case "MOCK":
                    return new PolicyRepository();

                default:
                    throw new Exception("Unable to determine value for Category Repository from config file");
            }
        }

    }
}
