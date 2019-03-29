using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace BlogEngine.Data
{
    public class BlogpostSQLRepositoryDapper : IBlogpostTestRepository
    {
        private IDbConnection cxn = new SqlConnection(Settings.ConnectionString);

        public List<Blogpost> GetAllBlogPosts()
        {
            var blogposts = new List<Blogpost>();
            using (cxn)
            {
                blogposts = cxn.Query<Blogpost>("PostGetAll", commandType: CommandType.StoredProcedure).ToList();                    
            }
            foreach (var post in blogposts)
                     post.Hashtags = GetHashtagByPostId(post.PostId);

            return blogposts;
        }

        public Blogpost GetBlogPost(int postId)
        {
            var blogpost = new Blogpost();
            using (cxn)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PostID", postId);

                blogpost = cxn.Query<Blogpost>("PostGetByID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();             
            }
            blogpost.Hashtags = GetHashtagByPostId(blogpost.PostId);
            return blogpost;
        }

        public void AddBlogPost(Blogpost blogpost)
        {
            using (cxn)
            {
                var parameters = new DynamicParameters();
                if (!string.IsNullOrWhiteSpace(blogpost.Title))
                    parameters.Add("@Title", blogpost.Title);

                parameters.Add("@AuthorName", blogpost.Author.AuthorName);
                parameters.Add("@PublishDate", blogpost.datePublished);
                parameters.Add("@ExpireDate", blogpost.dateExpires);
                parameters.Add("@IsApproved", blogpost.IsApproved);
                parameters.Add("@PostContent", blogpost.Content);

                blogpost.PostId = cxn.ExecuteScalar<int>("PostInsert", parameters, commandType: CommandType.StoredProcedure);
            }
            AddHashtagListToDb(blogpost);
        }

        public void AddHashtagListToDb(Blogpost blogpost)
        {
            List<Hashtag> allHashtags = GetAllHashTags();
            foreach (var hashtag in blogpost.Hashtags)
            {
                if (!allHashtags.Exists(h => h.HashtagName == hashtag.HashtagName))
                {
                    int hashtagId = AddHashtag(hashtag);
                    AddToPostHash(blogpost.PostId, hashtagId);
                }
            }
        }

        public void AddToPostHash(int postId, int hashtagId)
        {
            using (cxn)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PostID", postId);
                parameters.Add("@HashtagID", hashtagId);

                cxn.Execute("PostHashInsert", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public int AddHashtag(Hashtag hashtag)
        {            
            using (cxn)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@HashtagName", hashtag.HashtagName);

                return cxn.ExecuteScalar<int>("HashtagInsert", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void RemoveBlogPost(int postId)
        {
            using (cxn)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PostID", postId);

                cxn.Execute("PostDelete", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateBlogPost(Blogpost blogpost)
        {
            using (cxn)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PostID", blogpost.PostId);    
                parameters.Add("@Title", blogpost.Title);
                parameters.Add("@AuthorName", blogpost.Author.AuthorName);
                parameters.Add("@PublishDate", blogpost.datePublished);
                parameters.Add("@ExpireDate", blogpost.dateExpires);
                parameters.Add("@IsApproved", blogpost.IsApproved);
                parameters.Add("@PostContent", blogpost.Content);

                cxn.Execute("PostUpdate", parameters, commandType: CommandType.StoredProcedure);
            }
            AddHashtagListToDb(blogpost);
        }

        public List<Blogpost> GetPostsbyHashTag(Hashtag hashtag)
        {
            using (cxn)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@HashtagID", hashtag.HashtagId);

                return cxn.Query<Blogpost>("PostGetByHashtagID", parameters, commandType: CommandType.StoredProcedure).ToList();              
            }            
        }

        public List<Hashtag> GetAllHashTags()
        {           
            using (cxn)
            {                
                return cxn.Query<Hashtag>("HashtagGetAll", commandType: CommandType.StoredProcedure).ToList();                   
            }           
        }

        public List<Hashtag> GetHashtagByPostId(int postId)
        {
            var hashtags = new List<Hashtag>();
            using (cxn)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PostID", postId);

                hashtags = cxn.Query<Hashtag>("HashtagGetByPostID", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
            return hashtags;
        }

        public List<Blogpost> GetPostsbyHashTagName(string hashtagName)
        {
            var allblogposts = GetAllBlogPosts();
            return allblogposts.Where(b => b.Hashtags.Exists(h => h.HashtagName == hashtagName)).ToList();
        }

     }
}

