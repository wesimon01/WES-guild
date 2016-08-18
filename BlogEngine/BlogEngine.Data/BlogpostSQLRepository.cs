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
            List<Blogpost> blogposts = new List<Blogpost>();

            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "PostGetAll";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blogposts.Add(PopulateBlogpostFromDataReader(dr));
                    }
                }
            }
            foreach(var post in blogposts)
            {
                post.Hashtags = GetHashtagByPostId(post.PostId);
            }
            return blogposts;
        }

        public Blogpost GetBlogPost(int postId)
        {
            Blogpost blogpost = new Blogpost();

            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = "PostGetByID";
                cmd.CommandType = CommandType.StoredProcedure;     
                cmd.Parameters.AddWithValue("@PostID", postId);
                cmd.Connection = cxn;
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blogpost = PopulateBlogpostFromDataReader(dr);
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
                var cmd = new SqlCommand();

                cmd.CommandText = "PostInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;

                if (blogpost.Title != null)
                cmd.Parameters.AddWithValue("@Title", blogpost.Title);
                cmd.Parameters.AddWithValue("@AuthorName", blogpost.Author.AuthorName);
                cmd.Parameters.AddWithValue("@PublishDate", blogpost.datePublished);
                cmd.Parameters.AddWithValue("@ExpireDate", blogpost.dateExpires);
                cmd.Parameters.AddWithValue("@IsApproved", blogpost.IsApproved);
                cmd.Parameters.AddWithValue("@PostContent", blogpost.Content);
                            
                cxn.Open();
                blogpost.PostId = (int)cmd.ExecuteScalar();
                cxn.Close();
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
                var cmd = new SqlCommand();

                cmd.CommandText = "PostHashInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;

                cmd.Parameters.AddWithValue("@PostID", postId);
                cmd.Parameters.AddWithValue("@HashtagID", hashtagId);

                cxn.Open();
                cmd.ExecuteNonQuery();
                cxn.Close();
            }
        }

        public int AddHashtag(Hashtag hashtag)
        {
            int hashtagId;
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = "HashtagInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;
                
                cmd.Parameters.AddWithValue("@HashtagName", hashtag.HashtagName);

                cxn.Open();
                hashtagId = (int)cmd.ExecuteScalar();
                cxn.Close();
            }
            return hashtagId;
        }

        public void RemoveBlogPost(int postId)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();
                
                cmd.CommandText = "PostDelete";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;
                cmd.Parameters.AddWithValue("@PostID", postId);
               
                cxn.Open();
                cmd.ExecuteNonQuery();
                cxn.Close();            
            }
        }

        public void UpdateBlogPost(Blogpost post)
        {
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var cmd = new SqlCommand();

                cmd.CommandText = "PostUpdate";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;
                cmd.Parameters.AddWithValue("@PostID", post.PostId);
                cmd.Parameters.AddWithValue("@Title", post.Title);
                cmd.Parameters.AddWithValue("@AuthorName", post.Author.AuthorName);
                cmd.Parameters.AddWithValue("@PublishDate", post.datePublished);
                cmd.Parameters.AddWithValue("@ExpireDate", post.dateExpires);
                cmd.Parameters.AddWithValue("@IsApproved", post.IsApproved);
                cmd.Parameters.AddWithValue("@PostContent", post.Content);

                cxn.Open();
                cmd.ExecuteNonQuery();
                cxn.Close();            
            }
            AddHashtagListToDb(post);
        }

        public List<Blogpost> GetPostsbyHashTag(Hashtag hashtag)
        {
            List<Blogpost> blogposts = new List<Blogpost>();

            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "PostGetByHashtagID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HashtagID", hashtag.HashtagId);
                cmd.Connection = cxn;
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        blogposts.Add(PopulateBlogpostFromDataReader(dr));
                    }
                }
            }
            return blogposts;
        }

        
        public List<Hashtag> GetAllHashTags()
        {
            List<Hashtag> hashtags = new List<Hashtag>();

            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "HashtagGetAll";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cxn;
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        hashtags.Add(PopulateHashtagFromDataReader(dr));
                    }
                }
            }
            return hashtags;
        }
    
        public List<Hashtag> GetHashtagByPostId(int postId)
        {
            List<Hashtag> hashtags = new List<Hashtag>();

            using (SqlConnection cxn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "HashtagGetByPostID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostID", postId);
                cmd.Connection = cxn;
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        hashtags.Add(PopulateHashtagFromDataReader(dr));
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
            using (var cxn = new SqlConnection(Settings.ConnectionString))
            {
                var hashtags = new List<Hashtag>();

                var cmd = new SqlCommand();
                cmd.CommandText = "HashtagGetByPostID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PostID", postId);
                cmd.Connection = cxn;
                cxn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        hashtags.Add(new Hashtag { HashtagId = (int)(dr["HashtagID"]), HashtagName = dr["HashtagName"].ToString()});
                    }
                }
                return hashtags;
            }           
        }

        private Blogpost PopulateBlogpostFromDataReader(SqlDataReader dr)
        {
            Blogpost blogpost = new Blogpost();
            
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
            Hashtag hashtag = new Hashtag();

            hashtag.HashtagId = (int)dr["HashtagID"];
            hashtag.HashtagName = dr["HashtagName"].ToString();

            return hashtag;
        }




    }
}
