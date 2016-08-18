using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Models;

namespace BlogEngine.Data
{
    public class BlogpostTestRepository : IBlogpostTestRepository
    {
        private static List<Blogpost> _blogposts;
        
        public BlogpostTestRepository()
        {
            if (_blogposts == null)
            {
                _blogposts = new List<Blogpost>()
            {

            new Blogpost{
            PostId = 1,
            Title = "Lorem ipsum dolor sit amet",
            datePublished = new DateTime(2016,7,1),
            dateExpires = new DateTime (2016,9,1),
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse pretium ex vitae arcu imperdiet pharetra. Vestibulum a felis pharetra, ultrices enim at, porttitor nisl. Aenean tellus velit, tristique vel diam eu, auctor facilisis nulla. Morbi vulputate felis libero, sit amet semper erat placerat eu. Aenean tristique ipsum ac leo congue, eu sagittis ante porta. Aliquam ut sem a ligula tristique fermentum et consectetur metus. Sed non venenatis lacus.",
            IsApproved = true,
            Author = new Author {AuthorId = 1, AuthorName = "Tolstoy" },
            Hashtags = new List<Hashtag> {
            new Hashtag {HashtagId = 1, HashtagName = "Louisville" },
            new Hashtag {HashtagId = 2, HashtagName = "Drinks" }
            }
            },

            new Blogpost{
            PostId = 2,
            Title = "Phasellus venenatis",
            datePublished = new DateTime(2016,7,2),
            dateExpires = new DateTime (2016,9,2),
            Content = "Phasellus venenatis, erat et dignissim semper, nunc leo ullamcorper orci, ac placerat tellus arcu sed magna. Aenean dictum lacus volutpat nunc pharetra scelerisque. Phasellus pharetra tristique accumsan. Sed vehicula mi metus, at porta risus euismod et. Suspendisse et lectus et libero feugiat auctor eu in libero. Donec quis mattis erat. Vivamus eu euismod ante.",
            IsApproved = true,
            Author = new Author {AuthorId = 2, AuthorName = "Hemmingway" },
            Hashtags = new List<Hashtag> {
            new Hashtag {HashtagId = 1, HashtagName = "Louisville" },
            new Hashtag {HashtagId = 3, HashtagName = "GoodEats" }
            }
            },

            new Blogpost{
            PostId = 3,
            Title = "Duis dictum",
            datePublished = new DateTime(2016,7,2),
            dateExpires = new DateTime (2016,8,2),
            Content = "Duis dictum neque id diam pharetra, quis rhoncus leo sodales. Sed pulvinar ex ac mauris rutrum scelerisque. Vestibulum ac viverra metus, non fringilla urna. Cras ullamcorper arcu et diam sollicitudin aliquam. Donec ut aliquet massa. Vivamus et semper nulla. Donec sit amet dignissim erat, a iaculis massa. Donec quis dolor congue quam blandit auctor.",
            IsApproved = true,
            Author = new Author {AuthorId = 3, AuthorName = "AnonymousCoward" },
            Hashtags = new List<Hashtag> {
            new Hashtag {HashtagId = 1, HashtagName = "Louisville" },
            new Hashtag {HashtagId = 2, HashtagName = "Drinks" }
            }
            },

            new Blogpost{
            PostId = 4,
            Title = "Praesent ultricies",
            datePublished = new DateTime(2016,7,2),
            dateExpires = new DateTime (2016,8,2),
            Content = "Praesent ultricies eleifend nunc, sit amet ornare sapien maximus sed. Praesent consectetur sollicitudin libero, eget maximus nunc molestie quis. Vestibulum sit amet sagittis lacus. Aliquam pretium ex eget luctus mattis. Nunc ornare quis justo vitae laoreet. Vivamus justo mauris, lacinia vitae ultrices vel, aliquam id ex. Sed tincidunt aliquet vestibulum. Sed vulputate erat ac turpis mollis sodales.",
            IsApproved = false,
            Author = new Author {AuthorId = 4, AuthorName = "Sauron" },
            Hashtags = new List<Hashtag> {
            new Hashtag {HashtagId = 1, HashtagName = "Louisville" },
            new Hashtag {HashtagId = 3, HashtagName = "GoodEats" }
            }
            },

                };
            };
        }

        public Blogpost GetBlogPost(int postId)
        {
            return _blogposts.FirstOrDefault(b => b.PostId == postId);
        }

        public List<Blogpost> GetAllBlogPosts()
        {
            return _blogposts;
        }

        public void AddBlogPost(Blogpost post)
        {
            if (_blogposts.Any())
                post.PostId = _blogposts.Max(b => b.PostId) + 1;
            else
                post.PostId = 1;
           
            _blogposts.Add(post);

        }

        public void RemoveBlogPost(int postId)
        {
            Blogpost selectedblogpost = _blogposts.FirstOrDefault(b => b.PostId == postId);

            if (selectedblogpost != null)
            {
                _blogposts.RemoveAll(b => b.PostId == selectedblogpost.PostId);
            }
        }

        public List<Hashtag> GetAllHashTags()
        {
            var bloglist = GetAllBlogPosts();
            var hashtags = new List<Hashtag>();
            foreach (var blogpost in bloglist)
            {
                foreach (var tag in blogpost.Hashtags)
                {
                    hashtags.Add(tag);
                }
            }
            var uniquehashtags = hashtags.GroupBy(t => t.HashtagName).Select(t => t.First()).ToList();

            if (uniquehashtags.Count() > 8)
            {
                uniquehashtags.Reverse();
                return uniquehashtags.Take(8).ToList();
            }
            else
            {
                return uniquehashtags;
            }
        }

        public List<Blogpost> GetPostsbyHashTag (Hashtag hashtag)
        {
            return _blogposts.Where(b => b.Hashtags.Exists(h => h.HashtagId == hashtag.HashtagId)).ToList();
        }

        public List<Blogpost> GetPostsbyHashTagName(string hashtagName)
        {         
            return _blogposts.Where(h => h.Hashtags.Exists(n => n.HashtagName == hashtagName)).ToList();
        }

        public void UpdateBlogPost(Blogpost post)
        {
            Blogpost postToUpdate = GetBlogPost(post.PostId);

            postToUpdate.Title = post.Title;
            postToUpdate.datePublished = DateTime.Now;
            postToUpdate.dateExpires = DateTime.Now.AddDays(30);
            postToUpdate.Content = post.Content;
            postToUpdate.IsApproved = post.IsApproved;
            postToUpdate.Author = post.Author;
            postToUpdate.Hashtags = post.Hashtags;

        }
    }
}
    
    