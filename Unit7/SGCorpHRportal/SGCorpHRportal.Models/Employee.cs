using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCorpHRportal.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeId { get; set; }
        public List<TimeEntry> EmpTimeEntries { get; set; }
        public DateTime HireDate { get; set; }

        public decimal GetTotalEmpHours(List<TimeEntry> EmpTimeEntries)
        {
            decimal sum = 0;
            foreach (var entry in EmpTimeEntries)
                sum = sum + entry.HoursWorked;
            return sum;
        }

        public List<TimeEntry> SortTimeEntriesByDate(List<TimeEntry> EmpTimeEntries)
        {
             var result = EmpTimeEntries.OrderByDescending(e => e.dateTime).ToList();
             return result;
        }

    }
}
