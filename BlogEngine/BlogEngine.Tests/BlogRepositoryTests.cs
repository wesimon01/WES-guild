using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Models;
using BlogEngine.Data;
using NUnit.Framework;


namespace BlogEngine.Tests
{
    public class BlogRepositoryTests
    {
        [TestFixture]
        public class repoTests
        {
            [Test]
            public void CanGetBlogpost()
            {
                BlogpostTestRepository repo = new BlogpostTestRepository();
                var blogpost = repo.GetBlogPost(1);

                Assert.AreEqual(1, blogpost.PostId);
                Assert.AreEqual("Lorem ipsum dolor sit amet", blogpost.Title);
                Assert.AreEqual(true, blogpost.IsApproved);
            }

            [Test]
            public void CanGetAllBlogPosts()
            {
                BlogpostTestRepository repo = new BlogpostTestRepository();
                var posts = repo.GetAllBlogPosts();

                Assert.AreEqual(4, posts.Count());
            }

            [Test]
            public void CanAddBlogpost()
            {
                BlogpostTestRepository repo = new BlogpostTestRepository();

                Blogpost post = new Blogpost
                {
                    PostId = 12,
                    Author = new Author { AuthorName = "Jeff" },
                    Title = "The West",
                    datePublished = DateTime.Now,
                    dateExpires = DateTime.Now.AddDays(3),
                    Content = "A new post about the west."
                };

                var numberOfPostsBefore = repo.GetAllBlogPosts().Count;
                repo.AddBlogPost(post);
                var numberOfPostsAfter = repo.GetAllBlogPosts().Count;
                Assert.AreEqual(numberOfPostsBefore + 1, numberOfPostsAfter);
            }

            [Test]
            public void CanGetAllHashTags()
            {
                BlogpostTestRepository repo = new BlogpostTestRepository();
                var hashtags = repo.GetAllHashTags();

                Assert.AreEqual(3, hashtags.Distinct().Count());
            }

            [Test]
            public void CanRemoveBlogPost()
            {

                BlogpostTestRepository repo = new BlogpostTestRepository();

                var numberOfPostsBefore = repo.GetAllBlogPosts().Count;
                repo.RemoveBlogPost(1);
                var numberOfPostsAfter = repo.GetAllBlogPosts().Count;

                var result = repo.GetAllBlogPosts().Count;

                Assert.AreEqual(numberOfPostsBefore - 1, numberOfPostsAfter);
            }

            [Test]
            public void CanGetPostsbyHashTag()
            {
                BlogpostTestRepository repo = new BlogpostTestRepository();

                var result = repo.GetPostsbyHashTag(new Hashtag { HashtagId = 2 }).Count;

                Assert.AreEqual(2, result);
            }

            [Test]
            public void CanGetPostsbyHashTagName()
            {
                BlogpostTestRepository repo = new BlogpostTestRepository();

                var result = repo.GetPostsbyHashTagName("Drinks").Count;

                Assert.AreEqual(2, result);
            }

            [Test]
            public void CanUpdateBlogPost()
            {
                BlogpostTestRepository repo = new BlogpostTestRepository();

                Blogpost post = new Blogpost
                {
                    PostId = 1,
                    Title = "The West"
                };

                repo.UpdateBlogPost(post);
                var result = repo.GetBlogPost(1).Title;
                Assert.AreEqual("The West", result);
            }
        }
    }
}
