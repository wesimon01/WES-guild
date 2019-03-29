using SGCorpHRportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHRPortal.Data.Interfaces
{
    public interface IEmployeeRepository
    {

        IEnumerable<Employee> GetAll();
        IEnumerable<TimeEntry> GetTimeEntries(int employeeId);
        Employee Get(int employeeId);
        void DeleteTimeEntry(int employeeId, DateTime date);
        void AddTimeEntry(TimeEntry timeEntry, int employeeId);
        
    }
}
