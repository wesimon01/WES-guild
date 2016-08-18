using System.Collections.Generic;
using BlogEngine.Models;

namespace BlogEngine.Data
{
    public interface IPageTestRepository
    {
        void AddPage(Page page);
        List<Page> GetAllPages();
        Page GetPage(int pageId);
        void RemovePage(int pageId);
        void UpdatePage(Page page);
    }
}