using System.Collections.Generic;
using BlogEngine.Models;

namespace BlogEngine.BLL
{
    public interface IBlogEngineService
    {
        void AddBlogPost(Blogpost post);
        void AddPage(Page page);
        List<Blogpost> GetAllBlogPosts();
        List<Page> GetAllPages();
        Blogpost GetBlogPost(int postId);
        Page GetPage(int pageId);
        List<Blogpost> GetPostsbyHashTag(Hashtag hashtag);
        void RemoveBlogPost(int postId);
        void RemovePage(int pageId);
        void UpdateBlogPost(Blogpost post);
        void UpdatePage(Page page);
        List<Hashtag> GetAllHashTags();
        List<Blogpost> GetPostsbyHashTagName(string hashtagName);
        List<Blogpost> GetPostsbyHashTagId(int id);
    }
}