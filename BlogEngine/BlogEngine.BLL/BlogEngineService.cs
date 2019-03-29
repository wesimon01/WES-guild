using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Data;
using BlogEngine.Models;

namespace BlogEngine.BLL
{
    public class BlogEngineService : IBlogEngineService
    {
        private IBlogpostTestRepository _blogrepo;
        private IPageTestRepository _pagerepo;

        public BlogEngineService(IBlogpostTestRepository blogrepo, IPageTestRepository pagerepo)
        {
            _blogrepo = blogrepo;
            _pagerepo = pagerepo;
        }

        //***** BlogPost methods *****

        public List<Blogpost> GetAllBlogPosts()  
        {
            try {
                return _blogrepo.GetAllBlogPosts();
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetAllBlogPosts service module :", ex);
            }
        }

        public Blogpost GetBlogPost(int postId)  
        {
            try {
                return _blogrepo.GetBlogPost(postId);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetBlogPost service module :", ex);
            }
        }

        public List<Blogpost> GetPostsbyHashTag(Hashtag hashtag)
        {
            try {
                return _blogrepo.GetPostsbyHashTag(hashtag);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetPostsbyHashTag service module :", ex);
            }
        }

        public List<Blogpost> GetPostsbyHashTagName(string hashtagName)
        {
            try {
                return _blogrepo.GetPostsbyHashTagName(hashtagName);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetPostsbyHashTagName service module :", ex);
            }
        }

        public void AddBlogPost(Blogpost post)  
        {
            try {
                _blogrepo.AddBlogPost(post);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the AddBlogPost service module :", ex);
            }
        }

        public void RemoveBlogPost(int postId)  
        {
            try {
                _blogrepo.RemoveBlogPost(postId);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the RemoveBlogPost service module :", ex);
            }
        }

        public void UpdateBlogPost(Blogpost post)  
        {
            try {
                _blogrepo.UpdateBlogPost(post);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the UpdateBlogPost service module :", ex);
            }
        }

        public List<Hashtag> GetAllHashTags()
        {
            try {
                return _blogrepo.GetAllHashTags();
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetAllHashTags service module :", ex);               
            }
        }

        //***** Page Methods *****

        public List<Page> GetAllPages()  
        {
            try {
                return _pagerepo.GetAllPages();
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetAllPages service module :", ex);
            }
        }

        public Page GetPage(int pageId)  
        {
            try {
                return _pagerepo.GetPage(pageId);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetPage service module :", ex);
            }
        }

        public void AddPage(Page page)
        {
            try {
                _pagerepo.AddPage(page);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the AddPage service module :", ex);
            }
        }

        public void RemovePage(int pageId)
        {
            try {
                _pagerepo.RemovePage(pageId);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the RemovePage service module :", ex);
            }
        }

        public void UpdatePage(Page page)
        {
            try {
                _pagerepo.UpdatePage(page);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the UpdatePage service module :", ex);

            }
        }

        public List<Blogpost> GetPostsbyHashTagId(int id)
        {
            var hashtag = new Hashtag { HashtagId = id };
            List<Blogpost> posts;
            try {
                posts = _blogrepo.GetPostsbyHashTag(hashtag);
            }
            catch (Exception ex)
            {
                SimpleLog.StartLogging();
                SimpleLog.Log(ex);
                throw new ApplicationException("Something went wrong in the GetPostsbyHashTagId service module :", ex);
            }
            return posts;
        }
    }
}
