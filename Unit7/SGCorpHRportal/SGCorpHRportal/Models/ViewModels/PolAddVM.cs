using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGCorpHRportal.Models;
using System.Web.Mvc;

namespace SGCorpHRportal.UI.Models.ViewModels
{
    public class PolAddVM
    {      
        //public int SelectedCatId { get; set; }
        public Policy policy { get; set; }
        public List<SelectListItem> CategoryItems { get; set; }
        
        public PolAddVM()
        {
            policy = new Policy();
            CategoryItems = new List<SelectListItem>();
            SetCategoryItems(CategoryRepository.GetAll());        
        }

        public void SetCategoryItems(IEnumerable<Category> categories)
        {
            foreach (var category in categories)
            {
                CategoryItems.Add(new SelectListItem()
                {
                    Value = category.CategoryId.ToString(),
                    Text = category.CategoryName                   
                });
            }
        }

    }
}