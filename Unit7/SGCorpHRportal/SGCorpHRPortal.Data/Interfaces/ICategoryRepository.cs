using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorpHRportal.Models;

namespace SGCorpHRPortal.Data.Interfaces
{
    public interface ICategoryRepository
    {
         IEnumerable<Category> GetAll();
         void Add(Category category);
         Category Get(int categoryId);
         void Edit(Category category);
         void Delete(string categoryName);
    }
}
