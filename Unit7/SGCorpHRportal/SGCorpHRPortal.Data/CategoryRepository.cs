using SGCorpHRPortal.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGCorpHRportal.Models;

namespace SGCorpHRportal.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private static List<Category> _categories;

        static CategoryRepository()
        {
            // sample data
            _categories = new List<Category>
            {
                new Category {CategoryId = 1, CategoryName = "ShockAndAwe" },
                new Category {CategoryId = 2, CategoryName = "Goat" },
                new Category {CategoryId = 3, CategoryName = "SeverancePackages"  },
            };
        }

        public IEnumerable<Category> GetAll()
            {
            return _categories;          
            }

        public void Add(Category category)
        {
            category.CategoryId = _categories.Max(c => c.CategoryId) + 1;
            _categories.Add(category);
        }

        public Category Get(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public void Edit(Category category)
        {
            var selectedCategory = _categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (selectedCategory != null)
            {
                selectedCategory.CategoryName = category.CategoryName;             
            }
        }

        public void Delete(string categoryName)
        {
            _categories.RemoveAll(c => c.CategoryName == categoryName);
        }

    }
}