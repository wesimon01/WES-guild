using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Models;

namespace BlogEngine.Data
{
    public class PageTestRepository : IPageTestRepository
    {
        private static List<Page> _pages;

        public PageTestRepository()
        {
            if (_pages == null)
            {
                _pages = new List<Page>()
            {

            new Page {
            PageId = 1,
            Title = "Biography",
            Content = "Synth mumblecore brunch narwhal thundercats",                
            },

            new Page {
            PageId = 2,
            Title = "AboutUS",
            Content = "Synth mumblecore brunch narwhal thundercats",
            },

            new Page {
            PageId = 3,
            Title = "MumbleCore",
            Content = "Synth mumblecore brunch narwhal thundercats",
            },
            
            new Page {
            PageId = 4,
            Title = "AutoBiography",
            Content = "Synth mumblecore brunch narwhal thundercats",
            }

                };
            };
        }

        public Page GetPage(int pageId)
        {
            return _pages.FirstOrDefault(p => p.PageId == pageId);
        }

        public List<Page> GetAllPages()
        {
            return _pages;
        }

        public void AddPage(Page page)
        {
            if (_pages.Any())
                page.PageId = _pages.Max(p => p.PageId) + 1;
            else
                page.PageId = 1;

            _pages.Add(page);
        }

        public void RemovePage(int pageId)
        {
            Page selectedpage = _pages.FirstOrDefault(p => p.PageId == pageId);

            if (selectedpage != null)           
                _pages.RemoveAll(p => p.PageId == selectedpage.PageId);            
        }

        public void UpdatePage(Page page)
        {
            Page pageToUpdate = GetPage(page.PageId);

            pageToUpdate.Title = page.Title;            
            pageToUpdate.Content = page.Content;              
        }

    }
}
