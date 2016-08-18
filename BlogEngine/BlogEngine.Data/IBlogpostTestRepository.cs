using System.Collections.Generic;
using BlogEngine.Models;

namespace BlogEngine.Data
{
    public interface IBlogpostTestRepository
    {
        void AddBlogPost(Blogpost post);
        List<Blogpost> GetAllBlogPosts();
        Blogpost GetBlogPost(int postId);
        List<Blogpost> GetPostsbyHashTag(Hashtag hashtag);
        void RemoveBlogPost(int postId);
        void UpdateBlogPost(Blogpost post);
        List<Hashtag> GetAllHashTags();
        List<Blogpost> GetPostsbyHashTagName(string hashtagName);
    }
}