using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BlogEngine.Models;
using BlogEngine.Data;

namespace BlogEngine.Tests
{
    [TestFixture]
    public class PageRepositoryTests
    {
        [Test]
        public void CanGetAllPages()
        {
            var repo = new PageTestRepository();
            
            var result = repo.GetAllPages().Count;

            Assert.AreEqual(4, result);
        }

        [Test]
        public void CanGetPage()
        {
            var repo = new PageTestRepository();

            var result = repo.GetPage(1).Title;

            Assert.AreEqual("Biography", result);
        }
        
        [Test]
        public void CanRemovePage()
        {
            var repo = new PageTestRepository();

            var pageCountBefore = repo.GetAllPages().Count;
            repo.RemovePage(1);
            var pageCountAfter = repo.GetAllPages().Count;

            Assert.AreEqual(pageCountBefore - 1, pageCountAfter);
        }

        [Test]
        public void CanAddPage()
        {
            var repo = new PageTestRepository();

            var page = new Page
            {
                PageId = 12,
                Title = "Dirt",
                Content = "Synth mumblecore brunch narwhal thundercats",
            };

            var pageCountBefore = repo.GetAllPages().Count;
            repo.AddPage(page);
            var pageCountAfter = repo.GetAllPages().Count;
            
            Assert.AreEqual(pageCountBefore + 1, pageCountAfter);
        }

        [Test]
        public void CanUpdatePage()
        {
            var repo = new PageTestRepository();

            var page = new Page
            {
                PageId = 1,
                Title = "Dirt",
                Content = "Synth mumblecore brunch narwhal thundercats",
            };

            repo.UpdatePage(page);
            var actual = repo.GetPage(1);

            Assert.AreEqual("Dirt", actual.Title);
        }
    }
}
