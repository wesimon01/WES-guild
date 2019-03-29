using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGCorpHRportal.Data;
using SGCorpHRportal.Models;
using SGCorpHRPortal.Data.Interfaces;

namespace SGCorpHRportal.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> _employees;

        static EmployeeRepository()
        {         
            _employees = new List<Employee>
            {
                new Employee {
                    FirstName = "Tesla",
                    LastName = "Test",
                    EmployeeId = 1,
                    HireDate = new DateTime(2016,6,1),
                    EmpTimeEntries = new List<TimeEntry>
                {
                    new TimeEntry
                    {
                        HoursWorked = 9.00M,
                        dateTime = new DateTime(2016,7,11),
                        
                    },
                    new TimeEntry
                    {
                        HoursWorked = 8.00M,
                        dateTime = new DateTime(2016,7,12),

                    }
                    },
                },

                new Employee {
                    FirstName = "Goatly",
                    LastName = "GoatsMan",
                    EmployeeId = 2,
                    HireDate = new DateTime(2016,6,3),
                    EmpTimeEntries = new List<TimeEntry>
                {
                    new TimeEntry
                    {
                        HoursWorked = 10.00M,
                        dateTime = new DateTime(2016,7,13),

                    },
                    new TimeEntry
                    {
                        HoursWorked = 8.00M,
                        dateTime = new DateTime(2016,7,14),

                    }
                    },
                },
                new Employee {
                    FirstName = "PollyWants",
                    LastName = "Cracker",
                    EmployeeId = 3,
                    HireDate = new DateTime(2016,6,5),
                    EmpTimeEntries = new List<TimeEntry>
                {
                    new TimeEntry
                    {
                        HoursWorked = 10.00M,
                        dateTime = new DateTime(2016,7,12),

                    },
                    new TimeEntry
                    {
                        HoursWorked = 15.00M,
                        dateTime = new DateTime(2016,7,14),
                    }
                    },
                },
         };
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee Get(int employeeId)
        {
            return _employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        public void DeleteTimeEntry(int employeeId, DateTime date)
        {
            Employee selectedEmployee = _employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            List<TimeEntry> empTimeEntries = selectedEmployee.EmpTimeEntries;
            empTimeEntries.RemoveAll(e => e.dateTime.ToString("MM/dd/yyyy") == date.ToString("MM/dd/yyyy"));
        }

        public void AddTimeEntry(TimeEntry timeEntry, int employeeId)
        {
            Employee selectedEmployee = _employees.FirstOrDefault(e => e.EmployeeId == employeeId);           
            selectedEmployee.EmpTimeEntries.Add(timeEntry);
        }

        public IEnumerable<TimeEntry> GetTimeEntries(int employeeId)
        {
            Employee employee = Get(employeeId);
            return employee.EmpTimeEntries;

        }
       
    }
}