using SGCorpHRportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHRPortal.Data.Interfaces
{
    public interface IPolicyRepository
    {
        IEnumerable<Policy> GetAll();
        IEnumerable<Policy> GetbyCat(string categoryName);
        void Add(Policy policy); 
        Policy Get(int policyId);
        void Edit(Policy policy);
        void Delete(string policyName, int policyId);

    }
}
