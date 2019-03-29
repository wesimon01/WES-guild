using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.Models;
using DVDLibrary.BLL;
using DVDLibrary.UI.ViewModels;
using DVDLibrary.UI.Util;

namespace DVDLibrary.UI
{
    public class DVDController : Controller
    {
        IDVDService _service;
       
        public DVDController(IDVDService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DVDlist()
        {
            var list = _service.GetDVDlist();

            if (list != null)
            {
                return View(list);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DVDadd()
        {            
           return View(new DVDAddVM());
        }

        [HttpPost]
        public ActionResult DVDadd(DVDAddVM viewModel)
        {
            if (ModelState.IsValid)
            {
                _service.AddDVD(viewModel.DVD);
                return RedirectToAction("DVDlist", "DVD");
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult DVDEdit(int id)
        {
            var viewModel = new DVDEditVM();
            viewModel.DVD = _service.GetDVD(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DVDEdit(DVDEditVM viewmodel)
        {
            if (ModelState.IsValid)
            {
                _service.EditDVD(viewmodel.DVD);
                return RedirectToAction("DVDlist", "DVD");
            }
            return View(viewmodel);
        }


        [HttpGet]
        public ActionResult DVDdisplay(int? selectedDVDId)
        {
            var viewModel = new DVDdisplayVM();
            if (selectedDVDId == null || selectedDVDId == 0 || _service.GetDVD(selectedDVDId.Value) == null)
            {
                viewModel.DVDs = _service.GetDVDlist();
                viewModel.DVDItems = Utilities.SetDVDItems(viewModel.DVDs);
                return View(viewModel);
            }
            else
            {
                viewModel.DVDs = _service.GetDVDlist();
                viewModel.DVDItems = Utilities.SetDVDItems(viewModel.DVDs);
                viewModel.selectedDVD = viewModel.DVDs.Where(d => d.Id == selectedDVDId).FirstOrDefault();
                viewModel.dvdId = viewModel.selectedDVD.Id;
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult DVDhistory(int? selectedDVDId)
        {
            var viewModel = new DVDhistoryVM();
            if (selectedDVDId == null || selectedDVDId == 0 || _service.GetDVD(selectedDVDId.Value) == null)
            {
                viewModel.DVDs = _service.GetDVDlist();
                viewModel.DVDItems = Utilities.SetDVDItems(viewModel.DVDs);
                return View(viewModel);
            }
            else
            {
                viewModel.DVDs = _service.GetDVDlist();
                viewModel.DVDItems = Utilities.SetDVDItems(viewModel.DVDs);
                viewModel.selectedDVD = viewModel.DVDs.Where(d => d.Id == selectedDVDId).FirstOrDefault();
                viewModel.dvdId = viewModel.selectedDVD.Id;
                viewModel.selectedDVD.BorrowerList = _service.GetBorrowerList(viewModel.selectedDVD.Id);
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult DVDsearch(int? selectedDVDId)
        {
            var viewModel = new DVDsearchVM();
            if (selectedDVDId == null || selectedDVDId == 0 || _service.GetDVD(selectedDVDId.Value) == null)
            {
                viewModel.DVDs = _service.GetDVDlist();
                return View(viewModel);
            }
            else
            {
                viewModel.DVDs = _service.GetDVDlist();
                viewModel._selectedDVDId = selectedDVDId.Value;
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult DVDremove()
        {           
            var viewModel = _service.GetDVDlist();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DVDremove(int? dvdId)
        {
            if (dvdId != null)
            {
                _service.RemoveDVD(dvdId.Value);
                return RedirectToAction("DVDremove");
            }
            return RedirectToAction("DVDremove");
        }

    }
}