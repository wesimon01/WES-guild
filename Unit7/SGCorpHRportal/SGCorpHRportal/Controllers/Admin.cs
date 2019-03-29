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
    public class AdminController : Controller
    {
        private ICategoryRepository categoryRepo;
        private IPolicyRepository policyRepo;

        public AdminController()
        {
            policyRepo = PolicyRepositoryFactory.GetRepository();
            categoryRepo = CategoryRepositoryFactory.GetRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View(new Category());
        }

        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            categoryRepo.Add(category);
            IEnumerable<Category> categories = categoryRepo.GetAll();
            return View("CategoryManage", categories);
        }

        [HttpGet]
        public ActionResult CategoryManage()
        {
            IEnumerable<Category> CatList = categoryRepo.GetAll();
            return View(CatList);
        }

        //[HttpGet]
        //public ActionResult CategoryDelete(int CategoryId)
        //{
        //    Category selectedCategory = CategoryRepository.Get(CategoryId);
        //    return View(selectedCategory);
        //}

        [HttpPost]
        public ActionResult CategoryDelete(Category selectedCategory)
        {

            categoryRepo.Delete(selectedCategory.CategoryName);
            return RedirectToAction("CategoryManage");
        }

        [HttpGet]
        public ActionResult PolicyList(string CategoryName)
        {
            if (CategoryName == null || CategoryName == "")
            {
                IEnumerable<Policy> polList = policyRepo.GetAll();
                return View(polList);
            }
            else
            {
                IEnumerable<Policy> policyList = policyRepo.GetbyCat(CategoryName);
                return View(policyList);
            }
        }

        [HttpGet]
        public ActionResult PolicyContent(int PolicyId)
        {

            Policy selectedPolicy = policyRepo.Get(PolicyId);
            return View(selectedPolicy);
        }

        [HttpGet]
        public ActionResult PolicyAdd()
        {
            return View(new PolAddVM());
        }

        [HttpPost]
        public ActionResult PolicyAdd(PolAddVM poladdvm)
        {
            poladdvm.policy.Category = categoryRepo.Get(poladdvm.policy.Category.CategoryId);
            policyRepo.Add(poladdvm.policy);

            return RedirectToAction("PolicyList");
        }

        [HttpGet]
        public ActionResult PolicyManage(string CategoryName)
        {
            if (CategoryName == null || CategoryName == "")
            {
                IEnumerable<Policy> polList = policyRepo.GetAll();
                return View(polList);
            }
            else
            {
                IEnumerable<Policy> policyList = policyRepo.GetbyCat(CategoryName);
                return View(policyList);
            }
        }

        [HttpGet]
        public ActionResult PolicyDelete(int policyId)
        {
            Policy selectedPolicy = policyRepo.Get(policyId);
            return View(selectedPolicy);
        }

        [HttpPost]
        public ActionResult PolicyDelete(Policy selectedPolicy)
        {
            policyRepo.Delete(selectedPolicy.PolicyName, selectedPolicy.PolicyId);
            return RedirectToAction("PolicyManage");
        }

    }
}