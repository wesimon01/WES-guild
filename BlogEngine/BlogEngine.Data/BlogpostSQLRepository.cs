using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Models;
using System.Data.SqlClient;
using System.Data;

namespace BlogEngine.Data
{
    public class BlogpostSQLRepository : IBlogpostTestRepository
    {
        public List<Blogpost> GetAllBlogPosts()
        {
            var blogposts = new List<Blogpost>();
            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PostGetAll", cxn))
                {                    
                    cmd.CommandType = CommandType.StoredProcedure;                   
                    cxn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            blogposts.Add(PopulateBlogpostFromDataReader(dr));
                        }
                    }
                }                
            }
            foreach(var post in blogposts)            
                    post.Hashtags = GetHashtagByPostId(post.PostId);
            
            return blogposts;
        }

        public Blogpost GetBlogPost(int postId)
        {
            var blogpost = new Blogpost();
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PostGetByID", cxn))
                {                                      
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PostID", postId);                    
                    cxn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            blogpost = PopulateBlogpostFromDataReader(dr);
                        }
                    }
                }                
            }
            blogpost.Hashtags = GetHashtagByPostId(blogpost.PostId);
            return blogpost;
        }

        public void AddBlogPost(Blogpost blogpost)
        {        
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PostInsert", cxn))
                {                                       
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    if (blogpost.Title != null)
                        cmd.Parameters.AddWithValue("@Title", blogpost.Title);

                    cmd.Parameters.AddWithValue("@AuthorName", blogpost.Author.AuthorName);
                    cmd.Parameters.AddWithValue("@PublishDate", blogpost.datePublished);
                    cmd.Parameters.AddWithValue("@ExpireDate", blogpost.dateExpires);
                    cmd.Parameters.AddWithValue("@IsApproved", blogpost.IsApproved);
                    cmd.Parameters.AddWithValue("@PostContent", blogpost.Content);

                    cxn.Open();
                    blogpost.PostId = (int)cmd.ExecuteScalar();                    
                }               
            }
            AddHashtagListToDb(blogpost);
        }

        public void AddHashtagListToDb(Blogpost blogpost)
        {
            int hashtagId;
            var allHashtags = GetAllHashTags();
            foreach (var hashtag in blogpost.Hashtags)
            {
                if (!allHashtags.Exists(h => h.HashtagName == hashtag.HashtagName))
                {
                    hashtagId = AddHashtag(hashtag);
                    AddToPostHash(blogpost.PostId, hashtagId);
                }
            }
        }

        public void AddToPostHash(int postId, int hashtagId)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PostHashInsert", cxn))
                {                    
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue("@PostID", postId);
                    cmd.Parameters.AddWithValue("@HashtagID", hashtagId);

                    cxn.Open();
                    cmd.ExecuteNonQuery();                   
                }               
            }
        }

        public int AddHashtag(Hashtag hashtag)
        {
            int hashtagId;
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("HashtagInsert", cxn))
                {                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HashtagName", hashtag.HashtagName);
                    cxn.Open();
                    hashtagId = (int)cmd.ExecuteScalar();               
                }                
            }
            return hashtagId;
        }

        public void RemoveBlogPost(int postId)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PostDelete", cxn))
                {                    
                    cmd.CommandType = CommandType.StoredProcedure;                   
                    cmd.Parameters.AddWithValue("@PostID", postId);

                    cxn.Open();
                    cmd.ExecuteNonQuery();                   
                }                   
            }
        }

        public void UpdateBlogPost(Blogpost post)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PostUpdate", cxn))
                {                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@PostID", post.PostId);
                    cmd.Parameters.AddWithValue("@Title", post.Title);
                    cmd.Parameters.AddWithValue("@AuthorName", post.Author.AuthorName);
                    cmd.Parameters.AddWithValue("@PublishDate", post.datePublished);
                    cmd.Parameters.AddWithValue("@ExpireDate", post.dateExpires);
                    cmd.Parameters.AddWithValue("@IsApproved", post.IsApproved);
                    cmd.Parameters.AddWithValue("@PostContent", post.Content);

                    cxn.Open();
                    cmd.ExecuteNonQuery();                   
                }                  
            }
            AddHashtagListToDb(post);
        }

        public List<Blogpost> GetPostsbyHashTag(Hashtag hashtag)
        {
            var blogposts = new List<Blogpost>();
            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("PostGetByHashtagID", cxn))
                { 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HashtagID", hashtag.HashtagId);                   
                    cxn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            blogposts.Add(PopulateBlogpostFromDataReader(dr));
                        }
                    }
                }               
            }
            return blogposts;
        }
       
        public List<Hashtag> GetAllHashTags()
        {
            var hashtags = new List<Hashtag>();
            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("HashtagGetAll", cxn))
                {
                    cmd.CommandText = "HashtagGetAll";
                    cmd.CommandType = CommandType.StoredProcedure;                   
                    cxn.Open(); 
                    
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            hashtags.Add(PopulateHashtagFromDataReader(dr));
                        }
                    }
                }              
            }
            return hashtags;
        }
    
        public List<Hashtag> GetHashtagByPostId(int postId)
        {
            var hashtags = new List<Hashtag>();
            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("HashtagGetByPostID", cxn))
                {                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PostID", postId);
                    cxn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            hashtags.Add(PopulateHashtagFromDataReader(dr));
                        }
                    }
                }               
            }
            return hashtags;
        }

        public List<Blogpost> GetPostsbyHashTagName(string hashtagName)
        {
            var allblogposts = GetAllBlogPosts();
            return allblogposts.Where(h => h.Hashtags.Exists(n => n.HashtagName == hashtagName)).ToList();
        }

        private List<Hashtag> PopulateHashtagsFromDataReaderWithId(int postId)
        {
            var hashtags = new List<Hashtag>();
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                using (var cmd = new SqlCommand("HashtagGetByPostID", cxn))
                {                                        
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PostID", postId);
                    cxn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            hashtags.Add(new Hashtag { HashtagId = (int)(dr["HashtagID"]), HashtagName = dr["HashtagName"].ToString() });
                        }
                    }
                }               
                return hashtags;
            }           
        }

        private Blogpost PopulateBlogpostFromDataReader(SqlDataReader dr)
        {
            var blogpost = new Blogpost();
            
            blogpost.PostId = (int)dr["PostID"];
            blogpost.Title = dr["Title"].ToString();
            blogpost.datePublished = (DateTime)dr["PublishDate"];

            if (dr["ExpireDate"] != DBNull.Value)
            blogpost.dateExpires = (DateTime)dr["ExpireDate"];

            if (dr["PostContent"] != DBNull.Value)
            blogpost.Content = dr["PostContent"].ToString();

            blogpost.IsApproved = (bool)dr["IsApproved"];
            //blogpost.Author.AuthorId = (int)dr["AuthorID"];
            blogpost.Author.AuthorName = dr["AuthorName"].ToString();
            blogpost.Hashtags = PopulateHashtagsFromDataReaderWithId(blogpost.PostId);

            return blogpost;
        }

        private Hashtag PopulateHashtagFromDataReader(SqlDataReader dr)
        {
            var hashtag = new Hashtag();
            hashtag.HashtagId = (int)dr["HashtagID"];
            hashtag.HashtagName = dr["HashtagName"].ToString();

            return hashtag;
        }

    }
}
