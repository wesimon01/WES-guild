using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.Models;
using DVDLibrary.BLL;
using DVDLibrary.UI.ViewModels;

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
            
           return View(_service.DVDObjectCreate());
        }

        [HttpPost]
        public ActionResult DVDadd(DVD dvd)
        {
            if (ModelState.IsValid)
            {
                _service.AddDVD(dvd);
                return RedirectToAction("DVDlist", "DVD");
            }
            return View(dvd);
        }

        [HttpGet]
        public ActionResult DVDdisplay(int? selectedDVDId)
        {
            if (selectedDVDId == null || selectedDVDId == 0 || _service.GetDVD(selectedDVDId.Value) == null)
            {
                return View(new DVDdisplayVM(_service));
            }

            else
            {
                DVDdisplayVM viewmodel = new DVDdisplayVM(_service);
                viewmodel._selectedDVDId = selectedDVDId.Value;
                return View(viewmodel);
            }
        }

        [HttpGet]
        public ActionResult DVDremove()
        {
            return View(new DVDremoveVM(_service));

        }

        [HttpPost]
        public ActionResult DVDremove(int? dvdId)
        {
            if (ModelState.IsValid && dvdId != null)
            {
                _service.RemoveDVD(dvdId.Value);
                return RedirectToAction("DVDremove");
            }
            return RedirectToAction("DVDremove");
        }

        [HttpGet]
        public ActionResult DVDsearch(int? selectedDVDId)
        {
            if (selectedDVDId == null || selectedDVDId == 0 || _service.GetDVD(selectedDVDId.Value) == null)
            {
                return View(new DVDsearchVM(_service));
            }

            else
            {
                DVDsearchVM viewmodel = new DVDsearchVM(_service);
                viewmodel._selectedDVDId = selectedDVDId.Value;
                return View(viewmodel);
            }
        }

        [HttpGet]
        public ActionResult DVDhistory(int? selectedDVDId)
        {
            if (selectedDVDId == null || selectedDVDId == 0 || _service.GetDVD(selectedDVDId.Value) == null)
            {
                return View(new DVDhistoryVM(_service));
            }

            else
            {
                DVDhistoryVM viewmodel = new DVDhistoryVM(_service);
                viewmodel._selectedDVDId = selectedDVDId.Value;
                return View(viewmodel);
            }
        }

    }
}