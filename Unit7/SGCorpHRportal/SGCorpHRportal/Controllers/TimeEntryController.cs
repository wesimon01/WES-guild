using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHRportal.Models.ViewModels;
using SGCorpHRportal.Models.Data;
using SGCorpHRportal.Models.Repos;

namespace SGCorpHRportal.Controllers
{
    public class TimeEntryController : Controller
    {

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
                EmployeeRepository.AddTimeEntry(viewmodel);
                return RedirectToAction("EmployeeTimeSheet");
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult EmployeeTimeSheet(int? selectedEmpId)
        {

            if (selectedEmpId == null || selectedEmpId == 0 || EmployeeRepository.Get(selectedEmpId.Value) == null)
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
                EmployeeRepository.DeleteTimeEntry(viewmodel.EmpId, viewmodel.date);
                return RedirectToAction("EmployeeTimeSheet");
            }
            return View(viewmodel);
        }
    }
}