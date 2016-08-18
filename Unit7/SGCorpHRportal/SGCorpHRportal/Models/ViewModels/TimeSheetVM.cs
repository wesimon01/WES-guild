using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGCorpHRportal.Models.Data;
using System.Web.Mvc;
using SGCorpHRportal.Models.Repos;


namespace SGCorpHRportal.Models.ViewModels
{
    public class TimeSheetVM
    {
        public List<SelectListItem> EmployeeItems { get; set; }
        public Employee employee { get; set; }
        public List<Employee> _employees {get; set;}
        public int selectedEmployeeId { get; set; }

        public TimeSheetVM()
        {
            _employees = EmployeeRepository.GetAll();
            EmployeeItems = new List<SelectListItem>();
            SetEmployeeItems(EmployeeRepository.GetAll());
        }

        public void SetEmployeeItems(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                EmployeeItems.Add(new SelectListItem()
                {
                    Value = employee.EmployeeId.ToString(),
                    Text = GetWholeName(employee)
                });
            }
        }

        public Employee Get(int EmpId)
        {
            return _employees.FirstOrDefault(e => e.EmployeeId == EmpId);
        }


        public string GetWholeName(Employee employee)
        {
            string wholeName = employee.LastName + " , " + employee.FirstName;
            return wholeName;
        }

    }
}