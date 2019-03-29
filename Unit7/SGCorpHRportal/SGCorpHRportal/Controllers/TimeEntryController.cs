using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHRportal.Models;
using SGCorpHRportal.UI.Models.ViewModels;
using SGCorpHRPortal.Data.Factory;
using SGCorpHRPortal.Data.Interfaces;

namespace SGCorpHRportal.UI.Controllers
{
    public class TimeEntryController : Controller
    {
        private IEmployeeRepository employeeRepo;

        public TimeEntryController()
        {
            employeeRepo = EmployeeRepositoryFactory.GetRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EmployeeSubmitTime()
        {
            TimeEntryVM viewmodel = new TimeEntryVM();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EmployeeSubmitTime(TimeEntryVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                employeeRepo.AddTimeEntry(viewmodel.TimeEntry, viewmodel.selectedEmployeeId);
                return RedirectToAction("EmployeeTimeSheet");
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult EmployeeTimeSheet(int? selectedEmpId)
        {

            if (selectedEmpId == null || selectedEmpId == 0 || employeeRepo.Get(selectedEmpId.Value) == null)
            {
                TimeSheetVM vm = new TimeSheetVM();
                return View(vm);
            }

            else
            {
                TimeSheetVM viewmodel = new TimeSheetVM();
                viewmodel.selectedEmployeeId = selectedEmpId.Value;
                return View(viewmodel);
            }
        }

        [HttpGet]
        public ActionResult TimeSheetDelete(int EmpId, DateTime date)
        {
            DeleteVM viewmodel = new DeleteVM();
            viewmodel.date = date;
            viewmodel.EmpId = EmpId;
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult TimeSheetDelete(DeleteVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                employeeRepo.DeleteTimeEntry(viewmodel.EmpId, viewmodel.date);
                return RedirectToAction("EmployeeTimeSheet");
            }
            return View(viewmodel);
        }



        // Helper Methods
        private List<SelectListItem> SetEmployeeItems(List<Employee> employees)
        {
            var employeeItems = new List<SelectListItem>();
            foreach (var employee in employees)
            {
                employeeItems.Add(new SelectListItem()
                {
                    Value = employee.EmployeeId.ToString(),
                    Text = GetWholeName(employee)
                });
            }
            return employeeItems;
        }

        private string GetWholeName(Employee employee)
        {
            string wholeName = employee.LastName + " , " + employee.FirstName;
            return wholeName;
        }
    }
}