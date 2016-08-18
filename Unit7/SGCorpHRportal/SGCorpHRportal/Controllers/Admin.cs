using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHRportal.Models;
using SGCorpHRportal.Models.Repos;
using SGCorpHRportal.Models.ViewModels;

namespace SGCorpHRportal.Controllers
{
    public class AdminController : Controller
    {   
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
            CategoryRepository.Add(category);
            IEnumerable<Category> repo = CategoryRepository.GetAll();
            return View("CategoryManage", repo);
        }

        [HttpGet]
        public ActionResult CategoryManage()
        {
            IEnumerable<Category> CatList = CategoryRepository.GetAll();
            return View(CatList);
        }

        [HttpGet]
        public ActionResult CategoryDelete(int CategoryId)
        {
            Category selectedCategory = CategoryRepository.Get(CategoryId);
            return View(selectedCategory);
        }

        [HttpPost]
        public ActionResult CategoryDelete(Category selectedCategory)
        {
            CategoryRepository.Delete(selectedCategory.CategoryName);
            return RedirectToAction("CategoryManage");
        }






        [HttpGet]
        public ActionResult PolicyList(string CategoryName)
        {
            if (CategoryName == null || CategoryName == "")
            {
                IEnumerable<Policy> polList = PolicyRepository.GetAll();
                return View(polList);
            }
            else
            {
                IEnumerable<Policy> policyList = PolicyRepository.GetbyCat(CategoryName);
                return View(policyList);
            }
        }

        [HttpGet]
        public ActionResult PolicyContent(int PolicyId)
        {

            Policy selectedPolicy = PolicyRepository.Get(PolicyId);
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
            poladdvm.policy.Category = CategoryRepository.Get(poladdvm.policy.Category.CategoryId);
            PolicyRepository.Add(poladdvm.policy);

            return RedirectToAction("PolicyList");
        }

        [HttpGet]
        public ActionResult PolicyManage(string CategoryName)
        {
            if (CategoryName == null || CategoryName == "")
            {
                IEnumerable<Policy> polList = PolicyRepository.GetAll();
                return View(polList);
            }
            else
            {
                IEnumerable<Policy> policyList = PolicyRepository.GetbyCat(CategoryName);
                return View(policyList);
            }
        }

        [HttpGet]
        public ActionResult PolicyDelete(int PolicyId)
        {
            Policy selectedPolicy = PolicyRepository.Get(PolicyId);
            return View(selectedPolicy);
        }

        [HttpPost]
        public ActionResult PolicyDelete(Policy selectedPolicy)
        {
            PolicyRepository.Delete(selectedPolicy.PolicyName, selectedPolicy.PolicyId);
            return RedirectToAction("PolicyManage");
        }

    }
}