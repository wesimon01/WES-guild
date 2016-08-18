using BlogEngine.BLL;
using BlogEngine.Data;
using BlogEngine.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Tests
{
    public class BlogEngineServiceTests
    {
        // Page Tests
        [Test]
        public void CanGetAllPages()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var result = svc.GetAllPages().Count;

            Assert.AreEqual(4, result);
        }

        [Test]
        public void CanGetPage()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var result = svc.GetPage(1).Title;

            Assert.AreEqual("Biography", result);
        }

        [Test]
        public void CanRemovePage()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var pageCountBefore = svc.GetAllPages().Count;
            svc.RemovePage(1);
            var pageCountAfter = svc.GetAllPages().Count;

            Assert.AreEqual(pageCountBefore - 1, pageCountAfter);
        }

        [Test]
        public void CanAddPage()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var page = new Page
            {
                PageId = 12,
                Title = "Dirt",
                Content = "Synth mumblecore brunch narwhal thundercats",
            };

            var pageCountBefore = svc.GetAllPages().Count;
            svc.AddPage(page);
            var pageCountAfter = svc.GetAllPages().Count;

            Assert.AreEqual(pageCountBefore + 1, pageCountAfter);
        }

        [Test]
        public void CanUpdatePage()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var page = new Page
            {
                PageId = 1,
                Title = "Dirt",
                Content = "Synth mumblecore brunch narwhal thundercats",
            };

            svc.UpdatePage(page);
            var actual = svc.GetPage(1);

            Assert.AreEqual("Dirt", actual.Title);
        }

        // Post tests
        [Test]
        public void CanGetBlogpost()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var blogpost = svc.GetBlogPost(1);

            Assert.AreEqual(1, blogpost.PostId);
            Assert.AreEqual("Lorem ipsum dolor sit amet", blogpost.Title);
            Assert.AreEqual(true, blogpost.IsApproved);
        }

        [Test]
        public void CanGetAllBlogPosts()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var posts = svc.GetAllBlogPosts();

            Assert.AreEqual(4, posts.Count());
        }

        [Test]
        public void CanAddBlogpost()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            Blogpost post = new Blogpost
            {
                PostId = 12,
                Author = new Author { AuthorName = "Jeff" },
                Title = "The West",
                datePublished = DateTime.Now,
                dateExpires = DateTime.Now.AddDays(3),
                Content = "A new post about the west."
            };

            var numberOfPostsBefore = svc.GetAllBlogPosts().Count;
            svc.AddBlogPost(post);
            var numberOfPostsAfter = svc.GetAllBlogPosts().Count;
            Assert.AreEqual(numberOfPostsBefore + 1, numberOfPostsAfter);
        }

        [Test]
        public void CanGetAllHashTags()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var hashtags = svc.GetAllHashTags();

            Assert.AreEqual(3, hashtags.Distinct().Count());
        }

        [Test]
        public void CanRemoveBlogPost()
        {

            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var numberOfPostsBefore = svc.GetAllBlogPosts().Count;
            svc.RemoveBlogPost(1);
            var numberOfPostsAfter = svc.GetAllBlogPosts().Count;

            var result = svc.GetAllBlogPosts().Count;

            Assert.AreEqual(numberOfPostsBefore - 1, numberOfPostsAfter);
        }

        [Test]
        public void CanGetPostsbyHashTag()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var result = svc.GetPostsbyHashTag(new Hashtag { HashtagId = 2 }).Count;

            Assert.AreEqual(2, result);
        }

        [Test]
        public void CanGetPostsbyHashTagName()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            var result = svc.GetPostsbyHashTagName("Drinks").Count;

            Assert.AreEqual(2, result);
        }

        [Test]
        public void CanUpdateBlogPost()
        {
            var svc = new BlogEngineService(new BlogpostTestRepository(), new PageTestRepository());

            Blogpost post = new Blogpost
            {
                PostId = 1,
                Title = "The West"
            };

            svc.UpdateBlogPost(post);
            var result = svc.GetBlogPost(1).Title;
            Assert.AreEqual("The West", result);
        }
    }
}
